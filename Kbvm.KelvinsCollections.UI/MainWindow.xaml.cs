using CommunityToolkit.Mvvm.Messaging;
using Kbvm.KelvinsCollections.Common.Aspects;
using Kbvm.KelvinsCollections.UI.Messages;
using Kbvm.KelvinsCollections.UI.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI
{
	[NoLog]
	public sealed partial class MainWindow : Window
	{
		public DrDementoViewModel ViewModel { get; set; }

		public MainWindow(DrDementoViewModel viewModel)
		{
			this.InitializeComponent();

			ViewModel = viewModel;	
			Root.Loaded += Root_Loaded;
			Root.DataContext = ViewModel;

			this.AppWindow.Resize(new Windows.Graphics.SizeInt32(1000, 1000));
		}

		private async void Root_Loaded(object sender, RoutedEventArgs e) 
			=> await ViewModel.LoadAsync();

		private async void ConfirmTrackDeleteDialog(object sender, RoutedEventArgs e)
		{
			ContentDialog dlg = new ContentDialog()
			{
				XamlRoot = this.Root.XamlRoot,
				Title = "Delete Track",
				Content = "Are you sure you want to delete this track?",
				PrimaryButtonText = "Delete",
				SecondaryButtonText = "Don't Delete",
				DefaultButton = ContentDialogButton.Secondary
			};

			int showOid = (int)((ButtonBase)sender).Tag;

			var result = await dlg.ShowAsync();
			if (result == ContentDialogResult.Primary)
				WeakReferenceMessenger.Default.Send(new DeleteTrackMessage(showOid));
		}
    }
}
