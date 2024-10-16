using Core_Proje_Api.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_Api.DAL.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=CoreProjeDB2;Trusted_Connection=True;");

        }




        public DbSet<Category> Categories { get; set; }

    }

}
