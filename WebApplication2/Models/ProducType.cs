using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class ProducType
    {
        public ProducType()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public int? ProductTypeId { get; set; }
        public string? ProductTypeName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
