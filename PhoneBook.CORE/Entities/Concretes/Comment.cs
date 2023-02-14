using PhoneBook.CORE.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.CORE.Concretes
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid ArticleId { get; set; }
        //public Article Article { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
