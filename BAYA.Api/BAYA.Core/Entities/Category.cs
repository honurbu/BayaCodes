using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Core.Entities
{
    public class Category : BaseEntity
    {
        public string  Name { get; set; }



        //Navigations
        public ICollection<SubClothesCategory> SubClothesCategories { get; set; }
        public ICollection<SubHealthCategory> SubHealthCategories { get; set; }
        public ICollection<SubShelterCategory> SubShelterCategories { get; set; }
        public ICollection<SubSupplyCategory> SubSupplyCategories { get; set; }

    }
}
