using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;


//GetVehicleDetails(vehicleManager);
//AddVehicle(vehicleManager);
//vehicleManagerGetAll();

//VehicleTest();
//UserAddTest();
//CustomerAddTest();
RentalTest();


void RentalTest()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());

    var result = rentalManager.Add(
      new Rental
      {
          VehicleId = 1,
          CustomerId = 1,
          RentDate = new DateTime(2023, 11, 12),
          ReturnDate = new DateTime(2023, 11, 29)
      });

    Console.WriteLine(result.Message);
}

//Current versions
void CustomerAddTest()
{
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

    var result = customerManager.Add(new Customer { CompanyName = "Özka" });
    Console.WriteLine(result.Message);
}

void UserAddTest()
{
    UserManager userManager = new UserManager(new EfUserDal());

    var result = userManager.Add(new User { FirstName = "Ali", LastName = "Özkan", Email = "ali@gmail.com", Password = "12345" });
    Console.WriteLine(result.Message);
}

void VehicleTest()
{
    VehicleManager vehcleManager = new VehicleManager(new EfVehicleDal());

    var result = vehcleManager.Add(new Vehicle { Name = "Ahmet", BrandId = 4, ColorId = 3, ModelYear = 2002, DailyPrice = 400, Description = "Otomatic" });
    Console.WriteLine(result.Message);

    foreach (var v in vehcleManager.GetVehicleDetails().Data)
    {
        Console.WriteLine(v.DailyPrice + " --> " + v.BrandName + " --> " + v.ColorName);
    }
}



//Old versions
static void GetVehicleDetails(VehicleManager vehicleManager)
{
    var resultManager = vehicleManager.GetVehicleDetails();
    if (resultManager.Success == true)
    {
        foreach (var vehicles in vehicleManager.GetVehicleDetails().Data)
        {
            Console.WriteLine("Vehicle Brand: " + vehicles.BrandName);
            Console.WriteLine("Vehicle Color: " + vehicles.ColorName);
            Console.WriteLine("Vehicle Daily Price: " + vehicles.DailyPrice);
        }
    }
    else
    {
        Console.WriteLine(resultManager.Message);
    }
}

static void AddVehicle(VehicleManager vehicleManager)
{
    //VehicleManager vehicleManager = new VehicleManager(new EfVehicleDal());
    Vehicle vehicle = new Vehicle() { Name = "Skoda", BrandId = 9, ModelId = 1, ColorId = 1, ModelYear = 2023, DailyPrice = 1500, Description = "1.6" };
    vehicleManager.Add(vehicle);
}

static void vehicleManagerGetAll()
{
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
}
