using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Services
{
    public class ProductService
    {
        public IEnumerable<Product> GetAvilableProducts(IEnumerable<Product> allProducts)
        {
            if (allProducts != null && allProducts.Count() > 0)
            {
                return allProducts.Where(p => p.Quantity > 0);
            }
            else
            {
                return null;
            }
         
        }
        public IEnumerable<Product> GetCompletedProducts(IEnumerable<Product> allProducts)
        {
            if (allProducts != null && allProducts.Count() > 0)
            {
                return allProducts.Where(p => p.Quantity == 0);
            }
            else
            {
                return null;
            }

        }

    }
}
