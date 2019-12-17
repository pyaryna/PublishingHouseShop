using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL.Entities
{
    public class Customer: IdentityUser
    {
        public string Name { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
