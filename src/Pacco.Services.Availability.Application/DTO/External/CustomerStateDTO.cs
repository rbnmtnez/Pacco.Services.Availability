using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Application.DTO.External
{
    public class CustomerStateDTO
    {
        public string State { get; set; }
        public bool IsValid => State.Equals("valid", StringComparison.OrdinalIgnoreCase);
    }
}
