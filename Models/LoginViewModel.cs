using System.ComponentModel.DataAnnotations;

namespace BestStoreMVC.Models
{
    
        public class LoginViewModel
        {
            [Required]
            [StringLength(100)]
            public string? Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string? Password { get; set; }
        }
    }




