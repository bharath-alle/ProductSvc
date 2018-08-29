using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public class PurchaseDetails
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double ActualPrice { get; set; }
        public double DiscountAmount { get; set; }
        public double FinalPrice { get; set; }
    }
}
