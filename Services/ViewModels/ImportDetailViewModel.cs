using DLL.LogEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class ImportDetailViewModel:AuditableEntity
    {
        public string ImportInvoiceDetailID { get; set; }
        public string LinkMechandiseId { get; set; }
        public int Quantity { get; set; }
        public string InvoiceId { get; set; }
        public float ImportCashDetail { get; set; }
    }
}
