using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using PGCare.CQRS.Context;
using PGCare.ViewModels;

namespace PGCare.CQRS.DoctorServices
{

    #region Interface
    public interface IGetDoctorsList
    {
        Task<List<DoctorVM>> Execute();
    }
    #endregion

    public class GetDoctorsList : IGetDoctorsList
    {
        public readonly PGCareContext _db;
        public GetDoctorsList(PGCareContext db)
        {
            _db = db;
        }

        public async Task<List<DoctorVM>> Execute()
        {
            return await _db.Doctors.Find(_ => true).Project(x => new DoctorVM
            {
                DoctorId = x.Id,
                DoctorName = x.DoctorName,
                Address = x.Address
            }).ToListAsync();
        }
    }
}
