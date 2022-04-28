namespace Problem5;

using static Console;
internal static class EmployeeConsoleManager
{

    private static Organization _organization;

    public static void Print(Organization org)
    {
        _organization = org;
        WriteLine(@"1. Добавить сотрудника
2. Удалить сотрудника
3. Поменять тип оплаты и размер зарплаты сотруднику
4. Вывести зарплату за месяц у сотрудника
5. Добавить отработанное время сотруднику
6. Список сотрудников с размером зарплаты в текущем месяце больше Х
7. Список сотрудников с фиксированной месячной оплатой, которые в текущем  месяце отработали все требуемые часы согласно трудовому календарю
8. Список N сотрудников с наибольшим размером зарплаты в текущем месяце");

        int secondStep = int.Parse(ReadLine());
        switch (secondStep)
        {
            case 1: Print_Add(); break;
            case 2: Print_Delete(); break;
            case 3: Print_ChangeTypeAndSalary(); break;
            case 4: Print_GetSalary(); break;
            case 5: Print_AddHours(); break;
            case 6: Print_GetWithSalaryGreaterThanX(); break;
            case 7: Print_GetEndedWorking(); break;
            case 8: Print_GetFirstN(); break;
            default: WriteLine("Команда не распознана"); break;
        }
    }

    private static void Print_Add()
    {
        Write("Имя: ");
        string name = ReadLine();

        Write("Позиция: ");
        string position = ReadLine();

        SalaryType type;
        while(true)
        {
            WriteLine("Тип зарплаты (1 - почасовая, 2 - ежемесячная)");
            int choose = int.Parse(ReadLine());
            if (choose != 1 && choose != 2)
                continue;
            type = choose == 1 ? SalaryType.Hourly : SalaryType.Monthly;
            break;
        }

        Write("Зарплата: ");
        decimal salary = decimal.Parse(ReadLine());

        Write("Название филиала: ");
        string branchName = ReadLine();

        Write("Название подразделения: ");
        int subdivisionNumber = int.Parse(ReadLine());

        _organization.AddEmployee(name, position, type, salary, branchName, subdivisionNumber);
    }

    private static void Print_Delete()
    {
        Write("Введите фио сотрудника: ");
        string name = ReadLine();
        _organization.RemoveEmployee(name);
    }

    private static void Print_ChangeTypeAndSalary()
    {
        Write("Введите фио сотрудника: ");
        string name = ReadLine();

        SalaryType type;
        while (true)
        {
            WriteLine("Тип зарплаты (1 - почасовая, 2 - ежемесячная)");
            int choose = int.Parse(ReadLine());
            if (choose != 1 && choose != 2)
                continue;
            type = choose == 1 ? SalaryType.Hourly : SalaryType.Monthly;
            break;
        }

        Write("Зарплата: ");
        decimal salary = decimal.Parse(ReadLine());

        var emp = _organization.GetEmployee(name);
        emp.Salary = salary;
        emp.SalaryType = type;
    }

    private static void Print_GetSalary()
    {
        Write("Введите фио сотрудника: ");
        string name = ReadLine();

        WriteLine(_organization.GetEmployee(name)?.Salary + "руб");
    }

    private static void Print_AddHours()
    {
        Write("Введите фио сотрудника: ");
        string name = ReadLine();

        Write("Введите количество часов для добавления: ");
        int hours = int.Parse(ReadLine());

        Employee emp = _organization.GetEmployee(name);
        emp.AddHours(hours);
    }

    private static void Print_GetWithSalaryGreaterThanX()
    {
        WriteLine("Введите минимальную зарплату для вывода: ");
        decimal X = decimal.Parse(ReadLine());

        WriteLine(_organization.GetEmployeesWithSalariesGreaterThan(X));
    }

    private static void Print_GetEndedWorking()
    {
        WriteLine(_organization.GetEndedWorkingEmployees());
    }

    private static void Print_GetFirstN()
    {
        Write("Введите N: ");
        int N = int.Parse(ReadLine());

        WriteLine(_organization.GetEmployeesWithHighestSalaries(N));
    }
}
