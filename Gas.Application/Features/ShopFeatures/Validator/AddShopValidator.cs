using FluentValidation;
using Gas.Model.CompanyManagement;

namespace Gas.Application.Features.ShopFeatures.Validator
{
    public class AddShopValidator:AbstractValidator<AddShopModel>
    {
        public AddShopValidator()
        {

            RuleFor(x => x.Shopname).NotEmpty().WithMessage("Shop Name cannot be null or empty");
            RuleFor(x => x.Commonstreet).NotEmpty().WithMessage("Shop Street cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Shop Street cannot be zero or less than zero");
            RuleFor(x => x.Superdealer).NotEmpty().WithMessage("Super Delear cannot be null or empty")
                    .Must(BeValidNumber).WithMessage("Super Delear cannot be zero or less than zero");
            RuleFor(x => x.Phonenumber).NotEmpty()
               .Must(BeValidPhone).WithMessage("PhoneNumber is not valid")
               .When(model => !string.IsNullOrEmpty(model.Phonenumber));
        }

        private bool BeValidNumber(int? number)
        {
            return number > 0;
        }

        private bool BeValidPhone(string phone)
        {
            return Helper.IsPhoneNumberValid(phone);
        }

    }
}
