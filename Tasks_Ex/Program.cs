using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks_Ex
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //int x = 10;
            //Task task = new Task(TaskMethod);
            //Task[] taskArg = new Task[10];
            //for (int i = 0; i < taskArg.Length; i++)
            //    taskArg[i] = Task.Factory.StartNew(TaskMethod);

            //    Console.WriteLine("Ждем окончания работы задачи.");
            //Task.WaitAll();
            //Console.ReadKey();

            //int timeSpan = 500;
            //int x = 30;
            //int y = 20;
            //Console.WriteLine($"X = {x}, Y = {y}.");
            //string str = "fuck you, asshole!";
            //Console.WriteLine($"str = {str}.");
            //Task<int> task_1 = new Task<int>(() => TaskAddMethod(x, y));
            //task_1.Start();
            //Task<string> task_2 = Task.Factory.StartNew(() => TaskToUpperMethod(str));
            //Console.WriteLine("Ждем окончания работы задачи.");            
            //Task.WaitAll();
            //Console.WriteLine($"Сумма X и Y равна {task_1.Result}");
            //Console.WriteLine($"Строка str после преобразования выглядит так {task_2.Result}");
            //Console.ReadKey();

            //Task task = new Task(TaskMethod);
            //task.ContinueWith(TaskMethodContinue);
            //task.Start();
            //Console.WriteLine("Ждем окончания работы задач.");
            //Console.ReadKey();
            //int x = 3;
            //int y = 2;
            //Task task = new Task(() => TaskAddMethod(x, y));
            //task.ContinueWith(TaskMethodContinue);
            //task.Start();
            //Console.WriteLine("  Ждем окончания работы задач.");
            //Console.ReadKey();

            //int[,] array_buf = new int[x, x];
            //array_buf = genMatrix(x, x);
            //resToStr(ref array_buf);
            //for (int i = 0; i < x; i++)
            //    for (int j = 0; j < x; j++)
            //    {
            //        Console.Write($"{array_buf[j,i].ToString()}");
            //        if (j == x - 1)
            //            Console.Write("\n \r");
            //        else
            //            Console.Write(" ");

            //    }
            await matrixMultiplyForOutput();

        }

        public async Task<int> Calculate()
        {
            await Task.Delay(100);
            // Возвращаем "int", а не "Task<int>"
            return 42;
        }

            static void ParallelMethod(int item, ParallelLoopState state)
        {
            Console.WriteLine("Item: {0}. Task: {1}", item, Task.CurrentId);
            if (item == 9)
                state.Break();
            Thread.Sleep(1000);
        }

        static void TaskMethod()
        {
            Console.WriteLine($"Задача {Task.CurrentId} TaskMethod выполняется.");
            Thread.Sleep(2000);
            Console.WriteLine($"Задача {Task.CurrentId} TaskMethod завершена.");
        }

        static void TaskMethodWithParameters(int timeSpan)
        {
            Console.WriteLine($"Задача {Task.CurrentId} выполняется.");
            Console.WriteLine($"Значение timeSpan = {timeSpan} ms.");
            Thread.Sleep(timeSpan);
            Console.WriteLine($"Задача {Task.CurrentId} завершена.");
        }

        static int TaskAddMethod (int x, int y)
        {
            Console.WriteLine($"Задача {Task.CurrentId} TaskMethod выполняется.");
            Thread.Sleep(500);
            Console.WriteLine($"Задача {Task.CurrentId} TaskMethod завершена.");
            return x + y;
        }

        static string TaskToUpperMethod (string inp_str)
        {
            Thread.Sleep(500);
            return inp_str.ToUpper();
        }

        static void TaskMethodContinue(Task task)
        {
            var taskStatus = task.Status;
            Console.WriteLine($"Задача {Task.CurrentId} TaskMethodContinue  выполняется.");
            Thread.Sleep(2000);
            Console.WriteLine($"Статус TaskMethod метода: {taskStatus}.");
            Console.WriteLine($"Задача {Task.CurrentId} TaskMethodContinue завершена.");
        }

        static int [,] genMatrix (int row, int colmn)
        {
            int[,] array_ = new int[colmn, row];
            for (int i = 0; i < colmn; i++)
                for (int j = 0; j < row; j++)
                {                 
                    array_[i, j] = new Random().Next(0, 11);
                }
            return array_;
        }

        static void resToStr (ref int [,] array_buf)
        {
           
            for (int i = 0; i < array_buf.GetLength(0) ; i++)
                for (int j = 0; j < array_buf.GetLength(1); j++)
                {
                    Console.Write($"{array_buf[i, j]}");
                    if (j == array_buf.GetLength(1) - 1)
                        Console.Write("\n \r");
                    else
                        Console.Write(" ");

                }
        }

        static async Task matrixMultiplyForOutput ()
        {
            int x = 100;
            var task1 = Task.Run(() => genMatrix(x, x));
            
            var task2 = Task.Run(() => genMatrix(x, x));

            var arrBuf1 = await task1;
            Console.WriteLine("Матрица А:");
            resToStr(ref arrBuf1);
            
            
            var arrBuf2 = await task2;
            Console.WriteLine("Матрица B:");
            resToStr(ref arrBuf2);

            Console.WriteLine();
            var task3 = Task.Run(() => matrixMultiplyBase(ref arrBuf1, ref arrBuf2));
            var exitArr = await task3;
            Console.WriteLine("Матрица C, результат перемножения матриц А и В:");
            resToStr(ref exitArr);                        
        }

        static int [,] matrixMultiplyBase(ref int[,] matrixA, ref int[,] matrixB)
        {
            var matrixC = new int[matrixA.GetLength(1), matrixB.GetLength(0)];
            for (var i = 0; i < matrixA.GetLength(1); i++)
            {
                for (var j = 0; j < matrixB.GetLength(0); j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < matrixA.GetLength(0); k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixC;
        }


    }
}
