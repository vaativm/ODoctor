using ODoctor.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ODoctor.Core.Entities.ClinicAggregate
{
    public class Clinic : BaseEntity<int>, IAggregateRoot
    {
        public Clinic() { }

        public Clinic(Contact contact, Address address)
        {
            Contact = contact;
            Address = address;
        }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name should be between 2 and 100 characters")]
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public Contact Contact { get; private set; }

        private readonly List<DoctorAssignment> _doctors = new List<DoctorAssignment>();
        public IReadOnlyCollection<DoctorAssignment> Doctors => _doctors.AsReadOnly();

        private readonly List<Service> _services = new List<Service>();
        public IReadOnlyCollection<Service> Services => _services.AsReadOnly();

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
