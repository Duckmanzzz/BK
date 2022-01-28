using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Entity;
using DLL.LogEntity;

namespace DLL.Entity
{
    public class Unit :AuditableEntity
    {
        public string UnitID { get; set; }
        public string UnitName { get; set; }
        public string UnitDescreption { get; set; }
        public List<Mechandise> ListMechandiseID { get; set; }
    }
}
