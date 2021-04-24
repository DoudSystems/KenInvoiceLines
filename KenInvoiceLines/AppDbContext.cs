using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace KenInvoiceLines {

    public class AppDbContext : DbContext {

        public DbSet<InvoicePayment> InvoicePayments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if(!builder.IsConfigured) {
                builder.UseSqlServer("server=localhost\\sqlexpress;database=KenDb;trusted_connection=true;");
            }
        }

        public AppDbContext() { }
    }
}
