using CommunityToolkit.Mvvm.ComponentModel;
using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI.ViewModels
{
	public partial class TrackViewModel : ObservableRecipient
	{
		[ObservableProperty]
		private int _oid;
		[ObservableProperty]
		private string _name;
		[ObservableProperty]
		private int _trackNumber;
		[ObservableProperty]
		private string _artist;

		public TrackViewModel(TrackDto track)
		{
			TrackNumber = track.TrackNumber;
			Artist = track.Artist;
			Name = track.Name;
		}

		public TrackViewModel()
		{
		}
	}
}
