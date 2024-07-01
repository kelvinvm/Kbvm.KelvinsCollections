using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kbvm.KelvinsCollections.Models.Models.DrDemento.Dto;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using Kbvm.KelvinsCollections.ViewModels.Handlers;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Kbvm.KelvinsCollections.ViewModels
{
	public partial class DrDementoViewModel : ObservableObject
	{
		private IDrDementoHandler _handler;

		public DrDementoViewModel(IShowTrackRepository repo, IDrDementoHandler handler)
		{
			_handler = handler ?? throw new ArgumentNullException(nameof(handler));

			_title = string.Empty;
			_description = string.Empty;
			_playList = string.Empty;
			_shows = [];
		}

		#region Observables
		[ObservableProperty]
		private int? _showNumber;

		[ObservableProperty]
		private string _title;

		[ObservableProperty]
		private string _description;

		[ObservableProperty]
		private DateTime _broadcastDate;

		[ObservableProperty]
		private string _playList;

		[ObservableProperty]
		ObservableCollection<ShowDto> _shows;

		[ObservableProperty]
		private ShowDto? _selectedShow;

		#endregion

		#region Commands
		[RelayCommand] 
		private void SaveShow()
		{
		}

		[RelayCommand]
		private void Reports()
		{
		}

		[RelayCommand]
		private void Clear()
		{
			LoadShow(new ShowDto());
		}

		[RelayCommand]
		private void Delete()
		{
		}

		[RelayCommand]
		private async Task Load()
		{
			Shows = new ObservableCollection<ShowDto>(await _handler.LoadShowsAsync());

			Title = "This is a title.";
			ShowNumber = 2415;
			Description = "Call me Ishmael. Or don't. I don't really care.";
		}
		#endregion

		partial void OnSelectedShowChanged(ShowDto? value)
		{
			if (value == null)
				return;

			LoadShow(value);
		}


		private void LoadShow(ShowDto show)
		{
			ShowNumber = show.ShowNumber == 0 ? null : show.ShowNumber;
			Title = show.Title;
			Description = show.Description;
			BroadcastDate = show.BroadcastDate == DateTime.MinValue ? DateTime.Now : show.BroadcastDate;
			PlayList = String.Join("\r\n", show.Tracks.Select(t => $"{t.Name} - {t.Artist}"));
		}
	}

}
