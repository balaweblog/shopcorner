using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("film_actor", Schema = "public")]
    public class FilmActor
    {
        [Column("actor_id")]
        public int ActorId { get; set; }

        [Column("film_id")]
        public int FilmId { get; set; }
        [Key]
        [Column("last_update")]
        public DateTime LastUpdate { get; private set; }
    }
}
