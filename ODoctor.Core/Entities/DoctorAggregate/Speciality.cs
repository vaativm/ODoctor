using System.ComponentModel.DataAnnotations;

namespace ODoctor.Core.Entities.DoctorAggregate
{
    public class Speciality : BaseEntity<int>
    {
        public Speciality() { }
        public Speciality(string name)
        {
            Name = name;
        }

        [StringLength(100, ErrorMessage = "Name can only be 100 characters")]
        public string Name { get; set; }
        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
