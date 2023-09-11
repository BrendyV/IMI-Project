using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Api.Interfaces
{
    public interface IApiLoginService
    {
        //Task<User> GetLoginUser();
        //void SetLoginUser(User user);
        //Task<Guid> GetLoginUserId();
        //Task<string> GetLoginUserToken();
        //Task<string[]> GetLoginUserRole();
        Task<bool> Login(string email, string password);
        void Logout();
    }
}
