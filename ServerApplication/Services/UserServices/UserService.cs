
using ServerApplication.Models.UserModels;

namespace ServerApplication.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DataBaseContext _Context;
        public UserService(DataBaseContext _context)
        {
            _Context = _context;
        }

        public string AuthenticateUser(string username,string password)
        {
            try
            {
                User user = _Context.Users.First(x => x.Username == username && x.Password == password);
                if (user != null)
                {
                    return user.Token;
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        
    }
}
