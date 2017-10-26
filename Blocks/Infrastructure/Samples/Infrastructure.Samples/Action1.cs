namespace EntLibExtensions.Infrastructure.Samples
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using EntLibExtensions.Infrastructure.Workers;

    public class Action1 : IWorkerAction
    {
        public bool Run(CancellationToken cancellationToken, IDictionary<string, string> parameters)
        {
            Console.WriteLine($"Hello From {nameof(Action1)}");
            return true;
        }
    }
}