using System;

namespace Raythos_Aerospace.Models.entities
{
    public class OrderEntity
    {
        public int Id { get; set; } 
        public int CustomerId { get; set; } 
        public DateTime OrderDate { get; set; }
        public int AircraftModelId { get; set; } 
        public decimal Price { get; set; }
        public string OrderStatus { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string SeatingConfiguration { get; set; }
        public string InteriorDesign { get; set; }
        public string AdditionalFeatures { get; set; }
        public int Quantity { get; set; }

        public UserEntity Customer { get; set; } 
        public AircraftEntity AircraftModel { get; set; }
    }
}
