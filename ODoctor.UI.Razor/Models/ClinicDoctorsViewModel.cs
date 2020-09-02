using System.Collections.Generic;

namespace ODoctor.UI.Razor.Models
{
    public class ClinicDoctorsViewModel
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public IList<DoctorProfileViewModel> DoctorProfiles { get; set; } = new List<DoctorProfileViewModel>();
    }
}
