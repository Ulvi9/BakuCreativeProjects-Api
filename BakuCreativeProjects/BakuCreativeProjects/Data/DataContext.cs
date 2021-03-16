using BakuCreativeProjects.Models;
using Microsoft.EntityFrameworkCore;

namespace BakuCreativeProjects.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
            
        }
        
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ChildCategory> ChildCategories { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);

             //MainCategory
             modelBuilder.Entity<MainCategory>().HasData(
                 new MainCategory()
                 {
                     Id = 1, Name = "Kisi"
                 },
                 new MainCategory()
                 {
                     Id = 2, Name = "Qadin"
                 },
                 new MainCategory()
                 {
                     Id = 3, Name = "Usaq"
                 }
             );
             //SubCategory
             modelBuilder.Entity<SubCategory>().HasData(
                 new SubCategory()
                 {
                     Id = 1, Name = "Ayaqqabi",MainCategoryId =1
                 },
                 new SubCategory()
                 {
                     Id = 2, Name = "Aksesuar",MainCategoryId = 1
                 }
             ); 
             //ChildCategory
              modelBuilder.Entity<ChildCategory>().HasData(
                 new ChildCategory()
                 {
                     Id = 1, Name = "Sport",
                     SubCategoryId = 1,
                     
                 },
                 new ChildCategory()
                 {
                     Id = 2, Name = "Klassik",
                     SubCategoryId = 1,
                 }
             );
         }

    }
}