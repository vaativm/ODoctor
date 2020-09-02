using ODoctor.Core.Entities.CalendarAggregate;

namespace ODoctor.Core.Entities.DoctorAggregate
{
    public class Doctor : BaseEntity<int>
    {
        public Doctor() { }
        public Doctor(Contact contact, int specialityId, Calendar calendar)
        {
            Contact = contact;
            SpecialityId = specialityId;
            Calendar = calendar;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {MiddleName} {LastName}"; }
        }

        public int SpecialityId { get; private set; }
        public Contact Contact { get; private set; }
        public Calendar Calendar { get; private set; }
        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
