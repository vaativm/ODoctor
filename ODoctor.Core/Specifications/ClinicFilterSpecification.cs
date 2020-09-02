using ODoctor.Core.Entities;

namespace ODoctor.Core.Specifications
{
    public class ClinicFilterSpecification: BaseSpecification<Clinic>
    {
        public ClinicFilterSpecification(int locationId)
            : base(c => c.CountyId == locationId)
        {
            AddInclude(d => d.Doctors);
        }
    }
}
