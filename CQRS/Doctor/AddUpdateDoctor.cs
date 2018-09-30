using System.Collections.Generic;
using System.Threading.Tasks;
using PGCare.ViewModels;

namespace PGCare.CQRS.Doctor {

    #region Interface
    public interface IAddUpdateDoctor {
        Task<DoctorVM> Execute (DoctorVM doctor);
    }
    #endregion

    public class AddUpdateDoctor : IAddUpdateDoctor {
        public AddUpdateDoctor () {

        }

        public async Task<DoctorVM> Execute (DoctorVM doctor) {
            return null;
        }
    }
}