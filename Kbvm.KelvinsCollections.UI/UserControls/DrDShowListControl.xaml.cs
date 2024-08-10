using CommunityToolkit.Mvvm.Messaging;
using Kbvm.KelvinsCollections.UI.Messages;
using Kbvm.KelvinsCollections.UI.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI.UserControls
{
	public partial class DrDShowListControl : UserControl
	{
		public static readonly DependencyProperty ShowListProperty =
			DependencyProperty.Register(
				nameof(Shows),
				typeof(ObservableCollection<ShowViewModel>),
				typeof(DrDShowListControl),
				new PropertyMetadata(null));

		public ObservableCollection<ShowViewModel> Shows
		{
			get => (ObservableCollection<ShowViewModel>)GetValue(ShowListProperty);
			set => SetValue(ShowListProperty, value);
		}

		public static readonly DependencyProperty SelectedShowProperty =
		DependencyProperty.Register(
			nameof(SelectedShow),
			typeof(ShowViewModel),
			typeof(DrDShowEditorControl),
			new PropertyMetadata(null));

		public ShowViewModel SelectedShow
		{
			get => (ShowViewModel)GetValue(SelectedShowProperty);
			set => SetValue(SelectedShowProperty, value);
		}

		public DrDShowListControl()
		{
			this.InitializeComponent();
		}

		private async void ConfirmDeleteDialog(object sender, RoutedEventArgs eventArgs)
		{
			ContentDialog dlg = new ContentDialog()
			{
				XamlRoot = this.XamlRoot,
				Title = "Delete Show",
				Content = "Are you sure you want to delete this show?",
				PrimaryButtonText = "Delete",
				SecondaryButtonText = "Don't Delete",
				DefaultButton = ContentDialogButton.Secondary
			};

			var result = await dlg.ShowAsync();
			if (result == ContentDialogResult.Primary)
				WeakReferenceMessenger.Default.Send(new DeleteShowMessage(SelectedShow));
		}
	}
}
