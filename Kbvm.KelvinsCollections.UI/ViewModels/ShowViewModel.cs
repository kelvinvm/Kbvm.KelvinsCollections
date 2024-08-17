using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using Kbvm.KelvinsCollections.UI.Messages;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kbvm.KelvinsCollections.UI.ViewModels
{
	public partial class ShowViewModel : ObservableRecipient
	{
		[ObservableProperty]
		private int _oid;
		[ObservableProperty]
		private int _showNumber;
		[ObservableProperty]
		private DateTimeOffset _broadcastDate;
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

		//private ICommand _clickCommand;
		//public ICommand ClickCommand
		//{
		//	get
		//	{
		//		return _clickCommand ?? (_clickCommand = new CommandHandler(() => AddTrackManual(), true));
		//	}
		//}



		//private void AddTrackManual()
		//{
		//	throw new NotImplementedException();
		//}



		[RelayCommand]
		public void AddTrack()
		{
			var newTrack = new TrackViewModel()
			{
				Name = "New Track",
				TrackNumber = Tracks.LastOrDefault()?.TrackNumber + 1 ?? 1
			};

			Tracks.Add(newTrack);
		}
	}
}
