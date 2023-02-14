using PhoneBook.BLL.Abstracts;
using PhoneBook.CORE.IRepositories; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Concretes
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository; 
        public AppUserService(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository; 
        }
    }
}
