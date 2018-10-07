using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PGCare.CQRS.DoctorServices;
using PGCare.ViewModels;
using PGCare.Filters.DoctorFilters;
using PGCare.Filters;

namespace PGCare.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<DoctorVM>> Get([FromRoute] string id)
        {
            var doctor = await _getDoctorDetail.Execute(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        [HttpGet]
        public async Task<ActionResult<DoctorVM>> GetAll()
        {
            return Ok(await _getDoctorsList.Execute());
        }

        [HttpPost]
        [ValidateModelAttribute]
        public async Task<ActionResult<string>> Add([FromBody] DoctorVM doctor)
        {
            var doctorId = await _addUpdateDoctor.Execute(new Models.Doctor
            {
                DoctorName = doctor.DoctorName,
                Address = doctor.Address
            });

            return CreatedAtAction("Get", new { id = doctorId });
        }

        [HttpPut]
        public async Task<IActionResult> Delete(string id)
        {
            var isDeleted = await _deleteDoctor.Execute(id);
            return new JsonResult(new Result { IsSucccess = isDeleted });
        }
    }
}
