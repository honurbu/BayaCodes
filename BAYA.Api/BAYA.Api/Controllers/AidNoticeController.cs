using AutoMapper;
using BAYA.Core.DTOs;
using BAYA.Core.Entities;
using BAYA.Core.Services;
using BAYA.Core.UnitOfWorks;
using BAYA.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAYA.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AidNoticeController : ControllerBase
    {
        private readonly IAidNoticeService _aidNoticeService;
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AidNoticeController(IAidNoticeService aidNoticeService, AppDbContext _appDbContext, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _aidNoticeService = aidNoticeService;
            this._appDbContext = _appDbContext;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        [HttpGet("{categoryid}/{countyid}")]
        public async Task<IActionResult> GetListById(int categoryid, int countyid)
        {
            var values = await _aidNoticeService.GetAidNoticesById(categoryid, countyid);
            return Ok(values);
        }


        [HttpGet("{categoryid}")]
        public IActionResult GetCountByCategory(int categoryid)
        {

            var values = _aidNoticeService.GetCount(categoryid);
            return Ok(values);
        }


        [HttpGet("{countyId}")]
        public IActionResult GetCounty(int countyId)
        {
            var values = _aidNoticeService.GetCountyCount(countyId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddAidNotice(AidNoticeDto aitNotice)
        {
            var values = await _aidNoticeService.AddAsync(_mapper.Map<AidNotice>(aitNotice));
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAidNoticeById(int id)
        {
            var values = await _aidNoticeService.GetAidNoticesListWithCategoryCounty(id);
            return Ok(values);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAidNotice(int id)
        {
            var values = await _aidNoticeService.GetByIdAsync(id);
            await _aidNoticeService.RemoveAsync(values);
            return Ok("Başarıyla silindi");
        }


        [HttpGet("{countyid}/{districtid}")]
        public IActionResult Control(int countyid, int districtid)
        {
            var values = _aidNoticeService.GetCountWithCountyDistrict(countyid, districtid);
            return Ok(values);
        }



        [HttpGet("{countyid}/{districtid}/{streetid}")]
        public IActionResult Control(int countyid, int districtid, int streetid)
        {
            var values = _aidNoticeService.GetCountWithCountyDistrictStreet(countyid, districtid, streetid);
            return Ok(values);
        }

        public class AddDTO
        {
            public string? county { get; set; }
            public string? districts { get; set; }
            public string? street { get; set; }

            public string? categoryname { get; set; }

            public string? subcategoryname { get; set; }
        }

        [HttpPost]
        public IActionResult AddDataAitNotion([FromBody] AddDTO dto)
        {
            SaveRelatedRecord(dto.county, dto.districts, dto.street, dto.categoryname, dto.subcategoryname);
            return Ok("Success");
        }

        [NonAction]
        public void SaveRelatedRecord(string county, string district, string street, string? categoryname, string? subcategoryname)
        {
            try
            {
                // İlgili tabloyu ve string değerin kontrol edilmesi
                var existCounty = _appDbContext.Counties.FirstOrDefault(r => r.CountyAddress == county);
                var existngDistrict = _appDbContext.Districts.FirstOrDefault(r => r.DistrictAddress == district);
                var existngStreet = _appDbContext.Streets.FirstOrDefault(r => r.StreetAddress == street);
                var existingCategory = categoryname != null ? _appDbContext.Categories.FirstOrDefault(r => r.Name == categoryname) : null;
                var existingSubcategory = subcategoryname != null ? _appDbContext.SubCategories.FirstOrDefault(r => r.Name == subcategoryname) : null;

                // Var olan kayıt varsa ilişkili tabloya ID'yi kaydetme
                var relatedRecord = new AidNotice
                {
                    CountyId = existCounty.Id,
                    DistrictId = existngDistrict.Id,
                    StreetId = existngStreet.Id,
                    CategoryId = existingCategory != null ? existingCategory.Id : null,
                    SubCategoryId = existingSubcategory != null ? existingSubcategory.Id : null
                };

                _appDbContext.AidNotices.Add(relatedRecord);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // Hata ayrıntılarını yakala
                Console.WriteLine(ex.Message);
                throw;
            }
        }


    }
}

