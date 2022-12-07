using Convey.CQRS.Events;
using System;
using System.Threading.Tasks;

namespace Pacco.Services.Availability.Application.Events.External.Handlers
{
    internal sealed class CustomerCreatedHandler : IEventHandler<CustomerCreated>
    {
        public async Task HandleAsync(CustomerCreated @event)
            => await Task.CompletedTask;
        
    }
}
