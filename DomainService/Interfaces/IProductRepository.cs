using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Interfaces
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void Update(Product product);
        void Delete(int id);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}
