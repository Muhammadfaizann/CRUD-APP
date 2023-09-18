using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Services.UserServices;

namespace ServerApplication.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper autoMapper;

        public UserController(DataBaseContext context, IMapper AutoMapper)
        {
            userService = new UserService(context);
            autoMapper = AutoMapper;
        }
        [HttpGet]
        [Route("api/User/Login/{username}/{password}")]
        public string Login(string username,string password)
        {
            return userService.AuthenticateUser(username,password);
        }
    }
}
