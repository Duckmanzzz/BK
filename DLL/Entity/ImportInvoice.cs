using DLL.LogEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Entity
{
    public class ImportInvoice:AuditableEntity
    {
        public string ImportInvoiceID { get; set; }
        public User ImportInvoiceUser { get; set; }
        
        public string UserId { get; set; }
        public List<ImportInvoiceDetail> LinkImportDetailID { get; set; }
        public Stock LinkStockID { get; set; }
        public string StockId { get; set; }
        public float? ImportTotalCash { get; set; }
    }
}
