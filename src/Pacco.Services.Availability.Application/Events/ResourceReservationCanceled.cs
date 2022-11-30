﻿using Convey.CQRS.Events;
using System;

namespace Pacco.Services.Availability.Application.Events
{
    [Contract]
    public class ResourceReservationCanceled : IEvent
    {
        public Guid ResourceId { get; }
        public DateTime DateTime { get; }

        public ResourceReservationCanceled(Guid resourceId, DateTime dateTime)
        {
            ResourceId = resourceId;
            DateTime = dateTime;
        }

    }
}
