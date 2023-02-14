using PhoneBook.CORE.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.CORE.Interfaces
{
    public interface IEditable
    {
        public string ModifierUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
