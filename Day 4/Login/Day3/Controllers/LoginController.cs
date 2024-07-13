using Bussiness_Logic_Layer;
using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//This is api for Login of user/admin

namespace Day3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public  BALLogin _balLogin;

        public LoginController(BALLogin balLogin)
        {
            _balLogin = balLogin;
        }

        ResposeResult result = new ResposeResult();
        [HttpPost]
        public ResposeResult LoginUser(User user)
        {
            try
            {
                result.Data = _balLogin.UserLogin(user);
                result.Result = ResponseStatus.Success;
            }
            catch(Exception ex)
                {
                result.Message = ex.Message;    
                result.Result = ResponseStatus.Error;
            }
            return result;  
        }
    }
}
