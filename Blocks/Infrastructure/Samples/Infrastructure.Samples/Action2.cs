namespace EntLibExtensions.Infrastructure.Samples
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using EntLibExtensions.Infrastructure.Workers;
    public class Action2 : IWorkerAction
    {
        public bool Run(CancellationToken cancellationToken, IDictionary<string, string> parameters)
        {
            Console.WriteLine("Hello from action 2");
            foreach (KeyValuePair<string, string> pair in parameters)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
            Console.WriteLine();
            Console.WriteLine();

            return false;
        }
    }
}