using CommunityToolkit.Mvvm.ComponentModel;
using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using System;
using System.Diagnostics;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI.ViewModels
{
	[DebuggerDisplay("{TrackNumber}-{Name}-{Artist}")]
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

		public string NameNumber => $"{TrackNumber,2} {Name}";

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
