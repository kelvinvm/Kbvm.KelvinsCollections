using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kbvm.KelvinsCollections.Common.Aspects;
using Kbvm.KelvinsCollections.Models.Models.DrDemento.Dto;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using Kbvm.KelvinsCollections.ViewModels.Handlers;
using System.Collections.ObjectModel;

namespace Kbvm.KelvinsCollections.ViewModels
{
	public partial class DrDementoViewModel : ObservableObject
	{
		private readonly IDrDementoHandler _handler;

		public DrDementoViewModel(IShowTrackRepository repo, IDrDementoHandler handler)
		{
			_handler = handler ?? throw new ArgumentNullException(nameof(handler));

			_title = string.Empty;
			_description = string.Empty;
			_playList = string.Empty;
			_shows = [];
		}

		#region Observables
		[NotifyCanExecuteChangedFor("SaveShowCommand")]
		[ObservableProperty]
		private int? _showNumber;

		[NotifyCanExecuteChangedFor("SaveShowCommand")]
		[ObservableProperty]
		private string _title;

		[NotifyCanExecuteChangedFor("SaveShowCommand")]
		[ObservableProperty]
		private string _description;

		[NotifyCanExecuteChangedFor("SaveShowCommand")]
		[ObservableProperty]
		private DateTime _broadcastDate;

		[NotifyCanExecuteChangedFor("SaveShowCommand")]
		[ObservableProperty]
		private string _playList;

		[ObservableProperty]
		ObservableCollection<ShowDto> _shows;

		[ObservableProperty]
		private ShowDto? _selectedShow;

		[NotifyCanExecuteChangedFor("DeleteShowCommand")]
		[ObservableProperty]
		private int _oid;

		#endregion

		#region Commands
		[RelayCommand(CanExecute = "IsShowValid")] 
		private async Task SaveShowAsync()
		{
			var showDto = LoadShow();
			if (Oid > 0)
				await _handler.UpdateShowAsync(showDto);
			else
			{
				showDto.Oid = await _handler.SaveShowAsync(showDto);
				Shows.Add(showDto);
			}

			Clear();
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

		[RelayCommand(CanExecute = "IsShowLoaded")]
		private async Task DeleteShowAsync()
		{
			await _handler.DeleteShowAsync(Oid);
			Shows.Remove(Shows.First(s => s.Oid == Oid));
			Clear();
		}

		[RelayCommand]
		private async Task Load()
		{
			Shows = new ObservableCollection<ShowDto>(await _handler.LoadShowsAsync());
		}
		#endregion

		#region CanExecute
		private bool IsShowValid()
			=> ShowNumber > 1969 && !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Description) && !string.IsNullOrWhiteSpace(PlayList);

		private bool IsShowLoaded()
			=> Oid > 0;
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
			PlayList = String.Join("\r\n", show.Tracks.Select(t => $"{t.Name} - {t.Artist}"));  // What do I do with the OID here?
			Oid = show.Oid;
		}

		private ShowDto LoadShow()
		{
			ShowDto showDto = new()
			{
				Oid = Oid,
				ShowNumber = ShowNumber ?? 0,
				Title = Title,
				Description = Description,
				BroadcastDate = BroadcastDate,
				Tracks = _handler.GetTracks(PlayList).ToList()
			};

			return showDto;
		}
	}

}
