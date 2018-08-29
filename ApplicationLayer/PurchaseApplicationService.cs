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
    public class PurchaseApplicationService
    {
        private readonly IPurchaseRepository _purchaseRepo;
        private readonly IProductRepository _productRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly PurchaseService _purchaseservice;
        public PurchaseApplicationService(IPurchaseRepository purchaseRepo,
            IProductRepository productRepo,
            ICustomerRepository customerRepo,
            PurchaseService purchaseservice)
        {
            _purchaseRepo = purchaseRepo;
            _purchaseservice = purchaseservice;
            _productRepo = productRepo;
            _customerRepo = customerRepo;
        }

        public bool BuyProduct(PurchaseDetails purchase)
        {
            var products = _productRepo.GetAllProducts().ToList();
            var customers = _customerRepo.GetAllCustomers().ToList();
            if (!_purchaseservice.IsProductExists(products,purchase))
            {
                return false;
                // return "Selected Product not existed";
            }
            else if (!_purchaseservice.IsCustomerExists(customers,purchase))
            {
                return false;
                // return "Selected CUstomer not existed";
            }
            else if (!_purchaseservice.IsProductQuantityAvilable(products,purchase))
            {
                return false;
                // return "Selected producted already sold out";
            }
            _purchaseservice.CalculatePrice(customers, products, purchase);
            _purchaseRepo.Addpurchase(purchase);
            var product = products.Find(p => p.Id == purchase.ProductId);
            product.Quantity= product.Quantity - purchase.Quantity;
            _productRepo.Update(product);
            return true;
        }
        public IEnumerable<PurchaseDetails> GetAllPurchases()
        {
            return _purchaseRepo.GetAllPurchases();
        }

    }
}
