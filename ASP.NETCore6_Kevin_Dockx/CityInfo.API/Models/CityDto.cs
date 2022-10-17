namespace CityInfo.API.Models
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get;set; }

        public int NumberOfPointsOfInterest
        {
            get //Fields can be made read-only (if you only use the get method),
            {
                return PointOfInterests.Count;
            }
        }
        public ICollection<PointOfInterestDto> PointOfInterests { get; set; }
        = new List<PointOfInterestDto>(); //inicializavom tusciai kolekcijai tam kad isvengtume null reference issues
    }
}
