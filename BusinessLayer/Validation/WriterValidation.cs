using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
	public class WriterValidation:AbstractValidator<Writer>
	{
        public WriterValidation()
        {
            RuleFor(p=>p.WriterName).NotEmpty().WithMessage("This field cannot be left blank.")
        }
    }
}
