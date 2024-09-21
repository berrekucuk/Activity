using Activity.DTO;
using Activity.Validations.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Activity.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<CreateCategoryRequestDto>, CreateCategoryRequestValidation>();
            services.AddScoped<IValidator<CreateBlogRequestDto>, CreateBlogRequestValidation>();
            services.AddScoped<IValidator<CreateActivityRequestDto>, CreateActivityRequestValidation>();
            return services;
        }
    }
}
