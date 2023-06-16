using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Core.Entities
{
    public class District : BaseEntity
    {
        public string DistrictAddress { get; set; }



        //Navigations
        public int LocationId { get; set; }
        public Location Locations { get; set; }
    }
}
