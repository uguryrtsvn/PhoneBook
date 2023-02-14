using PhoneBook.CORE.Concretes;
using PhoneBook.CORE.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.CORE.Entities.Concretes;

namespace PhoneBook.DAL.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly AppDbContext db;

        public BookRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<Book> GetWhereIncludePhoneInfos(Expression<Func<Book, bool>> expression)
        {
            return await db.Set<Book>().Include(x => x.PhoneInfos).FirstOrDefaultAsync(expression);
        }
    }
}
