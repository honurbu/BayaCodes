﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Core.Entities
{
    public class AidNotice : BaseEntity
    {
       
        //Navigations
        public int CategoryId { get; set; }
        public Category Categories { get; set; }  
        
        
        public int LocationId { get; set; }
        public Location Locations { get; set; }
    }
}
