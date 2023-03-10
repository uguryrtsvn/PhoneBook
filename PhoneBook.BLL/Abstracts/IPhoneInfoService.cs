using PhoneBook.CORE.Concretes;
using PhoneBook.CORE.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Abstracts
{
    public interface IPhoneInfoService
    {
        Task<bool> CreateAsync(PhoneInfo mdl);
        Task<List<PhoneInfo>> GetAllAsync();
        Task<List<PhoneInfo>> GetAllPassivesAsync();
        Task<PhoneInfo> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(PhoneInfo mdl);
        Task<bool> DeleteAsync(Guid id); 
    }
}
