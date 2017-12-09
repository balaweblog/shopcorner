using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("address", Schema = "public")]
    public class Address
    {
        [Key]
        [Column("address_id")]
        public int AddressId { get; private set; }
        [Column("address")]
        public string Address1 { get; set; }
        [Column("address2")]
        public string Address2 { get; set; }
        [Column("district")]
        public string District { get; set; }
        [Column("city_id")]
        public int CityId { get; set; }
        [Column("postal_code")]
        public string PostalCode { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; private set; }
    }
}
