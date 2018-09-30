using System.Collections.Generic;
using System.Threading.Tasks;
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
        public GetDoctorsList()
        {

        }

        public async Task<List<DoctorVM>> Execute()
        {
            return null;
        }
    }
}