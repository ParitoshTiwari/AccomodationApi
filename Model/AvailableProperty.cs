using System.ComponentModel.DataAnnotations;

namespace AccomodationApi.Model
{
    public class AvailableProperty
    {
        [Key]
        public int PropertyId { get; set; }
        public int BusStopDuration { get; set; }
        public bool Washer { get; set; }
        public bool Dryer { get; set; }
        public bool Microwave { get; set; }
        public bool Oven { get; set; }
        public bool Refrigerator { get; set; }
        public bool Dishwasher { get; set; }
        public bool Garrage { get; set; }
        public int UserId { get; set; }
        public string? PropertyName { get; set; }
        public string? PropertyAddress { get; set; }
        public string? Name { get; set; }
        public decimal Phone { get; set; }
    }
}
