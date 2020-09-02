using ODoctor.Core.Entities;

namespace ODoctor.Core.Specifications
{
    public class AppointmentSpecification:BaseSpecification<Appointment>
    {
        public AppointmentSpecification(int timeslotId)
            : base(a => a.Token.TimeslotId == timeslotId)
        {
            AddInclude(a => a.Token);
            AddInclude($"{nameof(Appointment.Token)}.{nameof(Appointment.Token.Timeslot)}");
        }
    }
}
