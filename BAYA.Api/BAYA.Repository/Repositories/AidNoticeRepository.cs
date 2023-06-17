using BAYA.Core.Entities;
using BAYA.Core.Repositories;
using BAYA.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Repository.Repositories
{
    public class AidNoticeRepository : GenericRepository<AidNotice>, IAidNoticeRepository
    {
        public AidNoticeRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<List<AidNotice>> GetAidNoticesById(int categoryid, int countyid)
        {
            return await _context.AidNotices
                .Include(x => x.Categories)
                .Include(x => x.Counties)
                .Include(x=>x.Streets).Include(x=>x.Districts)
                .Where(x => x.CategoryId == categoryid && x.CountyId == countyid).ToListAsync();
        }

        public async Task<List<AidNotice>> GetAidNoticesListWithCategoryCounty()
        {
            return await _context.AidNotices
                .Include(x => x.Categories)
                
                .Include(x => x.Counties).Include(x => x.Streets).Include(x => x.Districts)
                .ToListAsync();

        }

        public async Task<List<AidNotice>> GetAidNoticesListWithCategoryCounty(int id)
        {
            return await _context.AidNotices
                .Include(x => x.Categories)
                .Include(x => x.Counties).Include(x => x.Streets).Include(x => x.Districts)
                .Where(x => x.Id == id)
                .ToListAsync();
        }

        public int GetCount(int categoryid)
        {

            return _context.AidNotices.Include(x => x.Categories).Count(x => x.CategoryId == categoryid);

        }

        public int GetCountyCount(int countyId)
        {
            return _context.AidNotices.Include(x => x.Counties).Count(x => x.CountyId == countyId);
        }

        public int GetCountWithCountyDistrict(int countyId, int disticntid)
        {
            return _context.AidNotices.Include(x => x.Counties).Include(x=>x.Districts).Count(x => x.CountyId == countyId && x.DistrictId == disticntid);
        }

        public int GetCountWithCountyDistrictStreet(int countyId, int disticntid, int streetid)
        {
            return _context.AidNotices.Include(x => x.Counties).Include(x => x.Districts).Include(x=>x.Streets).Count(x => x.CountyId == countyId && x.DistrictId == disticntid  && x.StreetId == streetid);
        }
    }
}

