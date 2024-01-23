using Microsoft.AspNetCore.Mvc;
using CarsWebApp.Core.ServiceInterface;
using CarsWebApp.Data;
using CarsWebApp.Models.Cars;
using CarsWebApp.Core.Dto;

namespace CarsWebApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsWebAppContext _context;
        private readonly ICarsServices _carsServices;

        public CarsController(CarsWebAppContext context, ICarsServices carsServices)
        {
            _context = context;
            _carsServices = carsServices;
        }
        public IActionResult Index()
        {
            var result = _context.Cars
                .Select(x => new IndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CarType = x.CarType,
                    FuelType = x.FuelType,
                    Color = x.Color,
                    Transmission = x.Transmission,
                    EnginePowerKw = x.EnginePowerKw,
                    Engine = x.Engine,
                    BuiltYear = x.BuiltYear
                });

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carsServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var carVm = new DetailsViewModel();

            carVm.Id = car.Id;
            carVm.Name = car.Name;
            carVm.CarType = car.CarType;
            carVm.FuelType = car.FuelType;
            carVm.Color = car.Transmission;
            carVm.Transmission = car.Transmission;
            carVm.EnginePowerKw = car.EnginePowerKw;
            carVm.Engine = car.Engine;
            carVm.BuiltYear = car.BuiltYear;
            carVm.CreatedAt = car.CreatedAt;
            carVm.ModifiedAt = car.ModifiedAt;

            return View(carVm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateUpdateViewModel result = new CreateUpdateViewModel();
            return View("CreateUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateViewModel vm)
        {
            var CarDto = new CarDto();

            CarDto.Id = vm.Id;
            CarDto.Name = vm.Name;
            CarDto.CarType = vm.CarType;
            CarDto.FuelType = vm.FuelType;
            CarDto.Color = vm.Color;
            CarDto.Transmission = vm.Transmission;
            CarDto.EnginePowerKw = vm.EnginePowerKw;
            CarDto.Engine = vm.Engine;
            CarDto.BuiltYear = vm.BuiltYear;
            CarDto.CreatedAt = vm.CreatedAt;
            CarDto.ModifiedAt = vm.ModifiedAt;

            var result = await _carsServices.Create(CarDto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), CarDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carsServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var Carvm = new CreateUpdateViewModel();

            Carvm.Id = car.Id;
            Carvm.Name = car.Name;
            Carvm.CarType = car.CarType;
            Carvm.FuelType = car.FuelType;
            Carvm.Color = car.Color;
            Carvm.Transmission = car.Transmission;
            Carvm.EnginePowerKw = car.EnginePowerKw;
            Carvm.Engine = car.Engine;
            Carvm.BuiltYear = car.BuiltYear;
            Carvm.CreatedAt = car.CreatedAt;
            Carvm.ModifiedAt = car.ModifiedAt;

            return View("CreateUpdate", Carvm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreateUpdateViewModel vm)
        {

            var dto = new CarDto();
            dto.Id = vm.Id;
            dto.Name = vm.Name;
            dto.CarType = vm.CarType;
            dto.FuelType = vm.FuelType;
            dto.Color = vm.Color;
            dto.Transmission = vm.Transmission;
            dto.EnginePowerKw = vm.EnginePowerKw;
            dto.Engine = vm.Engine;
            dto.CreatedAt = vm.CreatedAt;
            dto.ModifiedAt = DateTime.Now;
            
            var result = await _carsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carsServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var Carvm = new DeleteViewModel();

            Carvm.Id = car.Id;
            Carvm.Name = car.Name;
            Carvm.CarType = car.CarType;
            Carvm.FuelType = car.FuelType;
            Carvm.Color = car.Transmission;
            Carvm.Transmission = car.Transmission;
            Carvm.EnginePowerKw = car.EnginePowerKw;
            Carvm.Engine = car.Engine;
            Carvm.BuiltYear = car.BuiltYear;
            Carvm.CreatedAt = car.CreatedAt;
            Carvm.ModifiedAt= car.ModifiedAt;

            return View(Carvm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carId = await _carsServices.Delete(id);

            if (carId == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
