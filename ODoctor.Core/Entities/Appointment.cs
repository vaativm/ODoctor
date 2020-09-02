using ODoctor.Core.Entities.CalendarAggregate;
using System;

namespace ODoctor.Core.Entities
{
    public enum AppointmentStatus : short
    {
        Active = 1,
        InProgress,
        Completed,
        Canceled,
        Expired
    }
    public class Appointment : BaseEntity<int>
    {
        public Appointment() { }
        public Appointment(Patient patient)
        {
            Patient = patient;
            PatientId = patient.Id;
        }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int TokenId { get; set; }
        public Token Token { get; set; }
        public DateTimeOffset BookingDate { get; set; }
        public AppointmentStatus Status { get; set; }

        public override void Validate()
        {
            if (Token.Timeslot.Date < DateTime.Now.Date)
                AddBrokenRule(new BusinessRule($"{nameof(Token.Timeslot.Date)}", "Appointment date can not be in the past"));

            if (Token.Timeslot.StartTime.TimeOfDay < DateTime.Now.TimeOfDay)
                AddBrokenRule(new BusinessRule($"{nameof(Token.Timeslot.StartTime)}", "Appointment start time can not be in the past"));

            if (Token.Timeslot.StartTime >= Token.Timeslot.EndTime)
                AddBrokenRule(new BusinessRule($"{nameof(Token.Timeslot.StartTime)}", "Appointment start time should be less than endtime"));
        }
    }
}