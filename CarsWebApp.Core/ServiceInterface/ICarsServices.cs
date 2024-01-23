using CarsWebApp.Core.Domain;
using CarsWebApp.Core.Dto;

namespace CarsWebApp.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> Create(CarDto dto);
        Task<Car> Update(CarDto dto);
        Task<Car> DetailsAsync(Guid id);
        Task<Car> Delete(Guid id);
    }
}
