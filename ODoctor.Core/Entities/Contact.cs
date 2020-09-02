using System.ComponentModel.DataAnnotations;

namespace ODoctor.Core.Entities
{
    public class Contact 
    {

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "Email address should not be more than 100 characters")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [StringLength(13, ErrorMessage = "Phone number should not be more than 13 characters")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
