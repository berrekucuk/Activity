using Activity.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Validations
{
    public class CreateCategoryRequestValidation : AbstractValidator<CreateCategoryRequestDto>
    {
        public CreateCategoryRequestValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
