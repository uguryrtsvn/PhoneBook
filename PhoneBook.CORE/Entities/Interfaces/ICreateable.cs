using PhoneBook.CORE.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.CORE.Interfaces
{
    public interface ICreateable
    {
        public string CreatorUserId { get; set; } 
        public DateTime CreatedDate { get; set; }
    }
}
