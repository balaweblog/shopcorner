using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("inventory", Schema = "public")]
    public class Inventory
    {
        [Key]
        [Column("inventory_id")]
        public int InventoryId { get; private set; }
        [Column("film_id")]
        public int FilmId { get; set; }
        [Column("store_id")]
        public int StoreId { get; set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; private set; }
    }
}
