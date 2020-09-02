using ODoctor.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace ODoctor.Core.Entities.CalendarAggregate
{
    public class Calendar : BaseEntity<int>, IAggregateRoot
    {
        public Calendar() { }

        public Calendar(int clinicId, int doctorId, List<ServiceAssignment> services)
        {
            ClinicId = clinicId;
            DoctorId = doctorId;
            _services = services;
        }
        public int ClinicId { get; private set; }
        public int DoctorId { get; private set; }

        private readonly List<Timeslot> _slots = new List<Timeslot>();
        public IReadOnlyCollection<Timeslot> Timeslots => _slots.AsReadOnly();

        public readonly List<ServiceAssignment> _services = new List<ServiceAssignment>();
        public IReadOnlyCollection<ServiceAssignment> Services => _services.AsReadOnly();

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
