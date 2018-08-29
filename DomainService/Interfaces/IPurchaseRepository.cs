using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Interfaces
{
    public interface IPurchaseRepository
    {
        void Addpurchase(PurchaseDetails purchase);
        void Update(PurchaseDetails purchase);
        void Delete(int id);
        IEnumerable<PurchaseDetails> GetAllPurchases();
        PurchaseDetails GetPurchaseById(int id);
    }
}
