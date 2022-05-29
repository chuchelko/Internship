namespace BunkerGameBot.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string Key { get; set; }

        [Required]
        public virtual Theme Theme { get; set; }

        [Required]
        public int MaxUsersCount { get; set; }

        [Required]
        public virtual List<User> Users { get; set; } = new List<User>();

        [Required]
        public virtual List<Characteristics> Characteristics { get; set; }

    }
}
