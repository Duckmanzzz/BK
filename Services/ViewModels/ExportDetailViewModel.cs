using DLL.LogEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class ExportDetailViewModel:AuditableEntity
    {
        public string ExportInvoiceDetailID { get; set; }
        public string MechandiseId { get; set; }
       
        public string StockId { get; set; }
        public int Quantity { get; set; }
        public float ExportCashDetail { get; set; }
    }
}
