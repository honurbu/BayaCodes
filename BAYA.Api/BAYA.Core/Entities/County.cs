using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Core.Entities
{
    public class County : BaseEntity
    {
        public string CountyAddress { get; set; }



        //Navigations
        public int LocationId { get; set; }
        public Location Locations { get; set; }
    }
}
