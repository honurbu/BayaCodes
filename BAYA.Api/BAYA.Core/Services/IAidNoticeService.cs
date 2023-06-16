﻿using BAYA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Core.Services
{
    public interface IAidNoticeService : IGenericService<AidNotice>
    {
        Task<List<AidNotice>> GetAidNoticesListWithCategoryCounty();
        Task<List<AidNotice>> GetAidNoticesById(int categoryid, int countyid);
        Task<List<AidNotice>> GetAidNoticesListWithCategoryCounty(int id);

        public int GetCount(int categoryid);
        public int GetCountyCount(int countyId);

    }
}
