using Microsoft.EntityFrameworkCore;
using SwaggerDemo.Model;

namespace SwaggerDemo
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {

        }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public virtual DbSet<BUnit> BUnit { get; set; }
        public virtual DbSet<BatchIds> BatchId{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;username=postgres;password=123456;database=NewDemo");
        }

       
        }
}
