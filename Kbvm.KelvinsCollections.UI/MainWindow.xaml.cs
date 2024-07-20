using Kbvm.KelvinsCollections.UI.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI
{
	public sealed partial class MainWindow : Window
	{
		public DrDementoViewModel ViewModel { get; set; }

		public MainWindow(DrDementoViewModel viewModel)
		{
			this.InitializeComponent();

			ViewModel = viewModel;	
			Root.Loaded += Root_Loaded;

			this.AppWindow.Resize(new Windows.Graphics.SizeInt32(750, 1000));
		}

		private async void Root_Loaded(object sender, RoutedEventArgs e) 
			=> await ViewModel.LoadAsync();

	}
}
