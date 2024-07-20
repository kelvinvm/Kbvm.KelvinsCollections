using Autofac;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

		}

		protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
		{
			var connectionStr = MSSqlConnectionProvider.GetConnectionString("WIN11-DEV", "DrDemento");
			XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionStr, DevExpress.Xpo.DB.AutoCreateOption.SchemaOnly);
			XpoDefault.Session = null;

			var builder = new ContainerBuilder();
			builder.RegisterModule<AutofacRegistrations>();
			builder.RegisterAutoMapper(typeof(App).Assembly);

			using var scope = builder.Build().BeginLifetimeScope();

			scope.Resolve<MainWindow>().Activate();
		}
	}
}
