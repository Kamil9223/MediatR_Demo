using System.Threading.Tasks;

namespace Service.ValidatorServices
{
    public interface IValidatorService
    {
        Task ValidateCommand(object command);
        Task ValidateQuery(object query);
    }
}
