
namespace Store.WebUI.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticete(string userName, string userPassword);
    }
}
