using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Repository.IoC;
using Service.ServicePipes;
using Service.ValidatorServices;
using System.Reflection;

namespace Service.IoC
{
    public static class ServiceModule
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddRepository();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Pipes will be executing top to bootom
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AuthorizationPipe<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(WrapperPipe<,>));

            services.AddScoped<IValidatorService, ValidatorService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();

            return services;
        }
    }
}
