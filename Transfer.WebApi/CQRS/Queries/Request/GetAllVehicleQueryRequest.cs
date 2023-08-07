using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.WebApi.CQRS.Queries.Response;

namespace Transfer.WebApi.CQRS.Queries.Request
{
    public class GetAllVehicleQueryRequest : IRequest<List<GetAllVehicleQueryResponse>>
    {

    }
}
