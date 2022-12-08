using Convey.HTTP;
using Pacco.Services.Availability.Application.DTO.External;
using Pacco.Services.Availability.Application.Services.Clients;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pacco.Services.Availability.Infrastructure.Services.Clients
{
    internal class CustomerServiceClient : ICustomerServiceClient
    {
        private readonly IHttpClient _client;
        private readonly string _url;

        public CustomerServiceClient(IHttpClient client, HttpClientOptions options)
        {
            _client = client;
            _url = options.Services["customers"];
        }

        public Task<CustomerStateDTO> GetStateAsync(Guid id)
            => _client.GetAsync<CustomerStateDTO>($"{_url}/customers/{id}/state");
    }
}
