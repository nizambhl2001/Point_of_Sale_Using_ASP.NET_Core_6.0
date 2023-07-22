using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public int? ProductId { get; set; }
        public int? SupplierId { get; set; }
        public int? StoreId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Vat { get; set; }
        public decimal? GrandTotalPrice { get; set; }
        public string? StockStatus { get; set; }
        public int? MemoNo { get; set; }
        public string? Coomments { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Store? Store { get; set; }
        public virtual Supplier? Supplier { get; set; }
    }
}
