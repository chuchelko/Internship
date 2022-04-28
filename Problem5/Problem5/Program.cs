using Problem5;

using static System.Console;

Organization organization = new Organization();

while (true)
{
    WriteLine(@"Добро пожаловать в организацию!
1. Филиалы..
2. Подразделения..
3. Сотрудники..
4. Показать расчетный лист");
    int firstStep = int.Parse(ReadLine());

    switch (firstStep)
    {
        case 1: BranchConsoleManager.Print(organization); break;
        case 2: SubdivisionConsoleManager.Print(organization); break;
        case 3: EmployeeConsoleManager.Print(organization); break;
        case 4: PrintConsolePayslip(); break;
        default: WriteLine("Такой команды нет"); break; 
    }
    WriteLine("\n\n");

}

void PrintConsolePayslip()
{
    WriteLine("Введите название филиала: ");
    string name = ReadLine();

    WriteLine("Введите номер подразделения: ");
    int number = int.Parse(ReadLine());

    WriteLine(organization.GetPayslip(name, number));
}





//Старый код, оставил на всякий случай
/* organization = new Organization();
organization.AddBranch("Branch 1");
organization.AddBranch("Branch 2");
int subdivision1 = organization.AddSubdivision();
int subdivision2 = organization.AddSubdivision();
organization.GetBranch("Branch 1").AddSubdivision(organization.GetSubdivision(subdivision1));
organization.GetBranch("Branch 1").AddSubdivision(organization.GetSubdivision(subdivision2));
organization.GetBranch("Branch 2").AddSubdivision(organization.GetSubdivision(subdivision1));
Employee Ivan = organization.AddEmployee("Иванов Иван Иванович", "сантехник", SalaryType.Monthly, 15000m, "Branch 1", subdivision1);
Employee Vladislav = organization.AddEmployee("Петров Владислав Александрович", "директор", SalaryType.Monthly, 15000m, " Branch 1 ", subdivision1);
Employee Pavel = organization.AddEmployee("Жуков Павел Павлович", "охранник", SalaryType.Monthly, 30000m, "Branch 2", subdivision1);
Pavel.AddHours(150);
Ivan.AddHours(10);
Ivan.SalaryType = SalaryType.Hourly;
Ivan.Salary = 220;
Vladislav.AddHours(10);
Console.WriteLine($"У Ивана {Ivan.GetMonthSalary()}, у Владислава {Vladislav.GetMonthSalary()}, у Павла {Pavel.GetMonthSalary()}");

//списки филиалов и подразделений в алфавитном порядке
Console.WriteLine(organization.GetBranches());
Console.WriteLine(organization.GetSubdivisions());

Console.WriteLine(organization.GetSubdivision(subdivision1).GetCountOfEmployees("Branch 1"));
//расчетный лист
Console.WriteLine("\nВведите название филиала:");
string branchName = Console.ReadLine();
Console.WriteLine("\nВведите номер подразделения:");
int subdivisionNumber = int.Parse(Console.ReadLine());
Console.WriteLine("\nРасчетный лист:");
Console.WriteLine(organization.GetPayslip(branchName ?? throw new Exception(), subdivisionNumber));

//5. список филиалов с указанием количества сотрудников в каждом подразделении
Console.WriteLine(organization.GetBranchesWithSubdivisionsAndEmployees());

//список филиалов с указанием средней зарплаты
Console.WriteLine(organization.GetBranchesWithAverageSalaries());

//7. список сотрудников с зарплатой большей 1500 р в месяц
Console.WriteLine("Сотрудников с зп больше 1500р: " + organization.GetEmployeesWithSalariesGreaterThan(1500));

//8. Список сотрудников с фиксированной месячной оплатой,
//которые в текущем  месяце отработали все требуемые часы согласно трудовому календарю
Console.WriteLine("Сотрудники, отработавшие все часы: " + organization.GetEndedWorkingEmployees());

//9. список N сотрудников с наибольшим размером зарплаты в текущем месяце
Console.WriteLine(organization.GetEmployeesWithHighestSalaries(2));*/