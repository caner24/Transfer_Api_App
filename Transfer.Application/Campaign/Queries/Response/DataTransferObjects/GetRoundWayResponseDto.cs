using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Application.Campaign.Queries.Response.DataTransferObjects
{
    public record class GetRoundWayResponseDto : GetOneWayResponseDto
    {
        public DateTime ReturnDate { get; init; }
    }
}
