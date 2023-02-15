using PhoneBook.CORE.Concretes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.CORE.Entities.Concretes;

namespace PhoneBook.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        } 
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<PhoneInfo> PhoneInfos { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Mevcut katmandaki bütün IEntityTypeConfiguration interface'inden türeyen configurasyonları uygulaması için 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
