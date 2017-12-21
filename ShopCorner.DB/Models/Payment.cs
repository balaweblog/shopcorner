using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("payment", Schema = "public")]
    public class Payment
    {
        [Key]
        [Column("payment_id")]
        public int PaymentId { get; private set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("staff_id")]
        public int StaffId { get; set; }
        [Column("rental_id")]
        public int RentalId { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("payment_date")]
        public DateTime PaymentDate { get; set; }
    }
}
