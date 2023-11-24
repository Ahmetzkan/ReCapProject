using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete;

VehicleManager vehicleManager = new VehicleManager(new EfVehicleDal());
//Vehicle vehicle = new Vehicle() { Name = "Audi", BrandId = 1, ColorId = 1, DailyPrice = 1500, Description = "1.6", ModelYear = 2023 }; 
//vehicleManager.Add(vehicle);

//foreach (var vehicleDal in vehicleManager.GetAll())
//{
//    Console.WriteLine("---------------");
//    Console.WriteLine("Vehicle Id: " + vehicleDal.Id);
//    Console.WriteLine("Vehicle Name: " + vehicleDal.Name);
//    Console.WriteLine("Brand Id: " + vehicleDal.BrandId);
//    Console.WriteLine("Vehicle Color " + vehicleDal.ColorId);
//    Console.WriteLine("Vehicle Description: " + vehicleDal.Description);
//    Console.WriteLine("Vehicle Model Year: " + vehicleDal.ModelYear);
//    Console.WriteLine("Vehicle Daily Price: " + vehicleDal.DailyPrice);
//}

//Console.WriteLine("-------Get Cars By Brand Id:1 -------");
//foreach (var vehicleDal in vehicleManager.GetCarsByBrandId(1))
//{
//    Console.WriteLine(vehicleDal.Name);
//}

//Console.WriteLine("-------Get Cars By Color Id:1 -------");

//foreach (var vehicleDal in vehicleManager.GetCarsByColorId(1))
//{
//    Console.WriteLine(vehicleDal.Name);
//}

foreach (var vehicle in vehicleManager.GetVehicleDetails())
{
    Console.WriteLine("Car Brand: " + vehicle.BrandName);
    Console.WriteLine("Car Color: " + vehicle.ColorName);
    Console.WriteLine("Car Daily Price: " + vehicle.DailyPrice);
}