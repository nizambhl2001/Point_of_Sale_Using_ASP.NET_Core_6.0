using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class StoreTransfer
    {
        [Key]
        public int StoreTransferId { get; set; }
        public int? ProductId { get; set; }
        public int StoreFrom { get; set; }
        public int StoreTo { get; set; }
        public int Qty { get; set; }

        public virtual Product? Product { get; set; }
    }
}
