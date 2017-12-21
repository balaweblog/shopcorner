using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("language", Schema = "public")]
    public class Language
    {
        [Key]
        [Column("language_id")]
        public int LanguageId { get; private set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; private set; }
    }
}
