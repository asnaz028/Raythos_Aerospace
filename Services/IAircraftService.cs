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
    }
}
