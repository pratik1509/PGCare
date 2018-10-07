using System;
using System.Threading.Tasks;
using PGCare.CQRS.Context;
using PGCare.Helpers;
using PGCare.Models;
using PGCare.ViewModels;

namespace PGCare.CQRS.DoctorServices
{

    #region Interface
    public interface IAddUpdateDoctor {
        Task<string> Execute(Doctor doctor);
    }
    #endregion

    public class AddUpdateDoctor : IAddUpdateDoctor {
        private readonly IPGCareContext _db;

        public AddUpdateDoctor (IPGCareContext db) {
            _db = db;
        }

        public async Task<string> Execute (Doctor doctor) {
            await _db.Doctors.InsertOneAsync(new Models.Doctor
            {
                DoctorName = doctor.DoctorName,
                Address = doctor.Address,                
                CreatedOn = Utils.ConvertDateTime(DateTime.Now)
            });

            return doctor.Id;
        }
    }
}
