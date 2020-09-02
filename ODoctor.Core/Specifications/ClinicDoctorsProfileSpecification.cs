using ODoctor.Core.Entities;
using System.Collections.Generic;

namespace ODoctor.Core.Specifications
{
    public class ClinicDoctorsProfileSpecification: BaseSpecification<ClinicAssignment>
    {
        public ClinicDoctorsProfileSpecification(int clinicId, HashSet<int> specialities)
            : base(a => a.ClinicId == clinicId && specialities.Contains(a.Doctor.SpecialityId))
        {
            AddInclude(a => a.Doctor);
            AddInclude(a => a.Clinic);
            AddInclude($"{nameof(ClinicAssignment.Doctor)}.{nameof(ClinicAssignment.Doctor.Speciality)}");
        }
    }
}
