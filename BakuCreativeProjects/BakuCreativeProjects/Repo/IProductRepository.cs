using System.Collections.Generic;
using System.Threading.Tasks;
using BakuCreativeProjects.Models;

namespace BakuCreativeProjects.Repo
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductsBySubCategoryIdAsync(int id);
        Task<List<Product>> GetProductsByChildCategoryIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> DeleteProductAsync(int id);
    }
}