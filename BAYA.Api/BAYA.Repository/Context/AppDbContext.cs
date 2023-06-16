using BAYA.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYA.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
               
        }


        public DbSet<AidNotice> AidNotices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Debris> Debrises { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<HelpCenter> HelpCenters { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<SubClothesCategory> SubClothesCategories { get; set; }
        public DbSet<SubShelterCategory> SubShelterCategories { get; set; }
        public DbSet<SubHealthCategory> SubHealthCategories { get; set; }
        public DbSet<SubSupplyCategory> SubSupplyCategories { get; set; }
    }
}
