using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Application.Exceptions
{
    public class CustomerNotFoundException : AppException
    {
        public Guid CustomerId { get; }

        public CustomerNotFoundException(Guid customerId) : base($"Customer with ID: '{customerId} was not found")
        {
            CustomerId = customerId;
        }

    }
}
