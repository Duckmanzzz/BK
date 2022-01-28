using DLL.Entity;
using DLL.LogEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class UnitViewModel:AuditableEntity
    {
        public string UnitID { get; set; }
        public string UnitName { get; set; }
        public string UnitDescreption { get; set; }
        //public int? UnitCount { get; set; }
        public List<Mechandise> ListMechandiseID { get; set; }
    }
}
