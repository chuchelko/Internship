namespace BunkerGameBot.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Theme
    {
        public long Id { get; set; }

        [ForeignKey("Key")]
        public string GameKey { get; set; }
        public virtual Game Game { get; set; }

        [Required]
        public string BunkerName { get; set; }

        [Required]
        public string ThemeNameAndDescription { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int YearsToLive { get; set; }

        [Required]
        public string Resources { get; set; }

        [Required]
        public virtual List<Room> Rooms { get; set; }
    }
}