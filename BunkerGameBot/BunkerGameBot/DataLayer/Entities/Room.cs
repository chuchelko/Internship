namespace BunkerGameBot.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Room
    {
        public long Id { get; set; }

        public long ThemeId { get; set; }
        public virtual Theme Theme { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool Locked { get; set; }

        [Required]
        public string Status { get; set; }
        public string Danger { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string locked = Locked ? "(закрыта на ключ)" : string.Empty;
            stringBuilder.AppendLine($"{Name} {locked}");
            stringBuilder.AppendLine($"Состояние: {Status}");
            stringBuilder.AppendLine($"Опасности: {Danger}");
            return stringBuilder.ToString();
        }
    }
}