using ODoctor.Core.Entities;
using System.Collections.Generic;

namespace ODoctor.Core.Specifications
{
    public class ClinicWithDoctorsFilterSpecification: BaseSpecification<Clinic>
    {
        public ClinicWithDoctorsFilterSpecification(HashSet<int> selectedLocations)
            : base(c => selectedLocations.Contains(c.CountyId))
        {
            AddInclude(c => c.Doctors);
            AddInclude($"{nameof(Clinic.Doctors)}.{nameof(ClinicAssignment.Doctor)}");
        }
    }
}
