namespace BunkerGameBot.DataLayer.Entities
{
    using System.Text;

    public class Characteristics
    {
        public long Id { get; set; }
        public virtual User User { get; set; }
        public virtual Game Game { get; set; }
        public string Profession { get; set; }
        public string BiologicalCharacteristic { get; set; }
        public string LifeStatus { get; set; }
        public string Hobby { get; set; }
        public string Phobia { get; set; }
        public string Character { get; set; }
        public string AdditionalInformation { get; set; }
        public string Knowledge { get; set; }
        public string Baggade { get; set; }
        public string ActionCard { get; set; }
        public string ConditionCard { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(User.Name + ":");
            stringBuilder.AppendLine("Профессия: " + Profession);
            stringBuilder.AppendLine("Био. характеристика: " + BiologicalCharacteristic);
            stringBuilder.AppendLine("Состояние здоровья: " + LifeStatus);
            stringBuilder.AppendLine("Хобби: " + Hobby);
            stringBuilder.AppendLine("Фобия: " + Phobia);
            stringBuilder.AppendLine("Характер: " + Character);
            stringBuilder.AppendLine("Доп. информация: " + AdditionalInformation);
            stringBuilder.AppendLine("Знания: " + Knowledge);
            stringBuilder.AppendLine("Багаж: " + Baggade);
            stringBuilder.AppendLine("Карта действия: " + ActionCard);
            stringBuilder.AppendLine("Карта условия: " + ConditionCard);

            return stringBuilder.ToString();
        }

    }
}
