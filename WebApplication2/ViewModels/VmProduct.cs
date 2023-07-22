namespace WebApplication2.ViewModels
{
    public class VmProduct
    {
        public int ProductTypeId { get; set; }
        public string? ProductTypeName { get; set; }
        public string[]? ProductName { get; set; }
        public decimal[]? BuyingPrice { get; set; }
        public decimal[]? SellingPrice { get; set; }
        public List<VmProductDetail> vmProductDetails { get; set; } = new List<VmProductDetail>();
        public class VmProductDetail
        {
            public int ProductId { get; set; }
            public int ProductTypeId { get; set; }
            public string? ProductName { get; set; }
            public decimal? BuyingPrice { get; set; }
            public decimal? SellingPrice { get; set; }
            public string? Photo { get; set; }
        }
        
    }
}
