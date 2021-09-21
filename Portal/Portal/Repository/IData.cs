using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Repository
{
    public interface IData
    {
        public void AddData(RefillOrder refillOrder);
        public void Savedata();
    }
}
