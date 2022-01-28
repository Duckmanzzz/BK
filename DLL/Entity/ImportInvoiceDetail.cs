using DLL.LogEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Entity
{
    public class ImportInvoiceDetail:AuditableEntity
    {
        public string ImportInvoiceDetailID { get; set; }
        public ImportInvoice LinkInvoiceID { get; set; }
        public Mechandise  LinkMechandiseID { get; set; }
        public string LinkMechandiseId { get; set; }    
        public int Quantity { get; set; }
        public string InvoiceId { get; set; }
        
        public float? ImportCashDetail { get; set; }
    }
}
