using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using DLL.LogEntity;

namespace DLL.Entity
{
    public class Stock :AuditableEntity
    { 
        public string StockID { get; set; }
        public string StockName { get; set; }
        public string StockAddr { get; set; }
        public string StockNote { get; set; }
        public List<ImportInvoice> ListImportInvoice { get; set; }
        public List<ExportInvoiceDetail> ListExportInvoice { get; set; }
        public List<StockDetail> ListStockDetail { get; set; }
    }
}
