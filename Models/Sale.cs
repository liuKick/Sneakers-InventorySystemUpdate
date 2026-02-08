using Postgrest.Models;
using Postgrest.Attributes;
using System;

namespace SneakerShop.Models
{
    [Table("sales")]
    public class Sale : BaseModel
    {
        [PrimaryKey("sale_id")]
        public string Id { get; set; }

        [Column("customer_id")]
        public string CustomerId { get; set; }

        [Column("staff_id")]
        public string StaffId { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("total_amount")]
        public decimal TotalAmount { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public Sale()
        {
            Id = Guid.NewGuid().ToString();
            Date = DateTime.Now;
            CreatedAt = DateTime.Now;
        }
    }
}