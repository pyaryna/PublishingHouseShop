using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Entities
{
    public class Customer: IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
    }
}
