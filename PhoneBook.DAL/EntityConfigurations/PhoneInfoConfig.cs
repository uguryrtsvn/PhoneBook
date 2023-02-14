using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.CORE.Entities.Concretes;

namespace PhoneBook.DAL.EntityConfigurations
{
    public class PhoneInfoConfig : IEntityTypeConfiguration<PhoneInfo>
    {
        public void Configure(EntityTypeBuilder<PhoneInfo> builder)
        {
            builder.HasOne(x => x.Book).WithMany(x => x.PhoneInfos).HasForeignKey(x => x.BookId);  
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.PhoneNumber).IsRequired();   
        }
    }
}
