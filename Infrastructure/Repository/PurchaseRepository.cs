using DomainEntities;
using DomainService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PurchaseRepository: IPurchaseRepository
    {

        public void Addpurchase(PurchaseDetails purchase)
        {
            ApplicationContext.PurchaseDetails.Add(purchase);
        }

        public void Delete(int id)
        {
            ApplicationContext.CancelPurchase(id);
        }

        public IEnumerable<PurchaseDetails> GetAllPurchases()
        {
            return ApplicationContext.PurchaseDetails;
        }

        public PurchaseDetails GetPurchaseById(int id)
        {
            return ApplicationContext.PurchaseDetails.Find(pd => pd.Id == id);
        }

        public void Update(PurchaseDetails purchase)
        {
            ApplicationContext.UpdatePurchase(purchase);
        }
    }
}
