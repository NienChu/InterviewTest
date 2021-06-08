using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderCheck.Model.DataModel {
    public class ApplicationUser: IdentityUser<Guid> {
        public virtual ICollection<Order> Orders { get; set; }
    }
}
