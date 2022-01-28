using DLL.LogEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Entity
{
    public class Mechandise:AuditableEntity
    {
        public string MechandiseID { get; set; }
        public string MechandiseName { get; set; }
        public string MechandiseProduct { get; set; }
        public float? MechandiseImportPrice { get; set; }
        public float? MechandiseExportPrice { get; set; }
        
        public Unit LinkUnit { get; set; }
        public string UnitId { get; set; }
        public List<StockDetail> ListStockDetail { get; set; }
        public List<ImportInvoiceDetail> LinkImportInvoiceDetail { get; set; }
        public List<ExportInvoiceDetail> LinkExportInvoiceDetail { get; set; }
    }
}
