using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
namespace WebApplication2.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Purchases = new HashSet<Purchase>();
        }
        [Key]
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public decimal? Mobile { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
