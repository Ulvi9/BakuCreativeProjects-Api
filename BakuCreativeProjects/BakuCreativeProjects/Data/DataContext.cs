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
                 },
                 new SubCategory()
                 {
                     Id = 3, Name = "Ayaqqabi",MainCategoryId =2
                 },
                 new SubCategory()
                 {
                     Id = 4, Name = "Aksesuar",MainCategoryId = 2
                 },
                 new SubCategory()
                 {
                     Id = 5, Name = "Ayaqqabi",MainCategoryId =3
                 },
                 new SubCategory()
                 {
                     Id = 6, Name = "Aksesuar",MainCategoryId = 3
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
                     Id = 2, Name = "Sport",
                     SubCategoryId = 3,
                 },
                 new ChildCategory()
                 {
                     Id = 3, Name = "Sport",
                     SubCategoryId = 5,
                     
                 },
                 new ChildCategory()
                 {
                     Id = 4, Name = "Klassik",
                     SubCategoryId = 1,
                 },
                 new ChildCategory()
                 {
                     Id = 5, Name = "Klassik",
                     SubCategoryId = 3,
                     
                 },
                 new ChildCategory()
                 {
                     Id = 6, Name = "Klassik",
                     SubCategoryId = 5,
                 },
                 new ChildCategory()
                 {
                     Id = 7, Name = "Saat",
                     SubCategoryId = 2,
                 },
                 new ChildCategory()
                 {
                     Id = 8, Name = "Saat",
                     SubCategoryId = 4,
                     
                 },
                 new ChildCategory()
                 {
                     Id = 9, Name = "Saat",
                     SubCategoryId = 6,
                 }
             );
         }

    }
}