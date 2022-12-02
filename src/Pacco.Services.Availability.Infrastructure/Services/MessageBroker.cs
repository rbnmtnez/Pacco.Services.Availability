using System.Collections.Generic;
using System;
using Pacco.Services.Availability.Application.Services;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using System.Linq;
using Microsoft.Extensions.Logging;
using Convey;
using Convey.MessageBrokers.Outbox;

namespace Pacco.Services.Availability.Infrastructure.Services
{
    internal sealed class MessageBroker : IMessageBroker
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IMessageOutbox _outbox;
        private readonly ILogger<MessageBroker> _logger;

        public MessageBroker(IBusPublisher busPublisher, IMessageOutbox outbox, ILogger<MessageBroker> logger)
        {
            _busPublisher = busPublisher;
            _outbox = outbox;
            _logger = logger;
        }

        public Task PublishAsync(params IEvent[] events) => PublishAsync(events?.AsEnumerable());

        public async Task PublishAsync(IEnumerable<IEvent> events)
        {
            if (events is null)
                return;

            foreach (var @event in events)
            {
                if (@event is null)
                {
                    continue;
                }

                var messageId = Guid.NewGuid().ToString("N");
                _logger.LogTrace($"Publishing an integration event: '{@event.GetType().Name.Underscore()}' +" +
                    $"with ID: '{messageId}'");

                if (_outbox.Enabled)
                {
                    await _outbox.SendAsync(@event, messageId: messageId);
                    continue;
                }
                await _busPublisher.PublishAsync(@event, messageId);
            }
        }
    }
}
