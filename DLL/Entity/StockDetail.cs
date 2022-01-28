﻿using DLL.LogEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Entity
{
    public class StockDetail:AuditableEntity
    {
        public string StockDetailID { get; set; }
        public Stock LinkStockID { get; set; }
        public string StockId { get; set; }
        public Mechandise LinkMechandiseID { get; set; }
        public string MechandiseId { get; set; }
        public int? Quantity { get; set; }
    }
}
