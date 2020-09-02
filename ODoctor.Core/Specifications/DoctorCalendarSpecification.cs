using ODoctor.Core.Entities;

namespace ODoctor.Core.Specifications
{
    public class DoctorCalendarSpecification:BaseSpecification<Calendar>
    {
        public DoctorCalendarSpecification(int doctorId, int clinicId)
            : base(c => c.DoctorId == doctorId && c.ClinicId == clinicId)
        {
            AddInclude(c => c.Doctor);
            AddInclude(c => c.Clinic);
            AddInclude(c => c.Timeslots);
            AddInclude($"{nameof(Calendar.Clinic)}.{nameof(Calendar.Clinic.Services)}");
        }
    }
}
