namespace Problem5;
using static Console;

internal static class BranchConsoleManager
{
    private static Organization _organization;

    public static void Print(Organization org)
    {
        _organization = org;
        WriteLine(@"Управление филиалами:
1. Добавить филиал
2. Привязать подразделение
3. Удалить филиал
4. Список филиалов в алфавитном порядке
5. Список филиалов в алфавитном порядке с указанием кол-ва работающих сотрудников в филиале
6. Список филиалов в алфавитном порядке с указанием кол-ва работающих сотрудников в филиале с группировкой по подразделениям
7. Список филиалов с указанием средней зарплаты в филиале");

        int secondStep = int.Parse(ReadLine());
        switch (secondStep)
        {
            case 1: Print_AddBranch(); break;
            case 2: Print_AttachSubdivision(); break;
            case 3: Print_DeleteBranch(); break;
            case 4: Print_GetBranches(); break;
            case 5: Print_GetBranchesWithEmployeeCount(); break;
            case 6: Print_GetBranchesWithSubdivisionsAndEmployees(); break;
            case 7: Print_GetBranchesWithAverageSalaries(); break;
            default: WriteLine("Такой команды нет"); break;
        }
    }

    private static void Print_AddBranch()
    {
        WriteLine("Введите название филиала: ");
        string name = ReadLine();

        if (_organization.AddBranch(name))
            WriteLine("Филиал добавлен");
        else
            WriteLine("Филиал уже существует");
    }

    private static void Print_AttachSubdivision()
    {
        WriteLine("Введите название филиала: ");
        string name = ReadLine();

        WriteLine("Введите номер подразделения, которое нужно привязать: ");
        int num = int.Parse(ReadLine());

        _organization.GetBranch(name).AddSubdivision(_organization.GetSubdivision(num));
    }

    private static void Print_DeleteBranch()
    {
        WriteLine("Введите название филиала: ");
        string name = ReadLine();

        if (_organization.RemoveBranch(name))
            WriteLine("Филиал удален");
        else
            WriteLine("Филиал не удален");
    }

    private static void Print_GetBranches()
    {
        WriteLine(_organization.GetBranches());
    }

    private static void Print_GetBranchesWithEmployeeCount()
    {
        WriteLine(_organization.GetBranchesWithEmployeeCount());
    }

    private static void Print_GetBranchesWithSubdivisionsAndEmployees()
    {
        WriteLine(_organization.GetBranchesWithSubdivisionsAndEmployees());
    }

    private static void Print_GetBranchesWithAverageSalaries()
    {
        WriteLine(_organization.GetBranchesWithAverageSalaries());
    }

}
