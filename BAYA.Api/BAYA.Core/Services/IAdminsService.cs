﻿using BAYA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Core.Services
{
    public interface IAdminsService : IGenericService<Admins>
    {
        bool CompareAdminInfo(string username, string pass);

    }
}
