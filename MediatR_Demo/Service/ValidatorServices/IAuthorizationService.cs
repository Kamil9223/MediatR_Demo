using System.Threading.Tasks;

namespace Service.ValidatorServices
{
    public interface IAuthorizationService
    {
        bool IsUserAuthorizedForAction();
    }
}
