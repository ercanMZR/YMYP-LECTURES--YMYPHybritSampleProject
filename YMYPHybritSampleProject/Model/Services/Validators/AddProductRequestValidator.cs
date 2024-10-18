using FluentValidation;
using YMYPHybritSampleProject.Model.Services.Dto;

namespace YMYPHybritSampleProject.Model.Services.Validators
{
    public class AddProductRequestValidator:AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator() 
        {
            //Fluent Apı 
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.Stock).GreaterThan(0).WithMessage("Stock must be greater than 0");
        }

    }
}
