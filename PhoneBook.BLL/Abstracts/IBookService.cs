using PhoneBook.CORE.Entities.Concretes;
using PhoneBook.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Abstracts
{
    public interface IBookService 
    {
        Task<List<Book>> GetAllAsync();
        Task<bool> ActiveBookAsync(Guid id);
        Task<bool> CreateAsync(Book mdl);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Book>> GetAllPassivesAsync();
        Task<Book> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Book mdl);
 
    }
}
