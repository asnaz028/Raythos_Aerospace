using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Raythos_Aerospace.Models.entities
{
    public class AircraftEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string ModelImage { get; set; } 
        public string ModelName { get; set; }
        public string ModelDescription { get; set; }
        public string SKU { get; set; }
        public double Weight { get; set; }
        public decimal BasePrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal Price { get; set; }
        public bool IsSold { get; set; } 
    }
}
