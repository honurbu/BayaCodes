﻿using BAYA.Core.DTOs;
using BAYA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Core.Services
{
    public interface IHelpCenterService : IGenericService<HelpCenter>
    {
        Task<List<HelpCenter>> GetAllHelpCenters();
        Task<List<HelpCenter>> GetHelpCenterWithCategory(int id);


    }
}
