using Activity.DTO;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Validations.Validators
{
    public class CreateBlogRequestValidation : AbstractValidator<CreateBlogRequestDto>
    {
        public CreateBlogRequestValidation()
        {

            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required");
        }
    }
}
