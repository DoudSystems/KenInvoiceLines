using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KenInvoiceLines {
    
    public class Check {

        public List<InvoicePayment> InvoicePayments { get; set; }

        public bool CheckIfBalanced() {
            var invoiceAmt = InvoicePayments.Single(ip => ip.Type.Equals("I")).Amount;
            var paymentAmt = InvoicePayments.Where(ip => ip.Type.Equals("P")).Sum(ip => ip.Amount);
            return invoiceAmt == paymentAmt;
        }

        public void Print() {
            InvoicePayments.ForEach(ip => {
                Console.WriteLine($"Chk: {ip}");
            });
        }

    }
}
