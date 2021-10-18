using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSG.Kaveri.UserLoginAPI.Models;

namespace CSG.Kaveri.UserLoginAPI.DAL
{
    public interface IGetDataReadersAsync
    {
        Task<List<UserLoginResponse>> GetUserLoginDataAsync(UserLoginRequest userLoginRequest);
    }
}