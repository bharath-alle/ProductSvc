using DomainEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ApplicationContext
    {

        public static List<Product> Products = dummyProduct();
        public static List<Customer> Customers = dummyCustomer();
        public static List<PurchaseDetails> PurchaseDetails = dummyPurchaseDetails();

        public static List<Product> dummyProduct()
        {
            Products = new List<Product>();
            Product p = new Product
            {
                Id = 1,
                Name = "Test",
                Price = 100,
                Quantity = 10
            };
            Products.Add(p);
            return Products;
        }
        public static List<Customer> dummyCustomer()
        {
            Customers = new List<Customer>();
            Customer c = new Customer
            {
                Id = 1,
                Name = "Customer Test",
                Customertype=CustomerType.Regular
            };
            Customer cj = new Customer
            {
                Id = 2,
                Name = "Jenkins Customers",
                Customertype = CustomerType.SuperPrime
            };
            Customers.Add(c);
            Customers.Add(cj);
            return Customers;
        }
        public static List<PurchaseDetails> dummyPurchaseDetails()
        {
            PurchaseDetails = new List<PurchaseDetails>();
            PurchaseDetails pd = new PurchaseDetails
            {
                Id = 1,
                CustomerId=1,
                DiscountAmount=0,
                ActualPrice=100,
                FinalPrice=100,
                ProductId=1,
                Quantity=2
            };
            PurchaseDetails.Add(pd);
            return PurchaseDetails;
        }
        public ApplicationContext()
        {
          
        }
        public static void UpdateProduct(Product product)
        {
            if (Products.Exists(p=>p.Id==product.Id))
            {
                var indix = Products.FindIndex(p => p.Id == product.Id);
                Products[indix] = product;
            }
        }
        public static void DeleteProduct(int id)
        {
            if (Products.Exists(p => p.Id == id))
            {
                Products.RemoveAll(p => p.Id == id);
            }
        }


        public static void UpdateCustomer(Customer customer)
        {
            if (Customers.Exists(c => c.Id == customer.Id))
            {
                var indix = Customers.FindIndex(c => c.Id == customer.Id);
                Customers[indix] = customer;
            }
        }
        public static void DeleteCustomer(int id)
        {
            if (Customers.Exists(p => p.Id == id))
            {
                Customers.RemoveAll(p => p.Id == id);
            }
        }


        public static void UpdatePurchase(PurchaseDetails purchaseDetail)
        {
            if (PurchaseDetails.Exists(pd => pd.Id == purchaseDetail.Id))
            {
                var indix = PurchaseDetails.FindIndex(pd => pd.Id == purchaseDetail.Id);
                PurchaseDetails[indix] = purchaseDetail;
            }
        }
        public static void CancelPurchase(int id)
        {
            if (PurchaseDetails.Exists(p => p.Id == id))
            {
                PurchaseDetails.RemoveAll(p => p.Id == id);
            }
        }


    }
}
