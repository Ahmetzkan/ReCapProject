using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public void Add(Vehicle entity)
        {
            if (entity.Name.Length>=2 && entity.DailyPrice >=0 )
            {
                _vehicleDal.Add(entity);
            }
        }

        public List<Vehicle> GetAll()
        {
            return _vehicleDal.GetAll();
        }

        public List<Vehicle> GetCarsByBrandId(int Id)
        {
            return _vehicleDal.GetAll(vehicle=>vehicle.Id == Id);
        }

        public List<Vehicle> GetCarsByColorId(int Id)
        {
            return _vehicleDal.GetAll(vehicle => vehicle.Id == Id);
        }
    }
    
}
