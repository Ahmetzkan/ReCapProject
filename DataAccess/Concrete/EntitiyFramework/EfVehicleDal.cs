using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfVehicleDal : EfEntityRepositoryBase<Vehicle, RentACarContext>, IVehicleDal
    {
        List<VehicleDetailsDto> IVehicleDal.GetVehicleDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from veh in context.Vehicles
                             join b in context.Brands on veh.BrandId equals b.Id
                             join mo in context.Models on veh.ModelId equals mo.Id
                             join c in context.Colors on veh.ColorId equals c.Id
                             select new VehicleDetailsDto
                             {
                                 VehicleId =  veh.Id,
                                 BrandName = b.Name,
                                 ModelName = mo.Name,
                                 ColorName = c.Name,
                                 DailyPrice = veh.DailyPrice
                             };
                return result.ToList();              

            }
        }
    }
}
