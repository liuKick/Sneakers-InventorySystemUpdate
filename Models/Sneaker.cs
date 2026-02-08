using Postgrest.Models;
using Postgrest.Attributes;
using System;

namespace SneakerShop.Models
{
    [Table("sneakers")]
    public class Sneaker : BaseModel
    {
        [PrimaryKey("sneaker_id", false)]
        public string Id { get; set; }

        [Column("display_id")]
        public int DisplayId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("brand_id")]
        public string BrandId { get; set; }

        [Column("size")]
        public string Size { get; set; }

        [Column("color")]
        public string Color { get; set; }

        [Column("price")]
        public decimal Price { get; set; }  // Your cost (import price)

        [Column("sale_price")]
        public decimal? SalePrice { get; set; }  // Selling price (with profit)

        [Column("stock_quantity")]
        public int StockQuantity { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        // REMOVED calculated properties - they were causing binding issues
        // We'll calculate profits directly in the form instead

        public Sneaker()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}