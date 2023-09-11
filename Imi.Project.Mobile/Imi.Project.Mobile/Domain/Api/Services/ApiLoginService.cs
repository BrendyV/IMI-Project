using Imi.Project.Mobile.Domain.Api.Interfaces;
using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Api.Services
{
    public class ApiLoginService : IApiLoginService
    {
        private User LoginUser;
        private string Token;
        private string[] Roles;
        private Guid Id;

        public ApiLoginService()
        {

        }

        public void Logout()
        {
            LoginUser = null; ;
            Token = "";
            Roles = null;
        }

        public void SetLoginUser(User user)
        {
            LoginUser = user;
        }

        public async Task<bool> Login(string email, string password)
        {
            var login = new Login { email = email, password = password };

            var response = await WebApiClient.PostCallApi<ApiLoginTokenAndRoles, Login>($"{Constants._baseUri}api/auths/login", login);

            if (response == null)
            {
                return false;
            }

            Id = response.Id;
            Roles = response.Roles;
            Token = response.Token;

            return true;
        }

        //public async Task<User> GetLoginUser()
        //{
        //    return await Task.FromResult(LoginUser);
        //}

        //public async Task<Guid> GetLoginUserId()
        //{
        //    return await Task.FromResult(Id);
        //}

        //public async Task<string[]> GetLoginUserRole()
        //{
        //    return await Task.FromResult(Roles);
        //}

        //public async Task<string> GetLoginUserToken()
        //{
        //    return await Task.FromResult(Token);
        //}
    }
}
