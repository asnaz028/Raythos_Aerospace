using Raythos_Aerospace.Models.entities;
using Raythos_Aerospace.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Raythos_Aerospace.Services
{
    public interface IAircraftService
    {
        Task<bool> CreateAircraftAsync(AircraftViewModel aircraft);

        Task<bool> EditAircraftAsync(AircraftEntity aircraft);

        Task<IEnumerable<AircraftEntity>> GetAircraftsAsync();

        Task<IEnumerable<OrderEntity>> GetOrdersAsync(string status);

        Task<bool> DeleteAircraftAsync(int aircraftId);

        Task<bool> UpdateOrderStatus(int id, string status);

        Task<OrderEntity> GetOrderById(int id);

        Task AddToCartAsync(int aircraftModelId, int userId, decimal price, string seatingConfiguration, string interiorDesign, string additionalFeatures, int quantity);
    }
}
