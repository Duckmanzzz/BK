using DLL.LogEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Entity
{
    public class ExportInvoice:AuditableEntity
    {
        public string ExportInvoiceID { get; set; }
        public User LinkUserID { get; set; }
        public string ExportInvoiceUser { get; set; }
        public List<ExportInvoiceDetail> LinkExportDetailID { get; set; }
        public float? ExportTotalCash { get; set; }
    }
}
