using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        List<Vehicle> GetAll();
        List<Vehicle> GetVehicleDetails();
        List<Vehicle> GetById(int Id);
        List<Vehicle> GetCarsByBrandId(int Id);
        List<Vehicle> GetCarsByColorId(int Id);
    

        void Add(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(Vehicle vehicle);

       
    }
}
