using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.EntityFramework
{
    [Table("Videos")]
    public class Video
    {
        [Key, Required]
        public Guid VideoId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Title must be less than 50 character")]
        [MinLength(2, ErrorMessage = "Title must be at least 2 character")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "Type must be less than 50 character")]
        [MinLength(2, ErrorMessage = "Type must be at least 2 character")]
        public string Type { get; set; } = string.Empty;
        [Required]
        [MaxLength(250, ErrorMessage = "Location must be less than 50 character")]
        [MinLength(2, ErrorMessage = "Location must be at least 2 character")]
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "Image is required")]
        public string VideoUrl { get; set; } = string.Empty;

    }
}