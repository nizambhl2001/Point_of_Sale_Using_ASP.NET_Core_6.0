using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? StoreId { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? Rate { get; set; }
        [Display(Name = "Qty")]
        public int? Quantity { get; set; }
        [Display(Name = "Total")]
        public decimal? TotalPrice { get; set; }
        public decimal? Vat { get; set; }
        public decimal? Discount { get; set; }
        [Display(Name = "netTotal")]
        public decimal? NetTotalPrice { get; set; }
        public string? StockStatus { get; set; }
        public int? MemoNo { get; set; }
        public string? Coomments { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Store? Store { get; set; }
    }
}
