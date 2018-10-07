using PGCare.CQRS.Context;
using System.Threading.Tasks;

namespace PGCare.CQRS.DoctorServices
{

    #region Interface
    public interface IDeleteDoctor {
        Task<bool> Execute (string doctorId);
    }
    #endregion

    public class DeleteDoctor : IDeleteDoctor {

        private readonly IPGCareContext _db;

        public DeleteDoctor (IPGCareContext db) {
            _db = db;
        }

        public async Task<bool> Execute (string doctorId) {
            return false;
        }
    }
}
