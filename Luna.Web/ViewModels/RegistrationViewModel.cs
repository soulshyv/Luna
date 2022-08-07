using System.ComponentModel.DataAnnotations;

namespace Luna.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
    }
}