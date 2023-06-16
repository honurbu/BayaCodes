using BAYA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Core.DTOs
{
    public class AidNoticeDto : BaseDto
    {
        public string? Name { get; set; }

        //Navigations
        public int CategoryId { get; set; }

        public int CountyId { get; set; }
    }
}
