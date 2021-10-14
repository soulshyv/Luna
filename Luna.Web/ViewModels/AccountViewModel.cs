using System;
using System.ComponentModel.DataAnnotations;

namespace Luna.ViewModels
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Mot de passe")]
        [MinLength(8, ErrorMessage = "Le mot de passe doit faire au moins {1} caractères.")]
        [RegularExpression(
            "^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{6,}$",
            ErrorMessage =
                "Le mot de passe doit faire 6 caractères et doit contenir des: lettres capitales (A-Z), minuscules (a-z), nombres (0-9) et caractères spéciaux (e.g. !@#$%^&*)")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Confirmez votre mot de passe")]
        [Compare(nameof(Password), ErrorMessage = "Les deux mots de passe doivent correspondre.")]
        public string PasswordValidation { get; set; }
    }
}