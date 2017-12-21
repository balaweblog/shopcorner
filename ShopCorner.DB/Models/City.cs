using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("city", Schema = "public")]
    public class City
    {
        [Key]
        [Column("city_id")]
        public int CityId { get; private set; }
        [Column("city")]
        public string CityName{ get; set; }
        [Column("country_id")]
        public int CountryId { get; set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; private set; }
    }
}
