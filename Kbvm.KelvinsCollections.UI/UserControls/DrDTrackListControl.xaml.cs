using Kbvm.KelvinsCollections.UI.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI.UserControls
{
    public sealed partial class DrDTrackListControl : UserControl
    {
		public static readonly DependencyProperty TrackListProperty =
			DependencyProperty.Register(
				nameof(Tracks),
				typeof(ObservableCollection<TrackViewModel>),
				typeof(DrDTrackListControl),
				new PropertyMetadata(null));

		public ObservableCollection<TrackViewModel> Tracks
		{
			get => (ObservableCollection<TrackViewModel>)GetValue(TrackListProperty);
			set => SetValue(TrackListProperty, value);
		}

		//public static readonly DependencyProperty SelectedTracKProperty = 
		//	DependencyProperty.Register(
		//		nameof(SelectedTrack),
		//		typeof(TrackViewModel),
		//		typeof(DrDTrackListControl),
		//		new PropertyMetadata(null));

		//public TrackViewModel SelectedTrack
		//{
		//	get => (TrackViewModel)GetValue(SelectedTracKProperty);
		//	set => SetValue(SelectedTracKProperty, value);
		//}

		public DrDTrackListControl()
        {
            this.InitializeComponent();
        }
    }
}
