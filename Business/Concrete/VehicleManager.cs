using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete;
using Entities.DTO_s;
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

        [ValidationAspect(typeof(VehicleValidator))]
        public IResult Add(Vehicle vehicle)
        {
            _vehicleDal.Add(vehicle);
            return new SuccessResult(Messages.VehicleAdded);

        }

        public IResult Delete(Vehicle vehicle)
        {
            _vehicleDal.Delete(vehicle);
            return new SuccessResult(Messages.VehicleDeleted);
        }

        public IResult Update(Vehicle vehicle)
        {
            _vehicleDal.Update(vehicle);
            return new SuccessResult(Messages.VehicleUpdated);

        }

        public IDataResult<List<Vehicle>> GetAll()
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(),Messages.VehicleListed);
        }

        public IDataResult<List<Vehicle>> GetById(int id)
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(v => v.Id == id),Messages.VehicleListed);
        }

        public IDataResult<List<VehicleDetailsDto>> GetVehicleDetails()
        {
            return new SuccessDataResult<List<VehicleDetailsDto>>(_vehicleDal.GetVehicleDetails());
        }

        public IDataResult<List<Vehicle>> GetVehiclesByBrandId(int Id)
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(v => v.Id == Id));
        }

        public IDataResult<List<Vehicle>> GetVehiclesByColorId(int Id)
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(v => v.Id == Id));
        }

        public IDataResult<List<Vehicle>> GetVehiclesByModelId(int Id)
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(v => v.Id == Id));
        }

    }

}
