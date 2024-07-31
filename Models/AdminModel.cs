using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class AdminModel
    {
        [Required(ErrorMessage = "AdminId is required")]
        public Guid AdminId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Admin Name must be less than 50 character")]
        [MinLength(2, ErrorMessage = "Admin Name must be at least 2 character")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(100, ErrorMessage = "Email can be at most 100 characters long.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;

    }
}