namespace NzTrails.Api.Models.DTO
{
    public class UpdateAsyncRequestDto
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? RegionImageUrl { get; set; } = string.Empty;
    }
}
