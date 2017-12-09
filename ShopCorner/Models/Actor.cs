using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCorner.DB.Models
{
    [Table("actor", Schema = "public")]
    public class Actor
    {
        [Column("actor_id")]
        [Key]
        public int Actor_Id { get; private set; }
        [Column("first_name")]
        public string First_Name { get; set; }
        [Column("last_name")]
        public string Last_Name { get; set; }
        [Column("last_update")]
        public DateTime Last_Update { get; private set; }
    }
}
