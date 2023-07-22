using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class Stock
    {
        [Key]
        public int StockId { get; set; }
        public int? ProductId { get; set; }
        public int? StoreId { get; set; }
        public int? Quantity { get; set; }
        public string? Status { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Store? Store { get; set; }
    }
}
