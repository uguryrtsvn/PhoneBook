using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Validators
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName) => new IdentityError { Code = "DuplicateUserName", Description = $"\"{ userName }\" kullanıcı adı kullanılmaktadır." };

        public override IdentityError InvalidUserName(string userName) => new IdentityError { Code = "InvalidUserName", Description = "Geçersiz kullanıcı adı." };

        public override IdentityError DuplicateEmail(string email) => new IdentityError { Code = "DuplicateEmail", Description = $"\"{ email }\" başka bir kullanıcı tarafından kullanılmaktadır." };

        public override IdentityError InvalidEmail(string email) => new IdentityError { Code = "InvalidEmail", Description = "Geçersiz email." };

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError { Code = "PasswordTooShort", Description = "Şifreniz çok kısa" };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError { Code = "PasswordRequiresDigit", Description = "Şifreniz en az 1 sayı içermelidir." };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError { Code = "PasswordRequiresLower", Description = "Şifreniz en az 1 küçük harf içermelidir." };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError { Code = "PasswordRequiresUpper", Description = "Şifreniz en az 1 büyük harf içermelidir." };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError { Code = "PasswordRequiresNonAlphanumeric", Description = "Şifreniz en az 1 özel karakter içermelidir." };
        }
    }
}
