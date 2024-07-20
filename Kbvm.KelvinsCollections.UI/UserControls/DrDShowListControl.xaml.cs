using Kbvm.KelvinsCollections.UI.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI.UserControls
{
	public sealed partial class DrDShowListControl : UserControl
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
	}
}
