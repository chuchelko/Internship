//1. имитировать исключительную ситуацию и обработать исключение

using Problem6;

try
{
    int[] a = new int[3];
    int b = a[4];
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


//2.Привести примеры условных конструкций, позволяющие предвидеть исключительную ситуацию:
// try catch ?


//3. различные виды определения блока catch, отличие - доступ к исключению

try
{
    throw new ArgumentException();
}
catch(IndexOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}
catch
{
    Console.WriteLine("Еще одно исключение");
}


//4.Написать конструкцию try catch finally с использованием when.
//К каким частям конструкции можно применить when? - catch

int y = 0;
try
{
    y = 2;
    throw new Exception();
}
catch (Exception) when(y != 2)
{
    Console.WriteLine("это сообщение не выведется");
}
catch(Exception ex)
{
    Console.WriteLine("это сообщение выведется");
}
finally
{
    Console.WriteLine("блок finally выполняется всегда");
}


//5. Изучить класс Exception, понять для чего предназначены его свойства.
//Имитировать исключительную ситуацию. Посмотреть, что содержит каждое свойство Exception

try
{
    throw new ArgumentException();
}
catch(ArgumentException ex)
{
    //Console.WriteLine(ex.Message + '\n'
    //    + ex.StackTrace + '\n'
    //    + ex.ParamName + '\n'
    //    + ex.InnerException + '\n'
    //    + ex.TargetSite + '\n'
    //    + ex.Data.ToString() + '\n'
    //    + ex.Source);
}


//6. Создать свой класс исключений. Использовать его в обработке ошибок.

try
{
    bool connected = false;
    if (!connected)
        throw new ConnectionFailedException("Подключиться не удалось");
}
catch(Exception ex) 
{
    Console.WriteLine(ex);
}


//7. сначала выполнится finally в Method2, затем finally в Method1 (вызовы в методах не дойдут до конца),
//catch в Method1 не сработает, так как он не ловит деление на ноль
//сработает catch в Main, затем finally в Main
//вопрос - почему из Method1 и Method2 не вызывается код после блока finally