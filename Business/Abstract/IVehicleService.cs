using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        IDataResult<List<Vehicle>> GetAll();
        IDataResult<List<Vehicle>> GetById(int Id);
        IDataResult<List<Vehicle>> GetVehiclesByBrandId(int Id);
        IDataResult<List<Vehicle>> GetVehiclesByColorId(int Id);
        IDataResult<List<Vehicle>> GetVehiclesByModelId(int Id);
        IDataResult<List<VehicleDetailsDto>> GetVehicleDetails();


        IResult Add(Vehicle vehicle);
        IResult Update(Vehicle vehicle);
        IResult Delete(Vehicle vehicle);

       
    }
}
