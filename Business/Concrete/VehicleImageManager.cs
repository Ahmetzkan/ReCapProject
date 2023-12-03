using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Business.Concrete;
using Business.Constants;


namespace Business.Concrete
{
    public class VehicleImageManager : IVehicleImagesService
    {

        IVehicleImageDal _vehicleImageDal;
        IFileHelper _fileHelper;

        public VehicleImageManager(IVehicleImageDal vehicleImageDal, IFileHelper? fileHelper)
        {
            _vehicleImageDal = vehicleImageDal;
            _fileHelper = fileHelper;
        }
        public Core.Utilities.Results.IResult Add(IFormFile? file, VehicleImage vehicleImage)
        {
            Core.Utilities.Results.IResult result = BusinessRules.Run(CheckIfVehicleImageLimit(vehicleImage.VehicleId));
            if (result != null)
            {
                return result;
            }
            vehicleImage.ImagePath = _fileHelper.Upload(file,PathConstans.ImagesPath);
            vehicleImage.Date = DateTime.Now;
            _vehicleImageDal.Add(vehicleImage);
            return new SuccessResult("Pictures uploaded succesfully");
        }

        public Core.Utilities.Results.IResult Delete(VehicleImage vehicleImage)
        {
            _fileHelper.Delete(PathConstans.ImagesPath + vehicleImage.ImagePath);
            _vehicleImageDal.Delete(vehicleImage);
            return new SuccessResult();
        }

        public Core.Utilities.Results.IResult Update(IFormFile file, VehicleImage vehicleImage)
        {
            vehicleImage.ImagePath = _fileHelper.Update(file,PathConstans.ImagesPath + vehicleImage.ImagePath,PathConstans.ImagesPath);
            _vehicleImageDal.Update(vehicleImage);
            return new SuccessResult();
        }

        public IDataResult<List<VehicleImage>> GetByVehicleId(int vehicleId)
        {
            var result = BusinessRules.Run(CheckVehicleImage(vehicleId));
            if (result != null)
            {
                
                return new ErrorDataResult<List<VehicleImage>>(GetDefaultImage(vehicleId).Data);
            }
            return new SuccessDataResult<List<VehicleImage>>(_vehicleImageDal.GetAll(v=>v.VehicleId ==vehicleId));
        }

        public IDataResult<VehicleImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<VehicleImage>(_vehicleImageDal.Get(v => v.Id == imageId));
        }

        public IDataResult<List<VehicleImage>> GetAll()
        {
            return new SuccessDataResult<List<VehicleImage>>(_vehicleImageDal.GetAll(),Messages.VehicleAdded);

        }

        private IDataResult<List<VehicleImage>> GetDefaultImage(int vehicleId)
        {
            List<VehicleImage> vehicleImage = new List<VehicleImage>();
            vehicleImage.Add(new VehicleImage { VehicleId = vehicleId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<VehicleImage>>(vehicleImage);
        }
     
        private Core.Utilities.Results.IResult CheckIfVehicleImageLimit(int vehicleId)
        {
            var result = _vehicleImageDal.GetAll(v => v.VehicleId == vehicleId).Count;

            if (result>=5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }


        private Core.Utilities.Results.IResult CheckVehicleImage(int vehicleId)
        {
            var result = _vehicleImageDal.GetAll(v => v.VehicleId == vehicleId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }

    }
}



