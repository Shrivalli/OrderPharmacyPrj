using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class DrugLocation
    {
        public int Drug_Id { get; set; }
        public string Drug_Name { get; set; }
        public int Available_Stock { get; set; }
        public string Location_Name { get; set; }
    }
}
