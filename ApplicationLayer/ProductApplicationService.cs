using DomainEntities;
using DomainService.Interfaces;
using DomainService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class ProductApplicationService
    {
        private readonly IProductRepository _productRepo;
        private readonly ProductService _productservice;
        public ProductApplicationService(IProductRepository productRepo, ProductService productservice)
        {
            _productRepo = productRepo;
            _productservice = productservice;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }
        public IEnumerable<Product> GetAvilableProducts()
        {
            return _productservice.GetAvilableProducts(GetAllProducts());
        }
        public IEnumerable<Product> GetCompletedProducts()
        {
            return _productservice.GetCompletedProducts(GetAllProducts());
        }
        public void AddProduct(Product product)
        {
            _productRepo.CreateProduct(product);
        }
        public void UpdateProduct(Product product)
        {
            _productRepo.Update(product);
        }
        public void Delete(int productId)
        {
            _productRepo.Delete(productId);
        }

        public string Hello()
        {
            return "Hello";
        }
    }
}
