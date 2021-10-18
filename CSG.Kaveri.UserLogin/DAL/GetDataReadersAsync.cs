using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSG.Kaveri.CommonLibrary.KaveriDataAccess;
using CSG.Kaveri.UserLoginAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CSG.Kaveri.UserLoginAPI.DAL
{
    public class GetDataReadersAsync : IGetDataReadersAsync
    {
        private readonly ILogger _logger;
        private IDataAccess _data;
        private readonly IConfiguration _configuration;
        private readonly IGetDataReadersAsync _getDataReadersAsync;
        public string myConnectionString = string.Empty;

        public GetDataReadersAsync(ILoggerFactory logger,IDataAccess data, IConfiguration configuration)
        {
            _data = data;
            _logger = logger.CreateLogger("GetDataReaders");
            _configuration = configuration;
            myConnectionString = _configuration["ConnectionStrings:DBConnectionStringCSGDEV"];
        }
        public async Task<List<UserLoginResponse>> GetUserLoginDataAsync(UserLoginRequest userLoginRequest)
        {
            var sqlGetSearchKaveriData = _configuration["Queries:GetUserLoginData"];
            UserLoginResponse objResp = new UserLoginResponse();
            try
            {
                _logger.LogInformation("GetUserLoginDataAsync called.......");
                //objResp = _data.LoadSingleRecord<UserLoginResponse, U>(sqlGetSearchKaveriData, Parameters, myConnectionString);

                return await _data.LoadData<UserLoginResponse, dynamic>(sqlGetSearchKaveriData, new { userLoginRequest.loginname, userLoginRequest.password }, myConnectionString);

               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString()+ex.StackTrace.ToString());
                return null;
            }
        }
    }
}