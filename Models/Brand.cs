using Postgrest.Models;
using Postgrest.Attributes;
using System;

namespace SneakerShop.Models
{
    [Table("brands")]
    public class Brand : BaseModel
    {
        // 👇 Use lowercase property names that match database columns exactly
        public string brand_id { get; set; }
        public string brand_name { get; set; }
        public DateTime created_at { get; set; }

        public Brand()
        {
            brand_id = Guid.NewGuid().ToString();
            created_at = DateTime.Now;
        }
    }
}