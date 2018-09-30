using System.Collections.Generic;
using System.Threading.Tasks;
using PGCare.ViewModels;

namespace PGCare.CQRS.Doctor {

    #region Interface
    public interface IDeleteDoctor {
        Task<bool> Execute (string doctorId);
    }
    #endregion

    public class DeleteDoctor : IDeleteDoctor {
        public DeleteDoctor () {

        }

        public async Task<bool> Execute (string doctorId) {
            return false;
        }
    }
}