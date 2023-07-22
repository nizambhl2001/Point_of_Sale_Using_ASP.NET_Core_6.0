using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class Product
    {
        public Product()
        {
            Purchases = new HashSet<Purchase>();
            Sales = new HashSet<Sale>();
            Stocks = new HashSet<Stock>();
            StoreTransfers = new HashSet<StoreTransfer>();
        }
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? ProductTypeId { get; set; }
        public decimal? BuyingPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public string? Photo { get; set; }

        public virtual ProducType? ProductType { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<StoreTransfer> StoreTransfers { get; set; }
    }
}
