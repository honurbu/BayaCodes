using BAYA.Core.Entities;
using BAYA.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAYA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyController : ControllerBase
    {
        private readonly ICountyService _countyService;

        public CountyController(ICountyService countyService)
        {
            _countyService = countyService;
        }

        }
}
