namespace BunkerGameBot.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public long UserId { get; set; }

        [Required]
        public long ChatId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Game Game { get; set; }

        public long CharacteristicsId { get; set; }
        public virtual Characteristics Characteristics { get; set; }
        
    }
}
