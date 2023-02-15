using FluentValidation;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Models.FluentValidators
{
    public class RegisterVMValidator : AbstractValidator<RegisterVM>
    {
        public RegisterVMValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen email alanını doldurunuz.").EmailAddress().WithMessage("Lütfen geçerli bir email adresi girin.");
            //RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen kullanıcı adı alanını doldurunuz.");
            //RuleFor(x => x.FirstName).NotEmpty().WithMessage("Lütfen isim alanını doldurunuz.");
            //RuleFor(x => x.LastName).NotEmpty().WithMessage("Lütfen soyisim alanını doldurunuz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifre alanını doldurunuz.");
        }
    }
}

