using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSG.Kaveri.UserLoginAPI.DAL;
using CSG.Kaveri.UserLoginAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CSG.Kaveri.UserLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IGetDataReadersAsync _getDataReadersAsync;
        private readonly IConfiguration _configuration;
        private int parameter;

        public UserLoginController(IConfiguration configuration,ILoggerFactory logger, IGetDataReadersAsync getDataReadersAsync)
        {
            _logger = logger.CreateLogger("UserLoginController");
            _configuration = configuration;
            _getDataReadersAsync = getDataReadersAsync;
        }

        [Route("LoginData")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<UserLoginResponse>> GetUserLoginData([FromBody] UserLoginRequest userLoginRequest)
        {
            UserLoginResponse userLoginResponse = new UserLoginResponse();
            List<UserLoginResponse> listUserLoginResponse = new List<UserLoginResponse>();
            try
            {
                _logger.LogInformation("GetUserLoginData called.......");
                listUserLoginResponse = await _getDataReadersAsync.GetUserLoginDataAsync(userLoginRequest);

                if (listUserLoginResponse.Count > 0)
                {
                    listUserLoginResponse[0].responseCode = Convert.ToInt32(_configuration["ResponsesCodes:SuccessCode"]); ;
                    listUserLoginResponse[0].responseMessage = _configuration["Responses:SuccessMessage"];
                }
                else
                {
                    userLoginResponse.responseCode = Convert.ToInt32(_configuration["ResponsesCodes:FailureCode"]);
                    userLoginResponse.responseMessage = _configuration["Responses:FailMessage"];
                    listUserLoginResponse.Add(userLoginResponse);
                }
                return listUserLoginResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString() + ex.StackTrace.ToString());
                return null;
            }
        }
    }
}