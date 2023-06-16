using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Core.Entities
{
    public class AidNotice : BaseEntity
    {

        public string? Name { get; set; }

        //Navigations
        public int CategoryId { get; set; }
        public Category Categories { get; set; }  
        
        
        public int CountyId { get; set; }
        public County  Counties { get; set; }
    }
}
