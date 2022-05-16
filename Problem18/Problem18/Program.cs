namespace Problem16
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate.Tool.hbm2ddl;

    internal class Program
    {
        static void Main(string[] args)
        {
            DbContext db = new DbContext();

            using var session = db.GetSession();
            using var tx = session.BeginTransaction();
            var query = session.Query<Worker>();

            session.Save(new Worker() { Age = 15, Salary = 1000 });
            session.Save(new Worker() { Age = 15, Salary = 3000 });
            session.Save(new Worker() { Age = 15, Salary = 500 });
            session.Save(new Worker() { Age = 18, Salary = 9000 });
            session.Flush();

            //Выберите из таблицы workers записи с name равным Дмитрий, Альберт, Артем.
            var task1 = query
                .Where(worker => new string[] {"Дмитрий", "Альберт", "Артем"}.Contains(worker.Name))
                .ToArray();

            //Выберите из таблицы workers записи с login равным 'user1', 'user2', 'user3'
            var task2 = (from w in query
                        where new string[] {"user1", "user2", "user3"}.Contains(w.Login)
                        select w).ToArray();

            //Выберите из таблицы workers записи с name равным ‘Алина’, ‘Андрей’, ‘Виктория’,
            //и логином, равным 'user', 'admin', 'ivan' и зарплатой больше 300.
            var task3 = query
                .Where(worker =>
                new string[] { "Алина", "Андрей", "Виктория" }.Contains(worker.Name) &&
                new string[] {"user", "admin", "ivan"}.Contains(worker.Login) && 
                worker.Salary > 300).ToArray();

            //Выберите из таблицы workers записи c зарплатой от 100 до 1000
            var task4 = query
                .Where(worker => worker.Salary > 100 && worker.Salary < 1000)
                .ToArray();

            //Выберите из таблицы workers все записи так, чтобы туда попали только записи с разной зарплатой(без дублей)
            //var task5 = query
            //    .GroupBy(worker => worker.Salary)
            //    .Where(g => g.Count() == 1)
            //    .Select(g => g.Select(worker => w)).ToArray(); //исключение

            var task5 = query
                .GroupBy(worker => worker.Salary)
                .Select(group => group.First())
                .ToArray();

            // var task5 = (from w in query
            //              group w by worker.Salary into g
            //              where g.Count() == 1
            //              select g.Select(worker => w)).ToArray();

            //Получите все возрасты без дублирования
            var task6 = query
                .Select(worker => worker.Age)
                .Distinct()
                .ToArray();

            //Найдите в таблице workers минимальную зарплату
            var task7 = query
                .Select(worker => worker.Salary)
                .Min(); //Distinct перед Min почему-то дает исключение

            //Найдите в таблице workers максимальную зарплату
            var task8 = query
                .Select(worker => worker.Salary)
                .Max();

            //Найдите в таблице workers суммарную зарплату
            var task9 = query
                .Select(worker => worker.Salary)
                .Sum();

            //Найдите в таблице workers суммарную зарплату для людей в возрасте от 21 до 25
            var task10 = query
                .Where(worker => worker.Age >= 21 && worker.Age <= 25)
                .Select(workerQuery => workerQuery.Salary)
                .Sum();

            //Найдите в таблице workers среднюю зарплату
            var task11 = query
                .Select(worker => worker.Salary)
                .Average();

            //Найдите в таблице workers средний возраст
            var task12 = query
                .Select(worker => worker.Age)
                .Average();

            //Выберите из таблицы workers все записи, у которых дата больше текущей
            var task13 = query
                .Where(worker => worker.Date > DateTime.Now)
                .ToArray();

            //Вставьте в таблицу workers запись с полем date с текущим моментом времени в формате 'год-месяц-день часы:минуты:секунды'
            var task14 = session
                .Save(new Worker() { Date = DateTime.Parse("2012-12-20 12:50:12"), Name = "name" });

            //Вставьте в таблицу workers запись с полем date с текущей датой в формате 'год-месяц-день'.
            var task15 = session
                .Save(new Worker() { Date = DateTime.Parse("2012-12-20"), Name = "name" });

            //Выберите из таблицы workers все записи за 2020 год
            var task16 = query
                .Where(worker => worker.Date.Year == 2020)
                .ToArray();

            //Выберите из таблицы workers все записи за март любого года
            var task17 = query
                .Where(worker => worker.Date.Month == 3)
                .ToArray();

            //Выберите из таблицы workers все записи за третий день месяца
            var task18 = query
                .Where(worker => worker.Date.Day == 3)
                .ToArray();

            //Выберите из таблицы workers все записи за пятый день апреля любого года
            var task19 = query
                .Where(worker => worker.Date.Month == 4 && worker.Date.Day == 5)
                .ToArray();

            //Выберите из таблицы workers все записи за следующие дни любого месяца: 1, 7, 11, 12, 15, 19, 21, 29
            var task20 = query
                .Where(worker => new int[] { 1, 7, 11, 12, 15, 19, 21, 29 }.Contains(worker.Date.Month))
                .ToArray();

            //Выберите из таблицы workers все записи, в которых день меньше месяца.
            var task21 = query
                .Where(worker => worker.Date.Month > worker.Date.Day)
                .ToArray();

            //Найдите самые маленькие зарплаты по группам возрастов (для каждого возраста свою минимальную зарплату)
            var task22 = query
                .GroupBy(worker => worker.Age)
                .Select(group => new {
                    Age = group.Key, 
                    Salary = group.Min(workerQuery => workerQuery.Salary) 
                })
                .ToArray();

            //Найдите самый большой возраст по группам зарплат (для каждой зарплаты свой максимальный возраст)
            var task23 = query
                .GroupBy(worker => worker.Salary)
                .Select(group => new { 
                    Salary = group.Key, 
                    Age = group.Max(workerQuery => workerQuery.Age) 
                })
                .ToArray();

            //Выберите из таблицы workers все записи, зарплата в которых больше средней зарплаты.
            var task24 = query
                .Where(worker => worker.Salary > query
                                .Average(workerQuery => workerQuery.Salary))
                .ToArray();

            //Выберите из таблицы workers все записи, возраст в которых меньше среднего возраста, деленного на 2 и умноженного на 3.
            var task25 = query
                .Where(worker => worker.Salary > query
                                .Average(workerQuery => workerQuery.Salary) * 3 / 2)
                .ToArray();

            //Выберите из таблицы workers записи с минимальной зарплатой.
            var task26 = query
                .Where(worker => worker.Salary.Equals(query
                                .Min(workerQuery => workerQuery.Salary)))
                .ToArray();

            //Выберите из таблицы workers записи с максимальной зарплатой.
            var task27 = query
                .Where(worker => worker.Salary.Equals(query
                                .Max(workerQuery => workerQuery.Salary)))
                .ToArray();

            
            tx.Commit();
        }

    }    
}
