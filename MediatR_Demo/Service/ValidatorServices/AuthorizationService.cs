using System.Threading.Tasks;

namespace Service.ValidatorServices
{
    internal class AuthorizationService : IAuthorizationService
    {
        public bool IsUserAuthorizedForAction()
        {
            return true;
        }
    }
}
