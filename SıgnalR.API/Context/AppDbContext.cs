using Microsoft.EntityFrameworkCore;
using SıgnalR.API.Models;

namespace SıgnalR.API.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Covid> Covids { get; set; }
    }
}
