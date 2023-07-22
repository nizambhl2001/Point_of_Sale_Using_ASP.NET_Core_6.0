using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class TransactionType
    {
        [Key]
        public int TransactionId { get; set; }
        public string? TransactionTypeName { get; set; }
    }
}
