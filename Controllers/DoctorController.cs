using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PGCare.CQRS.Doctor;
using PGCare.ViewModels;
using PGCare.Filters.DoctorFilters;
using PGCare.Filters;

namespace PGCare.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class DoctorController : Controller
    {
        #region dependencies
        private readonly IGetDoctorDetail _getDoctorDetail;
        private readonly IGetDoctorsList _getDoctorsList;
        private readonly IAddUpdateDoctor _addUpdateDoctor;
        private readonly IDeleteDoctor _deleteDoctor;
        #endregion

        public DoctorController(
            IGetDoctorDetail getDoctorDetail,
            IGetDoctorsList getDoctorsList,
            IAddUpdateDoctor addUpdateDoctor,
            IDeleteDoctor deleteDoctor)
        {
            _getDoctorDetail = getDoctorDetail;
            _getDoctorsList = getDoctorsList;
            _addUpdateDoctor = addUpdateDoctor;
            _deleteDoctor = deleteDoctor;
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(DoctorVM), (int)HttpStatusCode.OK)]
        [ValidateDoctorExistsAttribute]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var doctor = await _getDoctorDetail.Execute(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DoctorVM>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _getDoctorsList.Execute());
        }

        [HttpPost]
        [ProducesResponseType(typeof(IDictionary<string, string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DoctorVM), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddUpdate([FromBody] DoctorVM doctor)
        {

            return CreatedAtAction("GetAll", null);
        }

        public async Task<IActionResult> Delete(string doctorId)
        {
            var isDeleted = await _deleteDoctor.Execute(doctorId);
            return new JsonResult(new Result { IsSucccess = isDeleted });
        }
    }
}