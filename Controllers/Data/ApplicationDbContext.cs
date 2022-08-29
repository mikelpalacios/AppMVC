using Microsoft.EntityFrameworkCore;
using AppMVC.Models;

namespace AppMVC.Controllers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Login> Login { get; set; }
    }
}
