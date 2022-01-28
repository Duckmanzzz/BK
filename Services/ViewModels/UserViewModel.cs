using DLL.LogEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class UserViewModel:AuditableEntity
    {
        public string UserID { get; set; }
        public string UserFullname { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserAddr{ get; set; }
        public string UserTel { get; set; }

    }
}
