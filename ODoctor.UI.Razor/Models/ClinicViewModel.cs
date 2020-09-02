using System.Collections.Generic;

namespace ODoctor.UI.Razor.Models
{
    public class ClinicViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ClinicSpeciality> ClinicSpecialities { get; set; } = new List<ClinicSpeciality>();
    }
}
