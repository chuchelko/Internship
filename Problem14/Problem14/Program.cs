namespace Problem14
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Program
    {

        private static long directoryLength = 0;
        static void Main(string[] args)
        {
            //4.Посмотреть способы запуска задач(Task.Run, Task.Factory.StartNew). Написать примеры.
            Task taskRun = Task.Run(() => Console.WriteLine("run() " + Task.CurrentId));

            Task taskStart = new Task(() => Console.WriteLine("start() " + Task.CurrentId));
            taskStart.Start();

            Task taskFactory = Task.Factory.StartNew(() => Console.WriteLine("startnew() " + Task.CurrentId));

            //5. Написать пример с ожиданием задачи
            Task.WaitAll(taskRun, taskFactory, taskStart);

            Console.WriteLine(Task.CompletedTask.Id);


            //7. Одна задача может запускать другую – вложенную задачу. Написать пример.
            //если запустить без AttachedToParent, то внутренняя задача будет также выполняться,
            //но внешняя не будет ждать, когда закончится выполнение внутренней, State будет равен
            //WaitingForChildrenToComplete
            //!!!outerTask нужно запускать обязательно через фабрику!!!
            Task outerTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task started");

                Task innerTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Inner task started");
                    Thread.Sleep(1000);
                    Console.WriteLine("Inner task completed");

                }, TaskCreationOptions.AttachedToParent);

                Console.WriteLine("Outer task completed");
            });

            Thread.Sleep(300);
            Console.WriteLine(outerTask.Status);
            outerTask.Wait();


            //10. Написать и запустить массив задач.
            Task[] tasks = new Task[5];

            for (int i = 0; i < tasks.Length; i++)
                tasks[i] = Task.Run(() => Console.WriteLine("10. Запущена задача " + Task.CurrentId));


            //11. Hаписать массив задач с ожиданием всех выполняемых задач.
            Task[] tasks11 = new Task[5];

            for (int i = 0; i < tasks11.Length; i++)
                tasks11[i] = Task.Run(() => Console.WriteLine("11. Запущена задача " + Task.CurrentId));

            Task.WaitAll(tasks11);


            //12. Написать задачу которая может вернуть результат и вывести этот результат в консоль.
            Task<int> taskInt = Task.Factory.StartNew(ReturnOne);
            Console.WriteLine("12. " + taskInt.Result);


            //13. Написать пример, которые выполняются после завершения другой задачи используя ContinueWith.
            Task task13 = Task.Run(() =>
            {
                Console.WriteLine("task13 started");
                Thread.Sleep(1000);
                Console.WriteLine("task13 completed");
            });

            Task task13countinue = task13.ContinueWith(task => Console.WriteLine("task13 continue"));
            task13countinue.Wait();


            //14. Построить цепочку последовательно выполняющихся задач.
            Task task14 = Task.Run(() =>
            {
                Console.WriteLine("task13 started");
            });

            Task task14countinue1 = task14.ContinueWith(task => Console.WriteLine("task14 continue1"));
            Task task14countinue2 = task14.ContinueWith(task => Console.WriteLine("task14 continue2"));
            task14countinue2.Wait();


            //17. Вычислить размер какого-нибудь большого каталога с помощью класса Parallel.
            //плюс еще написал синхронную версию метода и сравнил результаты -
            //00:00:00.1349041 vs 00:00:00.0675782 - асинхронный метод в два раза быстрее
            var watch = new Stopwatch();

            watch.Start();
            GetDirLengthSync("C:\\Users\\Emil\\Desktop\\Стажировка");
            watch.Stop();
            Console.WriteLine(watch.Elapsed.ToString());

            watch.Restart();
            GetDirLengthAsync("C:\\Users\\Emil\\Desktop\\Стажировка");
            watch.Stop();
            Console.WriteLine(watch.Elapsed.ToString());


            //18. Вычислить произведение двух матриц с помощью класса Parallel.
            double[,] matrix1 = new double[,] { 
                { 1, 1 },
                { 1, 1 } };

            double[,] matrix2 = new double[,] { 
                { 1, 0 },
                { 1, 1 } };

            double[,] resultMatrix = MultiplyMatrix(matrix1, matrix2, 2);
        }

        public static int ReturnOne() => 1;
        
        public static void GetDirLengthSync(string path)
        {
            string[] directories = Directory.GetDirectories(path);

            foreach (var dir in directories)
            {
                GetDirLengthSync(dir);
            }

            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                directoryLength += new FileInfo(file).Length;
            }
        }

        public static void GetDirLengthAsync(string path)
        {

            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                Interlocked.Add(ref directoryLength, new FileInfo(file).Length);
            }

            string[] directories = Directory.GetDirectories(path);

            Parallel.ForEach(directories, dir => GetDirLengthAsync(dir));
        }

        private static double[,] MultiplyMatrix(double[,] matrix1, double[,] matrix2, int n)
        {
            double[,] resultMatrix = new double[n, n];

            Task[] tasks = new Task[n * n];
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int i1 = i, j1 = j;
                    tasks[i * n + j] = Task.Run(() =>
                    {
                        double res = 0;
                        for (int k = 0; k < n; k++)
                            res += matrix1[j1, k] * matrix2[k, i1];
                        resultMatrix[j1, i1] = res;
                    });
                }
            }

            Task.WaitAll(tasks);
            return resultMatrix;
        }
        
    }
}
