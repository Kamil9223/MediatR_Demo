using Dto;
using MediatR;
using Service.ValidatorServices;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.ServicePipes
{
    internal class AuthorizationPipe<Tin, Tout> : IPipelineBehavior<Tin, Tout>
        where Tin : ICommand
    {
        private readonly IAuthorizationService _authorizarionService;

        public AuthorizationPipe(IAuthorizationService authorizarionService)
        {
            _authorizarionService = authorizarionService;
        }

        public Task<Tout> Handle(Tin request, CancellationToken cancellationToken, RequestHandlerDelegate<Tout> next)
        {
            if (!_authorizarionService.IsUserAuthorizedForAction())
            {
                throw new Exception("Authorizartio Failed!");
            }

            return next();
        }
    }
}
