using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag.AspNetCore;
using PGCare.CQRS.Context;
using PGCare.CQRS.DoctorServices;
using System.Reflection;

namespace PGCare
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            // Add framework services.
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwagger();

            // configuring connection to PGCare database
            services.Configure<Settings>(
                options =>
                {
                    options.ConnectionString = Configuration.GetSection("MongoDb:ConnectionString").Value;
                    options.Database = Configuration.GetSection("MongoDb:Database").Value;
                });

            // var settings = Configuration.GetSection("Root:MongoDB").Get<Settings>();
            services.Configure<Settings>(options => Configuration.GetSection("MongoDB").Bind(options));

            //db context
            services.AddSingleton<IPGCareContext, PGCareContext>();

            var db =
                new PGCareContext(Configuration["MongoDB:ConnectionString"], Configuration["MongoDB:Database"]);
            //doctor services
            services.AddScoped<IAddUpdateDoctor>(s => new AddUpdateDoctor(db));
            services.AddScoped<IDeleteDoctor>(s => new DeleteDoctor(db));
            services.AddScoped<IGetDoctorDetail>(s => new GetDoctorDetail(db));
            services.AddScoped<IGetDoctorsList>(s => new GetDoctorsList(db));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Webpack initialization with hot-reload.
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;
            });

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.MapWhen(a => !a.Request.Path.Value.StartsWith("/swagger"), builder =>
                builder.UseMvc(routes =>
                {
                    routes.MapSpaFallbackRoute(
                        name: "spa-fallback",
                        defaults: new { controller = "Home", action = "Index" });
                })
            );
        }
    }
}
