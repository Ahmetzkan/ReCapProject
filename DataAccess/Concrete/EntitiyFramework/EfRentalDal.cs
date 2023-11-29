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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalsDetails(Expression<Func<RentalDetailsDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join v in context.Vehicles on r.Id equals v.Id
                             join cu in context.Customers on r.Id equals cu.Id
                             join u in context.Users on cu.Id equals u.Id
                             join b in context.Brands on v.Id equals b.Id
                             join m in context.Models on v.Id equals m.Id


                             select new RentalDetailsDto
                             {
                                 Id = r.Id,
                                 VehicleId = v.Id,
                                 CustomerId = cu.Id,
                                 UserId = u.Id,
                                 BrandName = b.Name,
                                 ModelName = m.Name,
                                 FirstName = r.FirstName,
                                 LastName = r.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
      

        }
    }
}
