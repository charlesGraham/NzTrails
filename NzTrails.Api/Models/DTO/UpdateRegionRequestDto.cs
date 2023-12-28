using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzTrails.Api.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? RegionImageUrl { get; set; } = string.Empty;
    }
}
