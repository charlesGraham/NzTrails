namespace NzTrails.Api.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; } = string.Empty;
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
