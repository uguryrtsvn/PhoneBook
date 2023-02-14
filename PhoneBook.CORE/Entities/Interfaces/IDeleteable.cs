using PhoneBook.CORE.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.CORE.Interfaces
{
    public interface IDeleteable
    {
        public string DeletoryUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
