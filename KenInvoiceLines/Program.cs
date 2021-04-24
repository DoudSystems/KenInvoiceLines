using System;
using System.Collections.Generic;
using System.Linq;

namespace KenInvoiceLines {

    class Program {

        readonly AppDbContext db = new AppDbContext();

        private void ProcessEft(List<InvoicePayment> lines) {
            var eft = new Eft();
            eft.InvoicePayments = lines;
            Console.WriteLine($"Invoice & payments balanced : {eft.CheckIfBalanced()}");
            eft.Print();
        }

        private void ProcessCheck(List<InvoicePayment> lines) {
            var check = new Check();
            check.InvoicePayments = lines;
            Console.WriteLine($"Invoice & payments balanced : {check.CheckIfBalanced()}");
            check.Print();
        }

        public void Run() {
            // This simulates the query
            var lines = from ip in db.InvoicePayments
                        orderby ip.InvoiceNumber, ip.Type
                        select ip;
            // Get all the unique invoice numbers and whether each is a check or eft
            var InvNbrTypes = lines.Select(l => new { l.InvoiceNumber, l.CheckEft }).Distinct();
            // Iterate through the unique invoice numbers
            foreach(var invnbrtype in InvNbrTypes.ToList()) {
                // get all the lines for each invoice number
                var invoicePaymentLines = lines.Where(ip => ip.InvoiceNumber == invnbrtype.InvoiceNumber).ToList();
                if(invnbrtype.CheckEft.Equals("Chk")) {
                    ProcessCheck(invoicePaymentLines);
                } else {
                    ProcessEft(invoicePaymentLines);
                }
            }
        }

        public static void Main(string[] args) {
            new Program().Run();
        }
    }
}
