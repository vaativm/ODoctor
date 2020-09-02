namespace ODoctor.Core.Entities.ClinicAggregate
{
    public class DoctorAssignment
    {
        public int ClinicId { get; set; }
        public int DoctorId { get; set; }

        public Clinic Clinic { get; set; }
        public Doctor Doctor { get; set; }
    }
}
