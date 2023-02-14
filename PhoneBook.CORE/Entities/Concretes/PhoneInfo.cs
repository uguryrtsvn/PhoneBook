using PhoneBook.CORE.Abstracts;
using PhoneBook.CORE.Concretes;
using PhoneBook.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace PhoneBook.CORE.Entities.Concretes
{
    public class PhoneInfo : BaseEntity, ICreateable,IEditable,IDeleteable
    {
        public PhoneInfo()
        {
            Id = new Guid();
        }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
