using PhoneBook.CORE.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.CORE.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.EntityConfigurations
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasOne(x => x.CreatorUser).WithOne(x => x.Book); 
            builder.HasMany(x => x.PhoneInfos).WithOne(x =>x.Book).HasForeignKey(x => x.BookId);

        }
    }
}
