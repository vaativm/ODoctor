using Microsoft.AspNetCore.Mvc.Rendering;
using ODoctor.Core.Entities;
using System.Collections.Generic;

namespace ODoctor.UI.Razor.Models
{
    public class DoctorCalendarViewModel
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public int ServiceId { get; set; }
        public SelectList Services { get; set; }
        public IEnumerable<Timeslot> Timeslots { get; set; } = new List<Timeslot>();
    }
}
