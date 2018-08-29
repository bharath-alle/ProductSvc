using DomainEntities;
using DomainService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepository: IProductRepository
    {
       // private readonly ApplicationContext _context;
      

        public void CreateProduct(Product product)
        {
            ApplicationContext.Products.Add(product);
        }

        public void Delete(int id)
        {
            ApplicationContext.DeleteProduct(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {

            return ApplicationContext.Products;
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            ApplicationContext.UpdateProduct(product);
        }
       
    }
}
