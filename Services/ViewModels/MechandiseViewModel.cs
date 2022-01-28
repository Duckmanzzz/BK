using DLL.LogEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class MechandiseViewModel : AuditableEntity
    {
        public string MechandiseID { get; set; }
        public string MechandiseName { get; set; }
        public string MechandiseProduct { get; set; }
        public float? MechandiseImportPrice { get; set; }
        public float? MechandiseExportPrice { get; set; }

        public UnitViewModel Unit{get;set;}
        public string UnitId { get; set; }
    }
}
