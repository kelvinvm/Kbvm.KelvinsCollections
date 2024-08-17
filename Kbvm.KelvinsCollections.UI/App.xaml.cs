using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Kbvm.KelvinsCollections.Common.Aspects;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;
using System;
using System.Diagnostics;
using System.Linq;
using ZLogger;

namespace Kbvm.KelvinsCollections.UI
{
	public partial class App : Application
	{
		public IHost Host { get; }

		public App()
		{
			InitializeComponent();

			var connectionStr = MSSqlConnectionProvider.GetConnectionString("WIN11-DEV", "DrDemento");
			XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionStr, DevExpress.Xpo.DB.AutoCreateOption.SchemaOnly);
			XpoDefault.Session = null;

			Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
				.UseContentRoot(AppContext.BaseDirectory)
				.UseServiceProviderFactory(new AutofacServiceProviderFactory())
				.ConfigureContainer<ContainerBuilder>((container) =>
				{
					container.RegisterModule<AutofacRegistrations>();
					container.RegisterAutoMapper(typeof(App).Assembly);
				})
				.ConfigureLogging((ctx, logBldr) =>
				{
					logBldr
						.ClearProviders()
						.SetMinimumLevel(LogLevel.Trace)
						.AddZLoggerInMemory(processor =>
						{
							processor.MessageReceived += logString => Debugger.Log(0, "ZLog", $"{logString}\r\n");
						});
				})
				.Build();
		}

		protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args) 
			=> Host.Services.GetService<MainWindow>().Activate();
	}
}
