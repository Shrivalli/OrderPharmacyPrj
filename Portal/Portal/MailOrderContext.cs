using Microsoft.EntityFrameworkCore;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal
{
    public class MailOrderContext:DbContext
    {
        public MailOrderContext(DbContextOptions<MailOrderContext> options) : base(options)
        {

        }
        public DbSet<Refillls> refillOrders { get; set; }
    }
}
