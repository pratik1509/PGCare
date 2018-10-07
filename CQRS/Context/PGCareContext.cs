using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PGCare.Models;

namespace PGCare.CQRS.Context
{
    #region interface

    public interface IPGCareContext
    {
        IMongoCollection<Doctor> Doctors { get; }
        IMongoCollection<Medicine> Medicines { get; }

    }

    #endregion

    public class PGCareContext : IPGCareContext
    {
        private readonly IMongoDatabase _db;

        public PGCareContext(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            _db = client.GetDatabase(dbName);
        }

        public IMongoCollection<Doctor> Doctors => 
        _db.GetCollection<Doctor>("Doctors");

        public IMongoCollection<Medicine> Medicines => 
        _db.GetCollection<Medicine>("Medicines");

        public IMongoCollection<MedicineCategory> MedicineCategories => 
        _db.GetCollection<MedicineCategory>("MedicineCategories");

        public IMongoCollection<MedicineCommodity> MedicineCommodities => 
        _db.GetCollection<MedicineCommodity>("MedicineCommodities");

        public IMongoCollection<Purchase> Purchases => 
        _db.GetCollection<Purchase>("Purchases");

        public IMongoCollection<ScheduledCategory> ScheduledCategories => 
        _db.GetCollection<ScheduledCategory>("ScheduledCategories");

        public IMongoCollection<Sell> Sells => 
        _db.GetCollection<Sell>("Sells");

        public IMongoCollection<Stock> Stocks => 
        _db.GetCollection<Stock>("Stocks");

        public IMongoCollection<WholeSeller> WholeSellers => 
        _db.GetCollection<WholeSeller>("WholeSellers");
        
    }
}
