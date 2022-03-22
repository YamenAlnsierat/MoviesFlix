using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movieflix_api.Models;

namespace movieflix_api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Movie> Movies => Set<Movie>();
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    }
}