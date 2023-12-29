using System.ComponentModel.DataAnnotations;

namespace NzTrails.Api.Models.DTO
{
    public class RegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code must be 3 characters long.")]
        [MaxLength(3, ErrorMessage = "Code must be 3 characters long.")]
        public string Code { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;
        public string? RegionImageUrl { get; set; } = string.Empty;
    }
}
