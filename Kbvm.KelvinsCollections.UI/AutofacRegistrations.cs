using Autofac;
using Kbvm.KelvinsCollections.Repository.DrDemento;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using Kbvm.KelvinsCollections.UI.Views.Forms;
using Kbvm.KelvinsCollections.UI.Views.UserControls;
using Kbvm.KelvinsCollections.ViewModels;
using Kbvm.KelvinsCollections.ViewModels.Handlers;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI
{
	internal class AutofacRegistrations : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<MainForm>().AsSelf();
			builder.RegisterType<DrDementoUserControl>().AsSelf();
			builder.RegisterType<VinylUserControl>().AsSelf();

			builder.RegisterType<DrDementoViewModel>().AsSelf();

			builder.RegisterType<ShowTrackRepository>().As<IShowTrackRepository>();
			builder.RegisterType<DrDementoHandler>().As<IDrDementoHandler>();
		}
	}
}
