﻿using AutoMapper;
using BAYA.Core.DTOs;
using BAYA.Core.Entities;
using BAYA.Core.Services;
using BAYA.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAYA.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AidNoticeController : ControllerBase
    {
        private readonly IAidNoticeService _aidNoticeService;
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AidNoticeController(IAidNoticeService aidNoticeService, AppDbContext _appDbContext, IMapper mapper)
        {
            _aidNoticeService = aidNoticeService;
            this._appDbContext = _appDbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAidNotices()
        {
            var values = await _aidNoticeService.GetAidNoticesListWithCategoryCounty();
            return Ok(values);
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
    }
}