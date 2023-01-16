using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class CategoryValidation:AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(p => p.CategoryName).NotEmpty().NotNull().MinimumLength(5);
            RuleFor(p => p.CategoryDescription).NotEmpty().NotNull();
            RuleFor(p => p.Status == true);
        }
    }
}
