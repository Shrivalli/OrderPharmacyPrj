using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Repository
{
    public class Data : IData
    {
        private MailOrderContext context;
        
        public Data(MailOrderContext _context)
        {
            context = _context;
        }
        public void AddData(RefillOrder refillOrder)
        {
            try
            {
                Refillls refill = new Refillls();
                refill.DrugID = refillOrder.DrugID;
                refill.Subscription_ID = refillOrder.Subscription_ID;
                refill.Policy_ID = refillOrder.Policy_ID;
                refill.Member_ID = refillOrder.Member_ID;
                refill.Status = refillOrder.Status;
                refill.RefillDate = refillOrder.RefillDate;
                refill.NextRefillDate = refillOrder.NextRefillDate;
                refill.FromDate = refillOrder.FromDate;
                refill.Location = refillOrder.Location;
                context.refillOrders.Add(refill);
            }
            catch(Exception e)
            {
                return;
            }
        }

        public void Savedata()
        {
            context.SaveChanges();
        }
    }
}
