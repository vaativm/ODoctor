using System.Collections.Generic;

namespace ODoctor.UI.Razor.Models
{
    public class DoctorSearchVM
    {
        public IList<ClinicViewModel> Clinics { get; set; } = new List<ClinicViewModel>();
        public IList<ClinicSpeciality> ClinicSpecialityCounts { get; set; } = new List<ClinicSpeciality>();
    }
}