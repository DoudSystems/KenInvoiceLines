using System;
using System.Collections.Generic;
using System.Text;

namespace KenInvoiceLines {
    
    public class InvoicePayment {

        public int Id { get; set; }
        public string Type { get; set; }
        public string CheckEft { get; set; }
        public string InvoiceNumber { get; set; }
        public double Amount { get; set; }

        public override string ToString() {
            return $"{Id} | {Type} | {CheckEft} | {InvoiceNumber} | {Amount}";
        }
    }
}
