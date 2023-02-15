using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class RegisterVM
    {
        public string UserName { get; set; } = "a";
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; } = "a";
        public string Password { get; set; }
    }
}

