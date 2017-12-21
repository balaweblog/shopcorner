using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("film_category", Schema = "public")]
    public class FilmCategory
    {
        [Key]
        [Column("film_id")]
        public int FilmId { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; private set; }
    }
}
