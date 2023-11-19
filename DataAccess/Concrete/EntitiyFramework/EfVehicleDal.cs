using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfVehicleDal : IVehicleDal
    {
        public void Add(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void Delete(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAll()
        {
            return new List<Vehicle> { new Vehicle { VehicleId = 1 }, new Vehicle { VehicleId = 2 } };
        }

        public List<Vehicle> GetById(int VehicleId)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
