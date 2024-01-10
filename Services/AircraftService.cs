using Raythos_Aerospace.Data;
using Raythos_Aerospace.Models.entities;
using Raythos_Aerospace.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<AircraftEntity>> GetAircraftsAsync()
        {
            // Retrieve all aircraft from the database
            return await _context.Aircrafts.ToListAsync();
        }

        public async Task<bool> EditAircraftAsync(AircraftEntity updatedAircraft)
        {
            // Retrieve the existing aircraft from the database
            var existingAircraft = await _context.Aircrafts.FindAsync(updatedAircraft.Id);

            if (existingAircraft == null)
            {
                // Aircraft with the specified ID not found
                return false;
            }

            // Update properties of the existing aircraft with the values from the updated aircraft
            existingAircraft.ModelImage = updatedAircraft.ModelImage;
            existingAircraft.ModelName = updatedAircraft.ModelName;
            existingAircraft.ModelDescription = updatedAircraft.ModelDescription;
            existingAircraft.SKU = updatedAircraft.SKU;
            existingAircraft.Weight = updatedAircraft.Weight;
            existingAircraft.BasePrice = updatedAircraft.BasePrice;
            existingAircraft.MaxPrice = updatedAircraft.MaxPrice;
            existingAircraft.Price = updatedAircraft.Price;
            existingAircraft.IsSold = updatedAircraft.IsSold;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return true;
        }


    }


}
