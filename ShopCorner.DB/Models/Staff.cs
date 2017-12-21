using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("staff", Schema = "public")]
    public class Staff
    {
        [Key]
        [Column("staff_id")]
        public int StaffId { get; private set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("address_id")]
        public int AddressId { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("store_id")]
        public int StoreId { get; set; }
        [Column("active")]
        public bool Active { get; private set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; private set; }
        [Column("picture")]
        public byte[] Picture { get; set; }
    }

}
