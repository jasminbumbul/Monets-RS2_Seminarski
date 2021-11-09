﻿using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Monets.Api.Interfaces
{
    public interface IMeniService : ICRUDService<Model.Meni,MeniSearchRequest,MeniUpsertRequest, MeniUpsertRequest>
    {
    }
}
