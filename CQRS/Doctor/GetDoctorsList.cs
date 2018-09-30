using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using PGCare.CQRS.Context;
using PGCare.ViewModels;

namespace PGCare.CQRS.Doctor
{

    #region Interface
    public interface IGetDoctorsList
    {
        Task<List<DoctorVM>> Execute();
    }
    #endregion

    public class GetDoctorsList : IGetDoctorsList
    {
        public readonly PGCareContext _context;
        public GetDoctorsList(PGCareContext context)
        {
            _context = context;
        }

        public async Task<List<DoctorVM>> Execute()
        {
            return await _context.Doctors.Find(_ => true).Project(x => new DoctorVM
            {
                DoctorId = x.Id,
                DoctorName = x.DoctorName,
                Address = x.Address
            }).ToListAsync();
        }
    }
}