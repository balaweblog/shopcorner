using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("rental", Schema = "public")]
    public class Rental
    {
        [Key]
        [Column("rental_id")]
        public int RentalId { get; private set; }
        [Column("rental_date")]
        public DateTime? RentalDate { get; set; }
        [Column("inventory_id")]
        public int InventoryId { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("return_date")]
        public DateTime? ReturnDate { get; set; }
        [Column("staff_id")]
        public int StaffId { get; set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; private set; }
    }
}
