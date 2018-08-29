using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Services
{
    public class PurchaseService 
    {
        public bool IsProductExists(List<Product> products,PurchaseDetails purchase)
        {
            if (products.Exists(p => p.Id == purchase.ProductId))
                return true;
            else
                return false;
        }
        public bool IsProductQuantityAvilable(List<Product> products, PurchaseDetails purchase)
        {
            if (products.Find(p => p.Id == purchase.ProductId).Quantity - purchase.Quantity >= 0)
                return true;
            else
                return false;
        }

        public bool IsCustomerExists(List<Customer> customers, PurchaseDetails purchase)
        {
            if (customers.Exists(c => c.Id == purchase.CustomerId))
                return true;
            else
                return false;
        }
        public void CalculatePrice(List<Customer> customers, List<Product> products,PurchaseDetails purchase)
        {
            Customer cust = customers.Find(c => c.Id == purchase.CustomerId);
            Product prod = products.Find(p => p.Id == purchase.ProductId);
            double actualPrice = 0;
            double discountAmt = 0;
            double finalAmt = 0;
            if (cust.Customertype==CustomerType.Prime) //10% discount
            {
                actualPrice = prod.Price;
                discountAmt = actualPrice * 10 / 100;
                finalAmt = actualPrice - discountAmt;
            }
            else if (cust.Customertype == CustomerType.SuperPrime) //20% discount
            {
                actualPrice = prod.Price;
                discountAmt = actualPrice * 20 / 100;
                finalAmt = actualPrice - discountAmt;
            }
            else //0% discount
            {
                actualPrice = prod.Price;
                discountAmt =0;
                finalAmt = actualPrice - discountAmt;
            }
            purchase.DiscountAmount = discountAmt;
            purchase.ActualPrice = actualPrice;
            purchase.FinalPrice = finalAmt;
        }
    }
}
