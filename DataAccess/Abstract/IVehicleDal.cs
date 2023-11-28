using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IVehicleDal :IEntityRepository<Vehicle>
    {
        List<VehicleDetailsDto> GetVehicleDetails(Expression<Func<VehicleDetailsDto, bool>> filter = null);
    }
}
