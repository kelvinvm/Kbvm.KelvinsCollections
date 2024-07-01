using Autofac;
using DevExpress.Xpo.DB;
using DevExpress.Xpo;
using Kbvm.KelvinsCollections.UI.Views.Forms;

namespace Kbvm.KelvinsCollections.UI
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			//var connStr2 = SQLiteConnectionProvider.GetConnectionString("DrDemento");
			//XpoDefault.DataLayer = XpoDefault.GetDataLayer(connStr2, AutoCreateOption.DatabaseAndSchema);

			var connectionStr = MSSqlConnectionProvider.GetConnectionString("WIN11-DEV", "DrDemento");
			XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionStr, DevExpress.Xpo.DB.AutoCreateOption.SchemaOnly);
			XpoDefault.Session = null;

			var builder = new ContainerBuilder();
			builder.RegisterModule<AutofacRegistrations>();

			using var scope = builder.Build().BeginLifetimeScope();
			Application.Run(scope.Resolve<MainForm>());
		}
	}
}