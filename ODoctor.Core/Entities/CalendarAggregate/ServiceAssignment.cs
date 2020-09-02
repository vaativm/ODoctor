namespace ODoctor.Core.Entities.CalendarAggregate
{
    public class ServiceAssignment
    {
        public int CalendarId { get; set; }
        public Calendar Calendar { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
