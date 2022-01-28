
using DLL.LogEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class ImportInvoiceViewModel:AuditableEntity
    {
        public string ImportInvoiceID { get; set; }
        public string UserId { get; set; }
        public string StockId { get; set; }
        public float ImportTotalCash { get; set; }
        public List<ImportDetailViewModel> ListImportDetail{ get; set; }
    }
}
