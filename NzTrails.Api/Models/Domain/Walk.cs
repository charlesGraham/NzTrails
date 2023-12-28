using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzTrails.Api.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; } = string.Empty;
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        // navigation
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}
