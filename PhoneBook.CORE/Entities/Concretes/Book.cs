using PhoneBook.CORE.Abstracts;
using PhoneBook.CORE.Concretes;
using PhoneBook.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable
namespace PhoneBook.CORE.Entities.Concretes
{
    public class Book : BaseEntity, ICreateable, IEditable, IDeleteable
    {
        public Book()
        {
            PhoneInfos = new HashSet<PhoneInfo>();
            Id = Guid.NewGuid();
        }

        public ICollection<PhoneInfo> PhoneInfos { get; set; }
        public string CreatorUserId { get; set; }
        public AppUser CreatorUser { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
