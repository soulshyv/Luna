using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Luna.Commons.Models.Identity;

namespace Luna.ViewModels
{
    public class UserViewModel
    {
        public Guid? Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }

        public List<string> Roles { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<LunaIdentityRole> AllRoles { get; set; }

        public UserViewModel()
        {
        }

        public UserViewModel(LunaIdentityUser user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            IsActive = user.IsActive;
        }
    }
}