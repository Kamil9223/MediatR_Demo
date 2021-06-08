using Dto.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.NotificationHandlers.Product
{
    internal class SampleNotificationHandler : INotificationHandler<NotifyRequest>
    {
        public Task Handle(NotifyRequest notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Notification!!!!");

            return Task.CompletedTask;
        }
    }
}
