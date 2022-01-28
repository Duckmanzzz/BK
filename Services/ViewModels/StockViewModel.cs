using DLL.LogEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class StockViewModel:AuditableEntity
    {
        public string StockID { get; set; }
        public string StockName { get; set; }
        public string StockAddr { get; set; }
        public string StockNote { get; set; }
        public List<StockDetailViewModel> ListStockDetail { get; set; }
        public List<ExportInvoiceViewModel> ListExportInvoice { get; set; }
        public List<ImportInvoiceViewModel> ListImportInvoice { get; set; }
    }
}
