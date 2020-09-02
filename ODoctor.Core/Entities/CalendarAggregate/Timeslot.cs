using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ODoctor.Core.Entities.CalendarAggregate
{
    public enum TimeslotStatus : short
    {
        Available = 1,
        Closed
    }
    public class Timeslot : BaseEntity<int>
    {
        public Timeslot() { }

        public Timeslot(int calendarId)
        {
            CalendarId = calendarId;
        }
        public int CalendarId { get; set; }
       

        [DataType(DataType.Date)]
        public DateTimeOffset Date { get; set; }

        [DataType(DataType.Time)]
        public DateTimeOffset StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTimeOffset EndTime { get; set; }
        public TimeslotStatus Status { get; set; }

        public int GetBookedTime()
        {
            int bookedTime = 0;

            return bookedTime;
        }

        public int GetAvailableTime()
        {
            var interval = GetInterval();
            var bookedTime = GetBookedTime();
            int availableTime = 0;

            if (!IsCurrent() && !HasExpired())
            {
                availableTime = interval - bookedTime;
            }

            if (IsCurrent())
            {
                // and its not fully booked
                if (bookedTime < interval)
                {
                    var endDateTime = Date.AddHours(EndTime.Hour).AddMinutes(EndTime.Minute);
                    var floatingStartDateTime = Date + TimeSpan.FromMinutes(bookedTime);

                    if (floatingStartDateTime >= DateTime.Now && DateTime.Now <= endDateTime)
                    {
                        availableTime = (int)(endDateTime - DateTime.Now).TotalMinutes;
                    }
                    else
                    {
                        availableTime = (int)(endDateTime - floatingStartDateTime).TotalMinutes;
                    }
                }
            }

            return availableTime;
        }
        public bool HasExpired()
        {
            if (DateTime.Now > Date.AddHours(EndTime.Hour).AddMinutes(EndTime.Minute))
                return true;

            return false;
        }
        public bool IsCurrent()
        {
            DateTimeOffset startDateTime = Date.AddHours(StartTime.Hour).AddMinutes(StartTime.Minute);
            DateTimeOffset endDateTime = Date.AddHours(EndTime.Hour).AddMinutes(EndTime.Minute);

            if (startDateTime >= DateTime.Now && endDateTime < DateTime.Now)
                return true;

            return false;
        }
        public int GetInterval()
        {
            return (int)EndTime.Subtract(StartTime).TotalMinutes;
        }

        public override void Validate()
        {
            if (Date < DateTime.Now.Date)
                AddBrokenRule(new BusinessRule($"{nameof(Date)}", "Appointment date can not be in the past"));

            if (StartTime.TimeOfDay < DateTime.Now.TimeOfDay)
                AddBrokenRule(new BusinessRule($"{nameof(StartTime)}", "Appointment start time can not be in the past"));

            if (StartTime >= EndTime)
                AddBrokenRule(new BusinessRule($"{nameof(StartTime)}", "Appointment start time should be less than endtime"));
        }
    }
}
