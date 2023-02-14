using PhoneBook.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.CORE.Entities.Interfaces
{
    public interface IBaseEntity : IEditable, IDeleteable
    {
        public bool IsActive { get; set; }
    }
}
