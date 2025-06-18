using System;
using System.ComponentModel.DataAnnotations;


namespace gandolftheblack.Data.Models
{   public class ResourceRequest
    {
        public int Id { get; set; }

        [Required]
        public int RequesterId { get; set; }
        public User? Requester { get; set; }

        [Required, StringLength(50)]
        public string ResourceType { get; set; } = default!;

        [Required, StringLength(500)]
        public string Reason { get; set; } = default!;

        [Required, StringLength(50)]
        public string Duration { get; set; } = default!;

        [StringLength(1000)]
        public string? Notes { get; set; }

        public DateTime CreatedUtc { get; set; } = DateTime.Now;

        [Required, StringLength(20)]
        public string Status { get; set; } = "Pending";  

        public string? NetworkEngineer { get; set; }

        public string? SecurityEngineer { get; set; }

        public string? Manager { get; set; }
    }

}
