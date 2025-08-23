using Autofac;
using Kbvm.KelvinsCollections.Repository.DrDemento;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using Kbvm.KelvinsCollections.UI.ViewModels;
using System;
using System.Linq;

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

			builder.RegisterType<ShowTrackRepository>()
				.As<IShowTrackRepository>()
				.SingleInstance();
		}
	}
}
