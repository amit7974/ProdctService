using CrudFullstack.Model;
using Microsoft.EntityFrameworkCore;
using CrudFullstack.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;

namespace CrudFullstack.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Register models with the DbContext
        }
        public DbSet<Product> Products {  get; set; }
    }

        }
    

