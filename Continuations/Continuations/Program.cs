using System;
using System.Threading.Tasks;

namespace Continuations
{
    class Program
    {
        static void Main()
        {
            #region WhenAll

            //Task<int> task1 = DoSomethingAsync(1);
            //Task<int> task2 = DoSomethingAsync(2);
            //Task<int> task3 = DoSomethingAsync(3);

            //Task.WhenAll(task1, task2, task3).ContinueWith(resultsTask =>
            //{
            //    int[] results = resultsTask.Result;

            //    Console.WriteLine("All tasks completed. Results:");

            //    foreach (int result in results)
            //    {
            //        Console.WriteLine(result);
            //    }
            //});
            #endregion



            #region WhenAny

            //Task<int> task1 = DoSomethingAsync(1);
            //Task<int> task2 = DoSomethingAsync(2);
            //Task<int> task3 = DoSomethingAsync(3);

            //Task.WhenAny(task1, task2, task3).ContinueWith(resultTask =>
            //{
            //    int result = resultTask.Result.Result;

            //    Console.WriteLine($"The result of the first completed task: {result}");
            //});
            #endregion



            #region ContinuationsWithChildTask
            Task<int> parentTask = Task.Run(() =>
            {
                Console.WriteLine("Parent Task started.");
                Task<int> childTask = Task.Run(() =>
                {
                    Console.WriteLine("Child Task started.");
                    return DoSomethingAsync(1);
                });

                
                return childTask.Result;
            });

            
            parentTask.ContinueWith(resultTask =>
            {
                int result = resultTask.Result;
                Console.WriteLine($"Parent Task started. Result: {result}");
            });
            #endregion



            Console.ReadLine();
        }

        static async Task<int> DoSomethingAsync(int id)
        {
            Console.WriteLine($"Task {id} has started.");
            await Task.Delay(2000);
            Console.WriteLine($"Task {id} has started.");
            return id;
        }
    }
}
