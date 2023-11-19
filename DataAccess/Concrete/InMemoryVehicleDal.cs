using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryVehicleDal : IVehicleDal
    {
        List<Vehicle> _vehicles;
        public InMemoryVehicleDal()
        {
            _vehicles = new List<Vehicle>()
            {
                new Vehicle() {VehicleId=1,BrandId=1,ColorId=1,Description="Audi",DailyPrice=2000,ModelYear=2023},
                new Vehicle() {VehicleId=2,BrandId=2,ColorId=2,Description="Volvo",DailyPrice=1500,ModelYear=2020},
                new Vehicle() {VehicleId=3,BrandId=3,ColorId=3,Description="Honda",DailyPrice=1000,ModelYear=2021},
                new Vehicle() {VehicleId=4,BrandId=4,ColorId=4,Description="Hyundai",DailyPrice=1000,ModelYear=2022},
            };
        }
        void IVehicleDal.Add(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }


        void IVehicleDal.Delete(Vehicle vehicle)
        {
            Vehicle vehicleToDelete = _vehicles.SingleOrDefault(v => v.VehicleId == vehicle.VehicleId);
            _vehicles.Remove(vehicleToDelete);
        }

        void IVehicleDal.Update(Vehicle vehicle)
        {
            Vehicle vehicleToUpdate = _vehicles.SingleOrDefault(v => v.VehicleId == vehicle.VehicleId);
            vehicleToUpdate.VehicleId = vehicle.VehicleId;
            vehicleToUpdate.BrandId = vehicle.BrandId;
            vehicleToUpdate.ColorId = vehicle.ColorId;
            vehicleToUpdate.ModelYear = vehicle.ModelYear;
            vehicleToUpdate.DailyPrice = vehicle.DailyPrice;
            vehicleToUpdate.Description = vehicle.Description;
        }

        List<Vehicle> IVehicleDal.GetById(int VehicleId)
        {
            return _vehicles.Where(v => v.VehicleId == VehicleId).ToList();
        }


        List<Vehicle> IVehicleDal.GetAll()
        {
            return _vehicles;
        }

    }
}
