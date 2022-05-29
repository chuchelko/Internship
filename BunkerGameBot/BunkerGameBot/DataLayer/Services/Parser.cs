namespace BunkerGameBot.DataLayer.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BunkerGameBot.DataLayer.Entities;

    internal class Parser
    {
        private static Random random;

        public static async Task<Theme> GetRandomThemeAsync(Game game)
        {
            random = new Random(DateTime.Now.Millisecond * DateTime.Now.Second);
            string[] themeLocations = await File.ReadAllLinesAsync(@"DataLayer\Services\ThemeData\Locations.txt");
            string[] themeNamesDescriptions = await File.ReadAllLinesAsync(@"DataLayer\Services\ThemeData\NamesDescriptions.txt");
            string[] resources = await File.ReadAllLinesAsync(@"DataLayer\Services\ThemeData\Resources.txt");
            string[] bunkerNames = await File.ReadAllLinesAsync(@"DataLayer\Services\ThemeData\BunkerNames.txt");
            string[] roomNames = await File.ReadAllLinesAsync(@"DataLayer\Services\RoomData\Names.txt");
            string[] roomStatuses = await File.ReadAllLinesAsync(@"DataLayer\Services\RoomData\Statuses.txt");
            string[] roomDangers = await File.ReadAllLinesAsync(@"DataLayer\Services\RoomData\Dangers.txt");

            Theme theme = new Theme();
            theme.ThemeNameAndDescription = GetRandomString(themeNamesDescriptions);
            theme.Location = GetRandomString(themeLocations);
            theme.Rooms = new List<Room>(random.Next(2, 5));
            theme.BunkerName = GetRandomString(bunkerNames);
            theme.Resources = GetRandomString(resources);
            var secondResource = GetRandomString(resources);

            while(secondResource.Split()[0] == theme.Resources.Split()[0])
            {
                secondResource = GetRandomString(resources);
            }

            theme.Resources += '\n' + GetRandomString(resources);
            theme.YearsToLive = random.Next(1, 100);

            for (int i = 0; i < theme.Rooms.Capacity; i++)
                theme.Rooms.Add(new Room());

            foreach (Room room in theme.Rooms)
            {
                room.Theme = theme;
                room.Status = GetRandomString(roomStatuses);
                string name = GetRandomString(roomNames);
                while (theme.Rooms.Any(r => r.Name == name))
                    name = GetRandomString(roomNames);
                room.Name = name;
                room.Danger = GetRandomString(roomDangers);
                room.Locked = random.Next(0, 2) != 0;
            }

            theme.Game = game;
            return theme;
        }

        public static Characteristics[] GetRandomCharacteristics(int maxUsersCount)
        {
            var result = new Characteristics[maxUsersCount];
            Dictionary<string, List<string>> characteristicLists = new Dictionary<string, List<string>>();
            characteristicLists.Add("Профессия", new List<string>());
            characteristicLists.Add("Биологические характеристики", new List<string>());
            characteristicLists.Add("Состояние здоровья", new List<string>());
            characteristicLists.Add("Хобби", new List<string>());
            characteristicLists.Add("Фобия", new List<string>());
            characteristicLists.Add("Характер", new List<string>());
            characteristicLists.Add("Дополнительная информация", new List<string>());
            characteristicLists.Add("Знания", new List<string>());
            characteristicLists.Add("Багаж", new List<string>());
            characteristicLists.Add("Карта действия", new List<string>());
            characteristicLists.Add("Карта условия", new List<string>());

            using var stream = new FileStream(@"DataLayer\Services\UserData\Characteristics.txt", FileMode.Open, FileAccess.Read);
            using var reader = new StreamReader(stream);

            string newString;
            string currCharacteristic = string.Empty;
            while (!reader.EndOfStream)
            {
                newString = reader.ReadLine();
                if (newString == string.Empty)
                    continue;

                if (characteristicLists.ContainsKey(newString))
                {
                    currCharacteristic = newString;
                    continue;
                }

                characteristicLists[currCharacteristic].Add(newString);
            }

            Dictionary<string, Queue<string>> characteristicNames = new Dictionary<string, Queue<string>>();

            foreach (var listItem in characteristicLists)
            {
                Queue<string> characteristicsQueue = new Queue<string>();

                while(listItem.Value.Count > 0)
                {
                    string ch = listItem.Value[random.Next(listItem.Value.Count)];
                    listItem.Value.Remove(ch);
                    characteristicsQueue.Enqueue(ch);
                }

                characteristicNames[listItem.Key] = characteristicsQueue;
            }

            for(int i = 0; i < maxUsersCount; i++)
            {
                var characteristics = new Characteristics();
                characteristics.Profession = characteristicNames["Профессия"].Dequeue();
                characteristics.BiologicalCharacteristic = characteristicNames["Биологические характеристики"].Dequeue();
                characteristics.LifeStatus = characteristicNames["Состояние здоровья"].Dequeue();
                characteristics.Hobby = characteristicNames["Хобби"].Dequeue();
                characteristics.Phobia = characteristicNames["Фобия"].Dequeue();
                characteristics.Character = characteristicNames["Характер"].Dequeue();
                characteristics.AdditionalInformation = characteristicNames["Дополнительная информация"].Dequeue();
                characteristics.Knowledge = characteristicNames["Знания"].Dequeue();
                characteristics.Baggade = characteristicNames["Багаж"].Dequeue();
                characteristics.ActionCard = characteristicNames["Карта действия"].Dequeue();
                characteristics.ConditionCard = characteristicNames["Карта условия"].Dequeue();
                result[i] = characteristics;
            }

            return result;
        }

        private static string GetRandomString(string[] str)
        {
            return str[random.Next(str.Length - 1)];
        }
    }
}
