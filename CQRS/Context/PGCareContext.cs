using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PGCare.Models;

namespace PGCare.CQRS.Context
{
    #region interface

    public interface IPGCareContext
    {

    }

    #endregion

    public class PGCareContext : IPGCareContext
    {
        private readonly IMongoDatabase _db;

        public PGCareContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _db = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<PGCare.Models.Doctor> Doctors => 
        _db.GetCollection<PGCare.Models.Doctor>("Doctors");

        public IMongoCollection<PGCare.Models.Medicine> Medicines => 
        _db.GetCollection<PGCare.Models.Medicine>("Medicines");

        public IMongoCollection<PGCare.Models.MedicineCategory> MedicineCategories => 
        _db.GetCollection<PGCare.Models.MedicineCategory>("MedicineCategories");

        public IMongoCollection<PGCare.Models.MedicineCommodity> MedicineCommodities => 
        _db.GetCollection<PGCare.Models.MedicineCommodity>("MedicineCommodities");

        public IMongoCollection<PGCare.Models.Purchase> Purchases => 
        _db.GetCollection<PGCare.Models.Purchase>("Purchases");

        public IMongoCollection<PGCare.Models.ScheduledCategory> ScheduledCategories => 
        _db.GetCollection<PGCare.Models.ScheduledCategory>("ScheduledCategories");

        public IMongoCollection<PGCare.Models.Sell> Sells => 
        _db.GetCollection<PGCare.Models.Sell>("Sells");

        public IMongoCollection<PGCare.Models.Stock> Stocks => 
        _db.GetCollection<PGCare.Models.Stock>("Stocks");

        public IMongoCollection<PGCare.Models.WholeSeller> WholeSellers => 
        _db.GetCollection<PGCare.Models.WholeSeller>("WholeSellers");
        
    }
}