using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
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
    public class EfModelDal : EfEntityRepositoryBase<Model, RentACarContext>, IModelDal
    {
        public void Add(IModelDal entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IModelDal entity)
        {
            throw new NotImplementedException();
        }

        public IModelDal Get(Expression<Func<IModelDal, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<IModelDal> GetAll(Expression<Func<IModelDal, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(IModelDal entity)
        {
            throw new NotImplementedException();
        }
    }
}
