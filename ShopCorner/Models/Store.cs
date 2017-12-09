using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("store", Schema = "public")]
    public class Store
    {
        [Key]
        [Column("store_id")]
        public int StoreId { get; private set; }
        [Column("manager_staff_id")]
        public int ManagerStaffId { get; set; }
        [Column("address_id")]
        public int AddressId { get; set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; private set; }
    }
}
