using System.Collections.Generic;
using System.Threading.Tasks;
using BakuCreativeProjects.Data;
using BakuCreativeProjects.Models;
using Microsoft.EntityFrameworkCore;

namespace BakuCreativeProjects.Repo
{
    public class ProductRepository:IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Product>> GetProductAsync()
        {
            var products =await  _dataContext.Products
                .Include(c => c.ChildCategory)
                .Include(p=>p.Photos)
                .ToListAsync();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _dataContext.Products
                .Include(c => c.ChildCategory)
                .Include(p=>p.Photos)
                .FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<Product> CreateProductAsync(Product product)
         {
             await _dataContext.Products.AddAsync(product);
            await _dataContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var dbProduct =await _dataContext.Products
                .FirstOrDefaultAsync(x => x.Id == product.Id);
            if (dbProduct == null)
            {
                return dbProduct;
            }
            
            dbProduct.Name = product.Name;
            dbProduct.ChildCategoryId = product.ChildCategoryId;
            await _dataContext.SaveChangesAsync();
            
            return dbProduct;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var dbProduct = await _dataContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);
            if (dbProduct == null) return dbProduct;
             _dataContext.Remove(dbProduct);
            await _dataContext.SaveChangesAsync();
            return dbProduct;

        }
    }
}