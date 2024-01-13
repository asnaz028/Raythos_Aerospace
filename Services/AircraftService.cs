using Raythos_Aerospace.Data;
using Raythos_Aerospace.Models.entities;
using Raythos_Aerospace.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Raythos_Aerospace.Services
{
    public class AircraftService : IAircraftService
    {
        private readonly RaythosContext _context;

        public AircraftService(RaythosContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAircraftAsync(int aircraftId)
        {
            // Retrieve the aircraft from the database based on its ID
            var aircraftToDelete = await _context.Aircrafts.FindAsync(aircraftId);

            if (aircraftToDelete == null)
            {
                // Aircraft with the specified ID not found
                return false;
            }

            // Remove the aircraft from the context
            _context.Aircrafts.Remove(aircraftToDelete);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreateAircraftAsync(AircraftViewModel aircraftViewModel)
        {
            var aircraftEntity = new AircraftEntity
            {
                ModelImage = aircraftViewModel.ModelImage.FileName,
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


        public async Task<IEnumerable<OrderEntity>> GetOrdersAsync(string status)
        {
            var orders = await _context.Orders
       .Where(o => o.OrderStatus == status)
       .Include(o => o.AircraftModel)
       .ToListAsync();

            return orders;

        }

        public async Task AddToCartAsync(int aircraftModelId, int userId, decimal price, string seatingConfiguration, string interiorDesign, string additionalFeatures, int quantity)
        {
            var order = new OrderEntity
            {
                AircraftModelId = aircraftModelId,
                CustomerId = userId,
                OrderDate = DateTime.UtcNow,
                Price = price,
                OrderStatus = "Cart",
                SeatingConfiguration = seatingConfiguration,
                InteriorDesign = interiorDesign,
                AdditionalFeatures = additionalFeatures,
                Quantity = quantity
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
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
