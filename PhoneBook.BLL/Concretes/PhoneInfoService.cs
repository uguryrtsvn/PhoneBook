
using PhoneBook.BLL.Abstracts;
using PhoneBook.CORE.Entities.Concretes;
using PhoneBook.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Concretes
{
    public class PhoneInfoService : IPhoneInfoService
    {
        private readonly IPhoneInfoRepository _phoneInfoRepo; 
        public PhoneInfoService(IPhoneInfoRepository phoneInfoRepository)
        {
            _phoneInfoRepo = phoneInfoRepository; 
        } 
        public async Task<bool> CreateAsync(PhoneInfo mdl)
        { 
            return await _phoneInfoRepo.CreateAsync(mdl);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            PhoneInfo mdl = await _phoneInfoRepo.GetWhere(a => a.Id == id);
            return await _phoneInfoRepo.DeleteAsync(mdl);
        }

        public async Task<List<PhoneInfo>> GetAllAsync()
        {
            List<PhoneInfo> list = await _phoneInfoRepo.GetAllWhere(z=>z.IsActive == true); 
            return list;
        }

        public async Task<List<PhoneInfo>> GetAllPassivesAsync()
        {
            List<PhoneInfo> list = await _phoneInfoRepo.GetAllWhere(z => z.IsActive == false);
            return list;
        }

        public async Task<PhoneInfo> GetByIdAsync(Guid id)
        {
            PhoneInfo mdl = await _phoneInfoRepo.GetFilteredFirstOrDefault(
                selector: x => new PhoneInfo
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    BookId = x.BookId,
                    Book = x.Book,
                    FullName = x.FullName,
                    CreatorUserId = x.CreatorUserId,
                    PhoneNumber = x.PhoneNumber,
                    IsActive = x.IsActive,
                    ModifiedDate = x.ModifiedDate,
                    DeletedDate = x.DeletedDate,
                    DeletoryUserId = x.DeletoryUserId,
                    ModifierUserId = x.ModifierUserId,
                },
                expression: x => x.Id == id
                );
            return mdl;
        }

        public async Task<bool> UpdateAsync(PhoneInfo mdl)
        { 
            return await _phoneInfoRepo.UpdateAsync(mdl);
        }
    }
}
