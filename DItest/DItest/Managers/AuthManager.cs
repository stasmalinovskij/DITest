using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DItest.Managers
{
    public interface IAuthManager
    {
        Task<IdentityUser> FindByIdAsync(string id); // Get user id:
    }

    public class AuthManager : IAuthManager
    {
        private UserManager<IdentityUser> _iauthManager;

        public AuthManager(UserManager<IdentityUser> iauthManager)
        {
            this._iauthManager = iauthManager; //тут мы получаем налл
        }

        public Task<IdentityUser> FindByIdAsync(string id)
        {
            var result = _iauthManager.FindByIdAsync(id);
            return result;
        }
    }
}
