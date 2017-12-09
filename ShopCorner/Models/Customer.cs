using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("customer", Schema = "public")]
    public class Customer
    {
        [Key]
        [Column("customer_id")]
        public int CustomerId { get; private set; }
        [Column("store_id")]
        public int StoreId { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("address_id")]
        public int AddressId { get; set; }
        [Column("activebool")]
        public bool Activebool { get; set; }
        [Column("create_date")]
        public DateTime CreateDate { get; private set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; private set; }
        [Column("active")]
        public int Active { get; set; }
    }
}
