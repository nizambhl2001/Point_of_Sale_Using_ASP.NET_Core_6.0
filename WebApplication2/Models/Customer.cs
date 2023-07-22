using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }
        [Key]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
