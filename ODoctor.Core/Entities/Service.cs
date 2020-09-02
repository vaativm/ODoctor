using System.Collections.Generic;

namespace ODoctor.Core.Entities
{
    public enum Access : short
    {
        Public = 1,
        Private
    }
    public class Service : BaseEntity<int>
    {
        public Service() { }
        public Service(string name, int duration)
        {
            Name = name;
            Duration = duration;
        }
        public string Name { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public Access Access { get; set; }
        public ICollection<CalendarServiceAssignment> AssignedCalendars { get; set; }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
