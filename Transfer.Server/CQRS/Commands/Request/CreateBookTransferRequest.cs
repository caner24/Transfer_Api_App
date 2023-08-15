using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Client.Request;
using Transfer.Client.Response;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Server.CQRS.Commands.Request
{
    public class CreateBookTransferRequest : IRequest<TransferServiceSearchResponse>
    {
        
        public class Root
        {
            public List<string> VehicleIds { get; set; }
            public int Adults { get; set; }
            public int UserID { get; set; }
            public int Children { get; set; }
            public List<Tag> Tags { get; set; }
        }

        public class Tag
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}
