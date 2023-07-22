using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class Store
    {
        public Store()
        {
            Purchases = new HashSet<Purchase>();
            Sales = new HashSet<Sale>();
            Stocks = new HashSet<Stock>();
        }
        [Key]
        public int StoreId { get; set; }
        public int? StoreNo { get; set; }
        public string? StoreName { get; set; }
        public string? Address { get; set; }
        public string? ManagerName { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
