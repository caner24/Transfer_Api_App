﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Entity;
using Transfer.Server.Models;

namespace Transfer.Server.CQRS.Queries.Response
{
    public class GetUserResponse
    {
        public List<User> User { get; set; }
    }
}
