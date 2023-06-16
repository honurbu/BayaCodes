using AutoMapper;
using BAYA.Core.DTOs;
using BAYA.Core.Entities;
using BAYA.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAYA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpCenterController : ControllerBase
    {
        private readonly IHelpCenterService _helpCenterService;
        private readonly IMapper _mapper;

        public HelpCenterController(IHelpCenterService helpCenterService, IMapper mapper)
        {
            _helpCenterService = helpCenterService;
            _mapper = mapper;
        }



        [HttpPost]
        public async Task<IActionResult> AddHelpCenter(HelpCenterDto helpCenter)
        {
            var helpCenterDto = await _helpCenterService.AddAsync(_mapper.Map<HelpCenter>(helpCenter));
            return Ok(helpCenterDto);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteHelpCenter(int id)
        {
            var values = await _helpCenterService.GetByIdAsync(id);
            if (values == null)
                return NotFound("Belirtilen Id Bulunamadı !");
            await _helpCenterService.RemoveAsync(values);
            return Ok("Başarıyla silindi");
        }




        [HttpGet]
        public async Task<IActionResult> GetAllHelpCenter()
        {
            var values = await _helpCenterService.GetAllHelpCenters();
            return Ok(values);
        }
    }
}
