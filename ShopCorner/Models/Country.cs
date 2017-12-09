using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("country", Schema = "public")]
    public class Country
    {
        [Key]
        [Column("country_id")]
        public int CountryId { get; private set; }
        [Column("country")]
        public string CountryName { get; set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; private set; }
    }
}
