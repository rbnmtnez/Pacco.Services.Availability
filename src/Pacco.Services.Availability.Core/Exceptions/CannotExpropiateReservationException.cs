﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Core.Exceptions
{
    public class CannotExpropiateReservationException : DomainException
    {
        public Guid ResourceId { get;  }
        private readonly DateTime _dateTime;

        public CannotExpropiateReservationException(Guid resourceId, DateTime dateTime) 
            : base($"Cannot expropiate the resource with ID: '{resourceId} reservation at: {dateTime.Date}'")
        {
            ResourceId = resourceId;
            _dateTime = dateTime;
        }

    }
}
