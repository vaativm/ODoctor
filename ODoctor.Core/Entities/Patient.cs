using System.Collections.Generic;

namespace ODoctor.Core.Entities
{
    public class Patient: BaseEntity<int>
    {
        public Patient() { }
        public Patient(int userId, Contact contact)
        {
            UserId = userId;
            Contact = contact;
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public Contact Contact { get; private set; }
        public IList<Appointment> Appointments { get; set; }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
