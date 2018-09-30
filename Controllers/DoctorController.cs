using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PGCare.CQRS.Doctor;
using PGCare.ViewModels;

namespace PGCare.Controllers
{
    public class DoctorController : Controller
    {
        #region dependencies
        private readonly IGetDoctorsList _getDoctorsList;
        private readonly IAddUpdateDoctor _addUpdateDoctor;
        private readonly IDeleteDoctor _deleteDoctor;
        #endregion

        public DoctorController(
            IGetDoctorsList getDoctorsList,
            IAddUpdateDoctor addUpdateDoctor,
            IDeleteDoctor deleteDoctor)
        {
            _getDoctorsList = getDoctorsList;
            _addUpdateDoctor = addUpdateDoctor;
            _deleteDoctor = deleteDoctor;
        }

        public async Task<IActionResult> Index()
        {
            var customersLst = await _getDoctorsList.Execute();
            return new JsonResult(customersLst);
        }

        public async Task<IActionResult> AddUpdateDoctor([FromBody] DoctorVM doctor)
        {
            var returnObj = await _addUpdateDoctor.Execute(doctor);
            return new JsonResult(returnObj);
        }

        public async Task<IActionResult> DeleteDoctor(string doctorId)
        {
            var returnObj = await _deleteDoctor.Execute(doctorId);
            return new JsonResult(returnObj);
        }
    }
}