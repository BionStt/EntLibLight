namespace EntLibExtensions.Infrastructure.WinService
{
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Diagnostics;
    using System.ServiceProcess;

    /// <summary>
    /// This class designed for service installation by using istallutil.exe
    /// In case installation is provided by msi service extensions code below is ignored.
    /// service information will be retrieved from wxs file.
    /// </summary>
    [RunInstaller(true)]
    public abstract class ServiceInstallerBase : Installer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceInstallerBase"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        protected ServiceInstallerBase(WinServiceInstallationOptions options)
        {            
            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            // # Service Account Information
            serviceProcessInstaller.Account = options.Account;

            // # Service Information
            serviceInstaller.DisplayName = options.DisplayName;
            serviceInstaller.Description = options.Description;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = options.Options.ServiceName;

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);

            EventLogInstaller defaultInstaller = null;
            foreach (Installer installer in serviceInstaller.Installers)
            {
                var eventLogInstaller = installer as EventLogInstaller;
                if (eventLogInstaller != null)
                {
                    defaultInstaller = eventLogInstaller;
                    break;
                }
            }

            if (defaultInstaller != null)
            {
                serviceInstaller.Installers.Remove(defaultInstaller);
            }
        }
    }
}