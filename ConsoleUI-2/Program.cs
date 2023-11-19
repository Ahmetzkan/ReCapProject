using Business.Concrete;
using DataAccess.Concrete;

VehicleManager vehicleManager = new VehicleManager(new InMemoryVehicleDal());

foreach (var vehicleDal in vehicleManager.GetAll())
{
    Console.WriteLine("---------------");
    Console.WriteLine("Vehicle Id: " + vehicleDal.VehicleId);
    Console.WriteLine("Brand Id: " + vehicleDal.BrandId);
    Console.WriteLine("Vehicle Color " + vehicleDal.ColorId);
    Console.WriteLine("Vehicle Description: " + vehicleDal.Description);
    Console.WriteLine("Vehicle Model Year: " + vehicleDal.ModelYear);
    Console.WriteLine("Vehicle Daily Price: " + vehicleDal.DailyPrice);
}