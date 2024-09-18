
using System.ComponentModel.DataAnnotations;

namespace BestStoreMVC.Models
{
    public class CustomerDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Email { get; set; } = "";
        [Required, MaxLength(15)]
        public string Phone { get; set; } = "";
        [MaxLength(200)]
        public string Address { get; set; } = "";
    }
}


