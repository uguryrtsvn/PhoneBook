 
using PhoneBook.BLL.Abstracts; 
using PhoneBook.CORE.Concretes;
using PhoneBook.CORE.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.CORE.Entities.Concretes;

namespace PhoneBook.BLL.Concretes
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository; 

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository; 
        }

        public async Task<bool> ActiveBookAsync(Guid id)
        {
            Book book = await bookRepository.GetWhere(a => a.Id == id);
            book.IsActive = true;
            return await bookRepository.UpdateAsync(book);
        }

        public async Task<bool> CreateAsync(Book mdl)
        {  
            return await bookRepository.CreateAsync(mdl);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Book book = await bookRepository.GetWhere(a => a.Id == id);
            return await bookRepository.DeleteAsync(book);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            List<Book> list = await bookRepository.GetFilteredList(
                selector: x => new Book
                {
                    Id = x.Id, 
                    PhoneInfos = x.PhoneInfos,
                    CreatedDate = x.CreatedDate,
                    ModifiedDate = x.ModifiedDate,
                    CreatorUser = x.CreatorUser,
                    CreatorUserId = x.CreatorUserId,
                    IsActive = x.IsActive,
                    ModifierUserId = x.ModifierUserId
                },
                includes: x => x.Include(c => c.PhoneInfos),
                expression: x => x.IsActive == true
                );
            return list;
        }

        public async Task<List<Book>> GetAllPassivesAsync()
        {
            List<Book> list = await bookRepository.GetFilteredList(
                selector: x => new Book
                {
                    Id = x.Id,
                    PhoneInfos = x.PhoneInfos,
                    CreatedDate = x.CreatedDate,
                    ModifiedDate = x.ModifiedDate,
                    CreatorUser = x.CreatorUser,
                    CreatorUserId = x.CreatorUserId,
                    IsActive = x.IsActive,
                    ModifierUserId = x.ModifierUserId
                },
                includes: x => x.Include(c => c.PhoneInfos),
                expression: x => x.IsActive == false
                );
            return list;
        } 
        public async Task<Book> GetByIdAsync(Guid id)
        {
            Book book = await bookRepository.GetFilteredFirstOrDefault(
                selector: x => new Book
                {
                    Id = x.Id,
                    PhoneInfos = x.PhoneInfos,
                    CreatedDate = x.CreatedDate,
                    ModifiedDate = x.ModifiedDate,
                    CreatorUser = x.CreatorUser,
                    CreatorUserId = x.CreatorUserId,
                    IsActive = x.IsActive,
                    ModifierUserId = x.ModifierUserId
                },
                includes: x => x.Include(c => c.PhoneInfos),
                expression: x => x.Id == id
                );
            return book;
        }
          
        public async Task<bool> UpdateAsync(Book mdl)
        { 
            return await bookRepository.UpdateAsync(mdl);
        }
    }
}
