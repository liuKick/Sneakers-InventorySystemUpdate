using Postgrest.Attributes;
using Postgrest.Models;
using System;

namespace SneakerShop.Models
{
    [Table("customers")]
    public class Customer : BaseModel
    {
        // Use lowercase property names matching database columns
        public string customer_id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime created_at { get; set; }

        public Customer()
        {
            customer_id = Guid.NewGuid().ToString();
            created_at = DateTime.Now;
        }
    }
}