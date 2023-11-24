using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model = Entities.Concrete.Model;

namespace Business.Abstract
{
    public interface IModelService
    {
        List<Model> GetAll();
        void Add(Model model);
        void Update(Model model);
        void Delete(Model model);
    }
}
