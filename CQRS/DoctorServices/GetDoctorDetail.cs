using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using PGCare.CQRS.Context;
using PGCare.ViewModels;

namespace PGCare.CQRS.DoctorServices
{

    #region Interface
    public interface IGetDoctorDetail
    {
        Task<DoctorVM> Execute(string doctorId);
    }
    #endregion

    public class GetDoctorDetail : IGetDoctorDetail
    {
        private readonly PGCareContext _db;

        public GetDoctorDetail(PGCareContext db)
        {
            _db = db;
        }

        public async Task<DoctorVM> Execute(string doctorId)
        {
            return await _db.Doctors.Find(x => x.Id == doctorId).Project(x => new DoctorVM
            {
                DoctorId = x.Id,
                DoctorName = x.DoctorName,
                Address = x.Address
            }).FirstOrDefaultAsync();
        }
    }
}
