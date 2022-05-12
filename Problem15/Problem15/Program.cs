namespace Problem15
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Program
    {

        private static ulong _factorialNumber;

        static async Task Main(string[] args)
        {
            //4.Написать с помощью async/await асинхронный метод FactorialAsync, вычисляющую факториал от заданного числа
            var task = FactorialAsync(4);
            Thread.Sleep(300);
            Console.WriteLine("main");
            Console.WriteLine(await task);


            //5. Написать асинхронный методы чтения из файла и записи в файл
            //WriteFileAsync("file.txt", "text1\ntext2");
            await WriteFileAsync("file.txt", new string[] { "tex", "text2" });

            Task<string[]> fileTask = ReadFileAsync("file.txt");

            Console.WriteLine((await fileTask)[0]);


            //7. Написать методы, вычисляющие факториал от заданного числа, с различными вариантами возвращаемого значения.
            await FactorialWitoutReturnAsync(5);
            Console.WriteLine(_factorialNumber);

            FactorialVoidAsync(6);
            Console.WriteLine(_factorialNumber);


            //9. Вычисление факториалов от чисел 3, 4 , 5 запустить параллельно используя WhenAll.
            var task1 = FactorialAsync(3);
            var task2 = FactorialAsync(4);
            var task3 = FactorialAsync(5);
            await Task.WhenAll(task1, task2, task3); //в принципе можно было не писать, WriteLine бы ждала все три значения
            Console.WriteLine($"{await task1} {await task2} {await task3}");


            //10. Выше в пункте 4) писался метод, вычисляющий факториал от заданного числа.
            //Переделать так, чтобы, если передали число меньше нуля, то выкидывало ошибку.
            //И обработать данную ошибку с помощью try catch.
            try
            {
                ulong result = await FactorialWithExceptionAsync(-2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            //11.Если мы ожидаем выполнения сразу нескольких задач, например, с помощью Task.WhenAll,
            //то мы можем получить сразу несколько исключений одномоментно для каждой выполняемой задачи.
            //Переделать метод из пункта 9. Сделать обработку исключений сразу нескольких выполняемых задач.
            //12. Можно ли await использовать в блоках catch и finally? - можно
            List<Task> tasks12 = new List<Task>();
            tasks12.Add(FactorialWithExceptionAsync(3));
            tasks12.Add(FactorialWithExceptionAsync(-1));
            tasks12.Add(FactorialWithExceptionAsync(-3));
            try
            {
                await Task.WhenAll(tasks12.ToArray());
            }
            catch(Exception ex)
            {
                
                    Console.WriteLine(ex.Message);

            }

            Console.WriteLine($"{await task1} {await task2} {await task3}");


            //13. Используются классы CancellationToken и CancellationTokenSource написать отмену асинхронной операции.
            CancellationTokenSource cts = new CancellationTokenSource();

            Task<int> taskCTS = Task.Run(() =>
            {
                int a = 0;
                while(true)
                {
                    if (cts.IsCancellationRequested)
                        return a;
                    a++;
                }
            });
            
            await Task.Delay(100);
            cts.Cancel();
            Console.WriteLine("CancellationToken " + await taskCTS);
        }

        private static async Task<ulong> FactorialAsync(int n)
        {
            ulong factorial = 1;

            await Task.Run(() =>
            {
                for (int i = 2; i <= n; i++)
                {
                    factorial *= (ulong)i;
                }
            });
            
            return factorial;
        }

        private static async Task FactorialWitoutReturnAsync(int n)
        {
            _factorialNumber = 1;

            await Task.Run(() =>
            {
                for (int i = 2; i <= n; i++)
                {
                    _factorialNumber *= (ulong)i;
                }
            });

        }

        private static async void FactorialVoidAsync(int n)
        {
            _factorialNumber = 1;

            await Task.Run(() =>
            {
                for (int i = 2; i <= n; i++)
                {
                    _factorialNumber *= (ulong)i;
                }
            });

        }

        private static async Task<ulong> FactorialWithExceptionAsync(int n)
        {
            ulong factorial = 1;

            if (n < 0)
                throw new Exception("число меньше нуля");

            await Task.Run(() =>
            {
                for (int i = 2; i <= n; i++)
                {
                    factorial *= (ulong)i;
                }
            });

            return factorial;
        }

        private static async Task<string[]> ReadFileAsync(string path)
        {
            return await Task<string[]>.Run(() =>
            {
                return File.ReadAllLines(path);
            });

        }

        private static async Task WriteFileAsync(string path, string[] text)
        {
            await Task.Run(() =>
            {
                File.WriteAllLines(path, text);
            });
        }

    }
}
