namespace CarsWebApp.Core.Dto
{
     public class CarDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; } 
        public string FuelType { get; set; } 
        public string Color { get; set; }
        public string Transmission { get; set; } 
        public int EnginePowerKw { get; set; }
        public float Engine { get; set; } 
        public DateTime BuiltYear { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
