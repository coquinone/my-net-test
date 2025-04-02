using System.ServiceProcess;
using System.Diagnostics;
using System;
using CoreWCF;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WcfServiceLibrary.WindowsServiceHost
{
    public partial class Service1 : ServiceBase
    {
        private IHost host;

        public Service1()
        {
            InitializeComponent();
            host = CreateHostBuilder().Build();
        }

        private IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel()
                        .UseUrls("http://localhost:8080")
                        .ConfigureServices(services =>
                        {
                            services.AddServiceModelServices();
                            services.AddServiceModelMetadata();
                        })
                        .Configure(app =>
                        {
                            app.UseServiceModel(serviceBuilder =>
                            {
                                serviceBuilder.AddService<WcfServiceLibrary.Service1>();
                                serviceBuilder.AddServiceEndpoint<WcfServiceLibrary.Service1, WcfServiceLibrary.IService1>(new CoreWCF.BasicHttpBinding(), "/Service1");
                            });
                        });
                });

        internal void StartInDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                host.Start();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error starting service, {ex.Message}";
                EventLog.WriteEntry("WcfServiceLibraryServiceHost", errorMessage, EventLogEntryType.Error);
                EventLog.WriteEntry("WcfServiceLibraryServiceHost", ex.ToString(), EventLogEntryType.Error);
                throw;
            }
        }

        protected override void OnStop()
        {
            try
            {
                host.StopAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error stopping service, {ex.Message}";
                EventLog.WriteEntry("WcfServiceLibraryServiceHost", errorMessage, EventLogEntryType.Error);
                EventLog.WriteEntry("WcfServiceLibraryServiceHost", ex.ToString(), EventLogEntryType.Error);
                throw;
            }
        }
    }
}