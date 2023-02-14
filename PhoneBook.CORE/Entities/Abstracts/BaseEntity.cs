using PhoneBook.CORE.Concretes;
using PhoneBook.CORE.Entities.Interfaces;
using PhoneBook.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.CORE.Abstracts
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public string ModifierUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DeletoryUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
