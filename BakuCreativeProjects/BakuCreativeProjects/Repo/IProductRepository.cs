using System.Collections.Generic;
using System.Threading.Tasks;
using BakuCreativeProjects.Models;

namespace BakuCreativeProjects.Repo
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductAsync();
        Task<Product> GetProductByIdAsync(int id);
       // Task<List<Product>> GetDoctorByDepartmentIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> DeleteProductAsync(int id);
    }
}