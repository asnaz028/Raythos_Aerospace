using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Raythos_Aerospace.Models.entities
{
    public class ShippingEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public int OrderId { get; set; } 
        public DateTime ShippingDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ContactNumber { get; set; }
        public string CustomerAddress { get; set; }
        public string TrackingNumber { get; set; }

        public OrderEntity Order { get; set; } // Navigation property to OrderEntity

    }
}
