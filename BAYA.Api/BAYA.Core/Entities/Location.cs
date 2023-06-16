using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Core.Entities
{
    public class Location:BaseEntity
    {








        //Navigations


        public ICollection<County> Counties { get; set; }
        public ICollection<District> Districts { get; set; }
        public ICollection<Street> Streets { get; set; }
        public ICollection<Debris> Debrises { get; set; }
        public ICollection<AidNotice> AidNotices { get; set; }


    }
}
