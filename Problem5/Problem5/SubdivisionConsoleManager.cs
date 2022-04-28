namespace Problem5;
using static Console;

internal static class SubdivisionConsoleManager
{

    private static Organization _organization;

    public static void Print(Organization org)
    {
        _organization = org;
        WriteLine(@"1. Добавить подразделение
2. Удалить подразделение
3. Список подразделений в алфавитном порядке");
        int secondStep = int.Parse(ReadLine());

        switch (secondStep)
        {
            case 1: Print_AddSubdivision(); break;
            case 2: Print_DeleteSubdivision(); break;
            case 3: Print_GetSubdivisions();  break;
            default: WriteLine("Такой команды нет"); break;
        }
    }

    private static void Print_AddSubdivision()
    {
        WriteLine("Добавлено подразделение " + _organization.AddSubdivision());
    }

    private static void Print_DeleteSubdivision()
    {
        WriteLine("Введите номер подразделения: ");
        int number = int.Parse(ReadLine());

        if (_organization.RemoveSubdivision(number))
            WriteLine("Подразделение удалено");
        else
            WriteLine("Подразделения не существует");
    }

    private static void Print_GetSubdivisions()
    {
        WriteLine(_organization.GetSubdivisions());
    }
}
