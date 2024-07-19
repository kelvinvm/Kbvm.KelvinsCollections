using Autofac;
using Kbvm.KelvinsCollections.Repository.DrDemento;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using Kbvm.KelvinsCollections.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kbvm.KelvinsCollections.UI
{
	internal class AutofacRegistrations : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<MainWindow>()
				.AsSelf()
				.SingleInstance();
			builder.RegisterType<DrDementoViewModel>()
				.AsSelf()
				.InstancePerDependency();

			//builder.RegisterType<MainForm>().AsSelf();
			//builder.RegisterType<DrDementoUserControl>().AsSelf();
			//builder.RegisterType<VinylUserControl>().AsSelf();

			//builder.RegisterType<DrDementoViewModel>().AsSelf();

			builder.RegisterType<ShowTrackRepository>()
				.As<IShowTrackRepository>()
				.SingleInstance();


			//builder.RegisterType<DrDementoHandler>().As<IDrDementoHandler>();
			//builder.RegisterType<TrackHandler>().As<ITrackHandler>();
		}
	}
}
