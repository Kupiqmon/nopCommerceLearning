using System.Threading;

namespace ProgrammingLanguage
{
    public class AsyncThreadLearning
    {
        public static AsyncLocal<string?> Context = new();
        private static readonly AsyncLocal<object> AsyncLocal = new AsyncLocal<object>();

        /// <summary>
        ///  Tasks run with ExecutionContext and with CapturedContext
        /// </summary>
        /// <returns>Test printing the context.value in another task and current task</returns>
        public static async Task Run()
        {
            Context.Value = "Request1";
            await Task.Delay(10);

            _ = Task.Run(() =>
            {
                // This may or may not see Context.Value depending on
                // how ExecutionContext is flowed.
                Console.WriteLine($"Background task sees: {Context.Value}");
            });

            Console.WriteLine($"Main request sees: {Context.Value}");
        }

        /// <summary>
        /// 
        /// </summary>
        public void TaskRunNoLongerCapturesContext()
        {
            AsyncLocal.Value = 1;
            using (ExecutionContext.SuppressFlow()) // <-- THIS
            {
                var task = Task.Run(static async () =>
                {
                    await Task.Delay(1).ConfigureAwait(false);
                    Console.WriteLine(AsyncLocal.Value); // Prints "", expected is "" <-- Hurrah
                    AsyncLocal.Value = 2;
                    Console.WriteLine(AsyncLocal.Value); // Prints "2", expected is "2"
                });

                Task.WaitAll(task);
            }

            Console.WriteLine(AsyncLocal.Value); // Prints "1", expected is "1"
        }

        public async Task<string> GetValuesAsync(string t)
        {

            using (var httpClient = new HttpClient())
            {

                var response = await httpClient
                    .GetAsync("http://www.google.com")
                    .ConfigureAwait(continueOnCapturedContext: false);


                // This is the continuation for the httpClient.GetAsync method.
                // We shouldn't get back to sync context here
                // Cuz the continueOnCapturedContext is set to *false*
                // for the Task which is returned from httpClient.GetAsync method
                var html = await GetStringAsync();

                // This is the continuation for the GetStringAsync method.
                // Should I get back to sync context here?
                // Cuz the continueOnCapturedContext is set to *true*
                // for the Task which is returned from GetStringAsync 

                // However, GetStringAsync may be executed in another thread
                // which has no knowledge for the sync context 
                // because the continueOnCapturedContext is set to *false*
                // for the Task which is returned from httpClient.GetAsync method.

                // But, on the other hand, GetStringAsync method also has a 
                // chance to be executed in the UI thread but we shouldn't be
                // relying on that. 
                html += "Hey...";
                //Foo.Text = html; Placeholder for UI Sync Context

                return html;
            }
        }

        public async Task<string> GetValuesAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient
                            .GetAsync("http://www.google.com")
                            .ConfigureAwait(continueOnCapturedContext: false);
                // And now we're on the thread pool thread.
                // This "await" will capture the current SynchronizationContext...
                var html = await GetStringAsync();
                // ... and resume it here.
                // But it's not the UI SynchronizationContext.
                // It's the ThreadPool SynchronizationContext.
                // So we're back on a thread pool thread here.
                // So this will raise an exception.
                html += "Hey...";
                //Foo.Text = html; Example
                return html;
            }
        }

        public async Task<string> GetStringAsync()
        {

            await Task.Delay(1000);
            return "Done...";
        }

        /// <summary>
        /// Deadlock example
        /// </summary>
        /// <returns>Deadlock no return</returns>
        public string GetData()
        {
            var task = GetDataAsync();
            // The code continues in the current sync context with the sync thread
            task.Wait();   // Blocking here
            return task.Result;
        }

        public async Task<string> GetDataAsync()
        {
            await Task.Delay(1000); //capture current sync context and execute async task from thread pool
            // cannot go to next line because the current sync thread is blocked from the calling method since the task is not completed and the thread is waiting
            return "Hello";
        }

    }
}
