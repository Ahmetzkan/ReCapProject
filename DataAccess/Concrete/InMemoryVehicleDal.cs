using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Vehicle() {Id=1,BrandId=1,ColorId=1,Description="Audi",DailyPrice=2000,ModelYear=2023},
                new Vehicle() {Id=2,BrandId=2,ColorId=2,Description="Volvo",DailyPrice=1500,ModelYear=2020},
                new Vehicle() {Id=3,BrandId=3,ColorId=3,Description="Honda",DailyPrice=1000,ModelYear=2021},
                new Vehicle() {Id=4,BrandId=4,ColorId=4,Description="Hyundai",DailyPrice=1000,ModelYear=2022},
            };
        }


        public List<Vehicle> GetAll(Expression<Func<Vehicle, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Vehicle Get(Expression<Func<Vehicle, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehiclesByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetCarsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehiclesByColorId(int colorId)
        {
            throw new NotImplementedException();
        }
    }
}