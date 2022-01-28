using DLL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class StockDetailViewModel
    {
        public string StockDetailID { get; set; }
        public string StockID { get; set; }
        public string MechandiseId { get; set; }
        public int? Quantity { get; set; }
        public string MechandiseProduct { get; set; }
        public UnitViewModel LinkUnit { get; set; }
        public string Unit { get; set; }
        public StockViewModel Stock { get; set; }
        public MechandiseViewModel Mechandise { get; set; }
    }
}
