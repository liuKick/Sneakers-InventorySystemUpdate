using Postgrest.Models;
using Postgrest.Attributes;
using System;

namespace SneakerShop.Models
{
    [Table("sale_details")]
    public class SaleDetail : BaseModel
    {
        [PrimaryKey("sale_detail_id")]
        public string Id { get; set; }

        [Column("sale_id")]
        public string SaleId { get; set; }

        [Column("sneaker_id")]
        public string SneakerId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("unit_price")]
        public decimal? UnitPrice { get; set; } // Make nullable

        [Column("sub_total")]
        public decimal? SubTotal { get; set; } // Make nullable

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public SaleDetail()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}