
// Models/RegisterViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace BestStoreMVC.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(100)]
        public string? Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
