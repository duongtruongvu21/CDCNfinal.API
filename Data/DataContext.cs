using CDCNfinal.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CDCNfinal.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}