using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Driver;
using PGCare.CQRS.Context;

namespace PGCare.Filters.DoctorFilters
{
    public class ValidateDoctorExistsAttribute : TypeFilterAttribute
    {
        public ValidateDoctorExistsAttribute() : base(typeof(ValidateDoctorExistsFilterImpl))
        {
        }
        private class ValidateDoctorExistsFilterImpl : IAsyncActionFilter
        {
            private readonly PGCareContext _dbContext;
            public ValidateDoctorExistsFilterImpl(PGCareContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
            {
                if (context.ActionArguments.ContainsKey("id"))
                {
                    var id = context.ActionArguments["id"] as string;

                    if (id != null)
                    {
                        if (_dbContext.Doctors.Find(x => x.Id == id).CountDocuments() == 0)
                        {
                            context.Result = new NotFoundObjectResult(id);
                            return;
                        }
                    }
                }

                await next();
            }
        }
    }
}