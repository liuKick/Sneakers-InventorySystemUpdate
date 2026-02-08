using Postgrest.Models;
using Postgrest.Attributes;
using System;

namespace SneakerShop.Models
{
    [Table("users")]
    public class User : BaseModel
    {
        [PrimaryKey("user_id")]
        public string Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("role")]
        public string Role { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("status")]
        public string Status { get; set; } = "Active";

        public User()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
            Role = "staff";
            Status = "Active";
        }
    }
}