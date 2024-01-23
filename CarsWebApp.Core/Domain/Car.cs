using System.ComponentModel.DataAnnotations;

namespace CarsWebApp.Core.Domain
{
    public class Car
    {
        [Key]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; } // electric, fuel, hybrid etc
        public string FuelType { get; set; } // petrol, electric, hybrid etc
        public string Color { get; set; }
        public string Transmission { get; set; } // automatic, manual etc
        public int EnginePowerKw { get; set; }
        public float Engine { get; set; } // 2.9, 5.0, 4.4 etc
        public DateTime BuiltYear { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
