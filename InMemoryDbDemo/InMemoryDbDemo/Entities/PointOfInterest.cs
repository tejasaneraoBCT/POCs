using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace InMemoryDbDemo.Entities
{
    public class PointOfInterest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public City? City { get; set; }
    }
}
