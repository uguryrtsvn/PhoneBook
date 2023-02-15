using PhoneBook.CORE.Entities.Interfaces;
using PhoneBook.CORE.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.CORE.Entities.Concretes;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace PhoneBook.CORE.Entities.Concretes
{
    public class AppUser : IdentityUser, IBaseEntity
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Adress { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [NotMapped]
        public Book Book { get; set; }  
        public string ModifierUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DeletoryUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
