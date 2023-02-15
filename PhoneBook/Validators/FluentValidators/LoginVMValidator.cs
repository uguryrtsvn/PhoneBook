using FluentValidation; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Models.FluentValidators
{
    public class LoginVMValidator : AbstractValidator<LoginVM>
    {
        public LoginVMValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen email alanını doldurunuz.").EmailAddress().WithMessage("Lütfen geçerli bir email adresi girin.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifre alanını doldurunuz.");
        }
    }
}

