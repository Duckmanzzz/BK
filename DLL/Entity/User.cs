﻿using DLL.LogEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Entity
{
    public class User:AuditableEntity
    {
        public string UserID { get; set; }
        public string UserFullname { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserAddr { get; set; }
        public string UserTel { get; set; }

        public List<ImportInvoice> ImportInvoices { get; set; }
        public List<ExportInvoice> ExportInvoices { get; set; }
    }
}
