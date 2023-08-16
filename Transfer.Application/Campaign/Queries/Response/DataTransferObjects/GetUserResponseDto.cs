using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Entity;

namespace Transfer.Application.Campaign.Queries.Response.DataTransferObjects
{
    public  class GetUserResponseDto
    {
        public List<User> User { get; init; }
    }
}
