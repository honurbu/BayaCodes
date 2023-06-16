using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Core.Entities
{
    public class Debris : BaseEntity
    {





        //Navigations
        public int LocationId { get; set; }
        public Location Locations { get; set; }
    }
}
