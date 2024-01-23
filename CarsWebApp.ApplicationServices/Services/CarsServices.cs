using Microsoft.EntityFrameworkCore;
using CarsWebApp.Core.ServiceInterface;
using CarsWebApp.Data;
using CarsWebApp.Core.Domain;
using CarsWebApp.Core.Dto;

namespace CarswebApp.ApplicationServices.Services
{
    public class CarsServices: ICarsServices
    {
        private readonly CarsWebAppContext _context;
        
        public CarsServices (CarsWebAppContext context)
        {
            _context = context;
        }

        public async Task<Car> Create( CarDto dto)
        {
            Car car = new Car();
            car.Id = Guid.NewGuid();
            car.Name = dto.Name;
            car.CarType = dto.CarType;
            car.FuelType = dto.FuelType;
            car.Color = dto.Color;
            car.Transmission = dto.Transmission;
            car.EnginePowerKw = dto.EnginePowerKw;
            car.Engine = dto.Engine;
            car.BuiltYear = dto.BuiltYear;
            car.CreatedAt = dto.CreatedAt;
            car.ModifiedAt = dto.ModifiedAt;
           
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> DetailsAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Car> Update (CarDto dto)
        {
            Car car = new();
            car.Id = dto.Id;
            car.Name = dto.Name;
            car.CarType = dto.CarType;
            car.FuelType = dto.FuelType;
            car.Color = dto.Color;
            car.Transmission = dto.Transmission;
            car.EnginePowerKw = dto.EnginePowerKw;
            car.Engine = dto.Engine;
            car.BuiltYear = dto.BuiltYear;
            car.CreatedAt = dto.CreatedAt;
            car.ModifiedAt = DateTime.Now;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }
    }
}
