using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using PGCare.CQRS.Context;
using PGCare.ViewModels;

namespace PGCare.CQRS.Doctor
{

    #region Interface
    public interface IGetDoctorDetail
    {
        Task<List<DoctorVM>> Execute(string doctorId);
    }
    #endregion

    public class GetDoctorDetail : IGetDoctorDetail
    {
        public readonly PGCareContext _context;
        public GetDoctorDetail(PGCareContext context)
        {
            _context = context;
        }

        public async Task<List<DoctorVM>> Execute(string doctorId)
        {
            return await _context.Doctors.Find(x => x.Id == doctorId).Project(x => new DoctorVM
            {
                DoctorId = x.Id,
                DoctorName = x.DoctorName,
                Address = x.Address
            }).ToListAsync();
        }
    }
}