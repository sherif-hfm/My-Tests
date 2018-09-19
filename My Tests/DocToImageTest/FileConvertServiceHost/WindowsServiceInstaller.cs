using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace FileConvertServiceHost
{
    [RunInstaller(true)]
    public class WindowsServiceInstaller : Installer
    {
        /// <summary>
        /// Public Constructor for WindowsServiceInstaller.
        /// - Put all of your Initialization code here.
        /// </summary>
        public WindowsServiceInstaller()
        {
            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            //# Service Account Information
            serviceProcessInstaller.Account = ServiceAccount.User;
            serviceProcessInstaller.Username = @"itamana\eservices";
            serviceProcessInstaller.Password = "P@ssw0rd";

            //# Service Information
            serviceInstaller.DisplayName = "Riyadh File Convert Service Host";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            //# This must be identical to the WindowsService.ServiceBase name
            //# set in the constructor of WindowsService.cs
            serviceInstaller.ServiceName = "FileConvertServiceHost";

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);
        }
    }
}
