using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KenInvoiceLines {
    
    public class Eft {

        public List<InvoicePayment> InvoicePayments { get; set; }

        public bool CheckIfBalanced() {
            var invoiceAmt = InvoicePayments.Single(ip => ip.Type.Equals("I")).Amount;
            var paymentAmt = InvoicePayments.Where(ip => ip.Type.Equals("P")).Sum(ip => ip.Amount);
            return invoiceAmt == paymentAmt;
        }

        public void Print() {
            InvoicePayments.ForEach(ip => {
                Console.WriteLine($"Eft: {ip}");
            });
        }
    }
}
