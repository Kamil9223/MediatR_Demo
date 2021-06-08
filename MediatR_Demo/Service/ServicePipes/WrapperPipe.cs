using Common.Common;
using Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Service.ServicePipes
{
    internal class WrapperPipe<Tin, Tout> : IPipelineBehavior<Tin, Tout>
        where Tin : ICommand
    {
        private readonly Wrapper _wrapper;

        public WrapperPipe()
        {
            _wrapper = new Wrapper();
        }

        public Task<Tout> Handle(Tin request, CancellationToken cancellationToken, RequestHandlerDelegate<Tout> next)
        {
            return _wrapper.Wrap(() =>
            {
                return next();
            });
        }
    }
}
