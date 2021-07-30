using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DItest.Managers
{
	public class AuthManager
	{
        public interface IAuthManager
        {
            Task<Microsoft.AspNetCore.Identity.IdentityUser> FindByIdAsync(string id); // Get user id:
        }

        //public class testdI : IAuthManager
        //{
        //	// здесь должна быть импементация FindByIdAsync(string id) из UserManager<Data.CustomIdentityUser> но впихнуть не впихуемое не получается
        //	public Task<CustomIdentityUser> FindByIdAsync(string id)
        //	{
        //		throw new NotImplementedException();
        //	}
        //}

        public class AuthManager : IAuthManager
        {
            private IAuthManager _iauthManager;

            public AuthManager(IAuthManager iauthManager)
            {
                this._iauthManager = iauthManager; //тут мы получаем налл
            }

            public Task<Microsoft.AspNetCore.Identity.IdentityUser> FindByIdAsync(string id)
            {
                var result = _iauthManager.FindByIdAsync(id);
                return result;
            }
        }
    }
}
