using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(v => v.UserId).NotEmpty();
            RuleFor(v => v.ModelId).NotEmpty();
            RuleFor(v => v.BrandId).NotEmpty();
            RuleFor(v => v.ColorId).NotEmpty();
            RuleFor(v => v.CustomerId).NotEmpty();
            RuleFor(v => v.DailyPrice).GreaterThan(150);
          
        }

    }
}
