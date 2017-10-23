
namespace EntLibExtensions.Infrastructure.Workers.Implementation
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    ///     The worker.
    /// </summary>
    public class ActionWorker : Worker
    {
        /// <summary>
        ///     The worker configuration.
        /// </summary>
        private readonly IWorkerActionConfiguration workerActionConfiguration;

        /// <summary>
        ///     The worker action factory.
        /// </summary>
        private readonly IWorkerActionFactory workerActionFactory;

        /// <summary>
        ///     The is start.
        /// </summary>
        private bool isStart;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionWorker" /> class.
        /// </summary>
        /// <param name="workerActionConfiguration">The worker configuration.</param>
        /// <param name="workerActionFactory">The worker action factory.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if any argument is null.
        /// </exception>
        public ActionWorker(
            IWorkerActionConfiguration workerActionConfiguration,
            IWorkerActionFactory workerActionFactory)
        {
            if (workerActionConfiguration == null)
            {
                throw new ArgumentNullException(nameof(workerActionConfiguration));
            }

            if (workerActionFactory == null)
            {
                throw new ArgumentNullException(nameof(workerActionFactory));
            }
            
            this.workerActionConfiguration = workerActionConfiguration;
            this.workerActionFactory = workerActionFactory;
        }

        /// <summary>
        /// The delay start.
        /// </summary>
        private int DelayStart => (int)this.workerActionConfiguration.DelayStart.TotalMilliseconds;

        /// <summary>
        /// The short timeout.
        /// </summary>
        private int ShortTimeout => (int)this.workerActionConfiguration.ShortTimeout.TotalMilliseconds;

        /// <summary>
        /// The fail timeout.
        /// </summary>
        private int FailTimeout => (int)this.workerActionConfiguration.FailTimeout.TotalMilliseconds;

        /// <summary>
        ///     The start up.
        /// </summary>
        protected override void OnStartUp()
        {
            this.isStart = true;
            Task.Factory.StartNew(this.SelfRepeatTaskAction, TaskCreationOptions.LongRunning);
        }

        /// <summary>
        ///     The do work.
        /// </summary>
        /// <exception cref="OperationCanceledException">
        ///     If canceled.
        /// </exception>
        private void DoWork()
        {
            string workerActionTypeName = this.workerActionConfiguration.ActionType.Name;
            int timeOutDelay = this.DelayStart;            

            this.DelayOnStartIfNeeded(workerActionTypeName, timeOutDelay);

            if (this.Token.IsCancellationRequested)
            {
                return;
            }
            IWorkerActionFactory childFactory = null;
            try
            {
                childFactory = this.workerActionFactory.CerateChildFactory();
                IWorkerAction workerAction = childFactory.Create(this.workerActionConfiguration.ActionType);

                bool actionHasAnotherWork = workerAction.Run(this.Token, this.workerActionConfiguration.Parameters);
                if (actionHasAnotherWork)
                {
                    timeOutDelay = this.ShortTimeout;
                }
                else
                {
                    timeOutDelay = (int)this.workerActionConfiguration.LongTimeout.TotalMilliseconds;
                }
            }
            catch (OperationCanceledException exception)
            {
                //check that cancellation issued by correct token
                if (exception.CancellationToken == this.Token)
                {
                    InfraEventSource.Log.ActionCancel("OperationCanceledException", workerActionTypeName);
                    throw;
                }

                InfraEventSource.Log.ActionFailed(workerActionTypeName, exception.Message, exception.ToString());
                timeOutDelay = this.FailTimeout;
            }
            catch (Exception exception)
            {
                InfraEventSource.Log.ActionFailed(workerActionTypeName, exception.Message, exception.ToString());
                timeOutDelay = this.FailTimeout;
            }
            finally
            {
                this.TryToDisposeActionFactory(childFactory, workerActionTypeName);
            }

            this.DelayAfterExecutionIfNeeded(timeOutDelay, workerActionTypeName);
        }

        /// <summary>
        /// The delay on start if needed.
        /// </summary>
        /// <param name="workerActionTypeName">
        /// The worker action type name.
        /// </param>
        /// <param name="timeOutDelay">
        /// The time out delay.
        /// </param>
        private void DelayOnStartIfNeeded(string workerActionTypeName, int timeOutDelay)
        {
            if (this.isStart)
            {
                try
                {
                    if (timeOutDelay > 0 && !this.Token.IsCancellationRequested)
                    {
                        InfraEventSource.Log.ActionDelay("start", workerActionTypeName, timeOutDelay);

                        bool isCanceled = this.Token.WaitHandle.WaitOne(timeOutDelay);

                        if (isCanceled)
                        {
                            InfraEventSource.Log.ActionCancel("start delay", workerActionTypeName);
                        }
                        else
                        {
                            InfraEventSource.Log.ActionResume("start", workerActionTypeName);
                        }
                    }
                }
                catch (ObjectDisposedException)
                {
                    InfraEventSource.Log.ActionCancel("ObjectDisposedException start delay", workerActionTypeName);
                }

                this.isStart = false;
            }
        }

        /// <summary>
        /// The try to dispose action factory.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="actionName">
        /// The action name.
        /// </param>
        private void TryToDisposeActionFactory(IWorkerActionFactory factory, string actionName)
        {
            IDisposable disposable = factory as IDisposable;

            if (disposable != null)
            {
                try
                {
                    disposable.Dispose();
                }
                catch (Exception exception)
                {
                    InfraEventSource.Log.ActionFailed(actionName, "Exception occurred in the action factory dispose " + exception.Message, exception.ToString());
                }
            }
        }
        
        /// <summary>
        /// The delay after execution if needed.
        /// </summary>
        /// <param name="timeOutDelay">
        /// The time out delay.
        /// </param>
        /// <param name="workerActionTypeName">
        /// The worker action type name.
        /// </param>
        private void DelayAfterExecutionIfNeeded(int timeOutDelay, string workerActionTypeName)
        {
            try
            {
                if (timeOutDelay > 0 && !this.Token.IsCancellationRequested)
                {
                    InfraEventSource.Log.ActionDelay("run", workerActionTypeName, timeOutDelay);
                    bool isCanceled = this.Token.WaitHandle.WaitOne(timeOutDelay);
                    if (isCanceled)
                    {
                        InfraEventSource.Log.ActionCancel("run delay", workerActionTypeName);
                    }
                    else
                    {
                        InfraEventSource.Log.ActionResume("run delay", workerActionTypeName);
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                InfraEventSource.Log.ActionCancel("ObjectDisposedException run delay", workerActionTypeName);
            }
        }

        /// <summary>
        /// The self repeat task action.
        /// </summary>
        private void SelfRepeatTaskAction()
        {
            string name = this.workerActionConfiguration?.ActionType?.Name ?? "Unknown";

            if (this.Token.IsCancellationRequested)
            {
                InfraEventSource.Log.ActionCancel("CancellationRequested", name);
                return;
            }

            InfraEventSource.Log.ActionStart(name);

            try
            {
                this.DoWork();
            }            
            catch (OperationCanceledException)
            {
                //Check that cancellation requested by correct token
                if (this.Token.IsCancellationRequested)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                InfraEventSource.Log.ActionFailed(
                    name,
                    "Unhandled exception " + ex.Message,
                    ex.ToString());
            }

            InfraEventSource.Log.ActionEnd(name);

            try
            {
                Task.Factory.StartNew(this.SelfRepeatTaskAction, TaskCreationOptions.LongRunning);
            }
            catch (Exception ex)
            {
                InfraEventSource.Log.ActionFailedToReschedule(
                    name,
                    ex.Message,
                    ex.ToString());
            }
        }
    }
}