using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("film", Schema = "public")]
    public class Film
    {
        [Key]
        [Column("film_id")]
        public int FilmId { get; private set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("release_year")]
        public int ReleaseYear { get; set; }
        [Column("rental_duration")]
        public int RentalDuration { get;  set; }
        [Column("rental_rate")]
        public Decimal RentalRate { get;  set; }
        [Column("length")]
        public int Length { get; set; }
        [Column("replacement_cost")]
        public decimal ReplacementCost { get;  set; }
        [Column("rating")]
        public string Rating { get; set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; private set; }
        [Column("special_features")]
        public string SpecialFeatures { get; set; }
        [Column("fulltext")]
        public string FullText { get; set; }
        [Column("language_id")]
        public int LanguageId { get; set; }

    }
}
