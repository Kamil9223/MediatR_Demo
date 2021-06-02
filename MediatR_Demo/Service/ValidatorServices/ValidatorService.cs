using System.Threading.Tasks;

namespace Service.ValidatorServices
{
    internal class ValidatorService : IValidatorService
    {
        public Task ValidateCommand(object command)
        {
            return Task.CompletedTask;
        }

        public Task ValidateQuery(object query)
        {
            return Task.CompletedTask;
        }
    }
}
