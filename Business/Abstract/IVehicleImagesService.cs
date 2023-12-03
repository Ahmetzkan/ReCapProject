using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
    public interface IVehicleImagesService
    {
        IResult Add(IFormFile? file, VehicleImage vehicleImage);

        IResult Update(IFormFile file, VehicleImage vehicleImage);
        IResult Delete(VehicleImage vehicleImage);

        IDataResult<List<VehicleImage>> GetAll();
        IDataResult<List<VehicleImage>> GetByVehicleId(int vehicleId);
        IDataResult<VehicleImage> GetByImageId(int imageId);

    }
}
