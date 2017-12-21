using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("category", Schema = "public")]
    public class Category
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; private set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; private set; }
    }
}