using System.ComponentModel.DataAnnotations;

namespace PGCare.ViewModels
{
    public class DoctorVM
    {
        public string DoctorId { get; set; }

        [Required(ErrorMessage = "Doctor name is required")]
        public string DoctorName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}
