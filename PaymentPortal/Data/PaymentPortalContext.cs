using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentPortal.Models;

namespace PaymentPortal.Models
{
    public class PaymentPortalContext : DbContext
    {
        public PaymentPortalContext (DbContextOptions<PaymentPortalContext> options)
            : base(options)
        {
        }

        public DbSet<PaymentPortal.Models.DebitCard> DebitCard { get; set; }

        public DbSet<PaymentPortal.Models.CreditCard> CreditCard { get; set; }

        public DbSet<PaymentPortal.Models.Customer> Customer { get; set; }
    }
}
