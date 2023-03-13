using Microsoft.EntityFrameworkCore;
using ZooManagement.Models;

namespace ZooManagement
{
    public class ZooManagementDbContext : DbContext
    {
        public ZooManagementDbContext(DbContextOptions<ZooManagementDbContext> options) : base(options) { }

        public DbSet<AnimalDetail> Animal { get; set; }
        public DbSet<AnimalType> AnimalType { get; set; }

    }
}