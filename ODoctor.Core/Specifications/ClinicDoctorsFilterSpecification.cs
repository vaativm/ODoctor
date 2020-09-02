using ODoctor.Core.Entities;

namespace ODoctor.Core.Specifications
{
    public class ClinicDoctorsFilterSpecification: BaseSpecification<ClinicAssignment>
    {
        public ClinicDoctorsFilterSpecification(int? locationId, int? specialityId)
            : base(c => (!locationId.HasValue || c.Clinic.CountyId == locationId) &&
            (!specialityId.HasValue || c.Doctor.SpecialityId == specialityId))
        {
            AddInclude(c => c.Clinic);
            AddInclude(c => c.Doctor);
        }
    }
}
