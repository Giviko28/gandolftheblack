using System.ComponentModel.DataAnnotations;

namespace gandolftheblack.ViewModels
{
    public class ResourceRequestViewModel
    {
        [Required]
        [Display(Name = "Azure Resource")]
        public string ResourceType { get; set; } = "";

        [Required, StringLength(500)]
        public string Reason { get; set; } = "";

        [Required, StringLength(50)]
        public string Duration { get; set; } = "";

        [StringLength(1000)]
        public string? Notes { get; set; }
    }
}
