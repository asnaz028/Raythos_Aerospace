using Raythos_Aerospace.Data;
using Raythos_Aerospace.Models.entities;
using Raythos_Aerospace.Models.ViewModels;
using System.Threading.Tasks;

namespace Raythos_Aerospace.Services
{
    public class AircraftService : IAircraftService
    {
        private readonly RaythosContext _context;

        public AircraftService(RaythosContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAircraftAsync(AircraftViewModel aircraftViewModel)
        {
            var aircraftEntity = new AircraftEntity
            {
                ModelImage = aircraftViewModel.ModelImage,
                ModelName = aircraftViewModel.ModelName,
                ModelDescription = aircraftViewModel.ModelDescription,
                SKU = aircraftViewModel.SKU,
                Weight = aircraftViewModel.Weight,
                BasePrice = aircraftViewModel.BasePrice,
                MaxPrice = aircraftViewModel.MaxPrice,
                Price = aircraftViewModel.Price,
                IsSold = aircraftViewModel.IsSold
            };

            _context.Aircrafts.Add(aircraftEntity);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
