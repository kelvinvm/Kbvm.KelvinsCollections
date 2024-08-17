using Kbvm.KelvinsCollections.Common.Aspects;
using Kbvm.KelvinsCollections.UI.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI.UserControls
{
    public sealed partial class DrDShowEditorControl : UserControl
    {
		public static readonly DependencyProperty ShowProperty =
			DependencyProperty.Register(
				nameof(Show),
				typeof(ShowViewModel),
				typeof(DrDShowEditorControl),
				new PropertyMetadata(null));

		public ShowViewModel Show
		{
			get => (ShowViewModel)GetValue(ShowProperty);
			set => SetValue(ShowProperty, value);
		}

		public static readonly DependencyProperty FlacFileProperty =
			DependencyProperty.Register(
				nameof(FlacFile),
				typeof(string),
				typeof(DrDShowEditorControl),
				new PropertyMetadata(null));

		public string FlacFile
		{
			get => (string)GetValue(FlacFileProperty);
			set => SetValue(FlacFileProperty, value);
		}

		public DrDShowEditorControl()
        {
            this.InitializeComponent();
        }
    }
}
