using Pacco.Services.Availability.Application.DTO.External;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pacco.Services.Availability.Application.Services.Clients
{
    public interface ICustomerServiceClient
    {
        Task<CustomerStateDTO> GetStateAsync(Guid id);
    }
}
