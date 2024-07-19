using CommunityToolkit.Mvvm.ComponentModel;
using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI.ViewModels
{
	public partial class ShowViewModel : ObservableRecipient
	{
		[ObservableProperty]
		private int _showNumber;
		[ObservableProperty]
		private DateTime _broadcastDate;
		[ObservableProperty]
		private string _title;
		[ObservableProperty]
		private string _description;
		[ObservableProperty]
		private ObservableCollection<TrackViewModel> _tracks;

		public string ShowDate => BroadcastDate.ToString("MMMM d, yyyy"); 

		public ShowViewModel(ShowDto show)
		{
			ShowNumber = show.ShowNumber;
			BroadcastDate = show.BroadcastDate;
			Title = show.Title;
			Description = show.Description;

			foreach (TrackDto trackDto in show.Tracks)
				Tracks.Add(new TrackViewModel(trackDto));
		}

		public ShowViewModel()
		{
		}
	}
}
