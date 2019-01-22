using Microsoft.EntityFrameworkCore;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        /// <summary>
        /// Options include connections strings, which we will pass through existing class DbContextOptions
        /// Take these options and pass them along to DbContext constructor, and base class will take care of looking at those options
        /// and setup the proper database connections
        /// </summary>
        /// <param name="options"></param>
        public OdeToFoodDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
