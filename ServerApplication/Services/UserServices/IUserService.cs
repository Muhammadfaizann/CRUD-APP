using ServerApplication.Models.UserModels;

namespace ServerApplication.Services.UserServices
{
    public interface IUserService
    {
        string AuthenticateUser(string username,string password);
    }
}
