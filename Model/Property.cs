using System.ComponentModel.DataAnnotations.Schema;

namespace AccomodationApi.Model
{
    [Table("PropertyName", Schema = "dbo")]
    public class Property
    {
        public int PropertyId { get; set; }
        public string? PropertyName { get; set; }
        public string? PropertyAddress { get; set; }
    }
}
