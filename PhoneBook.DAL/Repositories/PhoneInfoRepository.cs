using PhoneBook.CORE.Concretes;
using PhoneBook.CORE.Entities.Concretes;
using PhoneBook.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Repositories
{
    public class PhoneInfoRepository : BaseRepository<PhoneInfo>, IPhoneInfoRepository
    {
        public PhoneInfoRepository(AppDbContext db) : base(db)
        {
        }
    }
}
