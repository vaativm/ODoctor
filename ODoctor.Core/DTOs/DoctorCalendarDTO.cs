using ODoctor.Core.Entities;
using System.Collections.Generic;

namespace ODoctor.Core.DTOs
{
    public class DoctorCalendarDTO
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public IEnumerable<Service> Services { get; set; } = new List<Service>();
        public IEnumerable<Timeslot> Timeslots { get; set; } = new List<Timeslot>();
    }
}
