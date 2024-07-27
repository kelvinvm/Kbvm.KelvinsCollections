using AutoMapper;
using ColorCode.Common;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using Kbvm.KelvinsCollections.UI.UserControls;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kbvm.KelvinsCollections.UI.ViewModels
{
	public partial class DrDementoViewModel : ObservableRecipient
	{
		private readonly IShowTrackRepository _showTrackRepo;
		private readonly IMapper _mapper;

		public DrDementoViewModel(IShowTrackRepository showTrackRepo, IMapper mapper)
		{
			_showTrackRepo = showTrackRepo ?? throw new ArgumentNullException(nameof(showTrackRepo));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

			_shows.CollectionChanged += _shows_CollectionChanged;
		}

		private void _shows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
		}

		[ObservableProperty]
		private List<string> _items = ["one", "two", "three", "four", "five"];

		[ObservableProperty]
		private ObservableCollection<ShowViewModel> _shows = [];

		[ObservableProperty]
		private ShowViewModel _selectedShow;

		[ObservableProperty]
		private ObservableCollection<TrackViewModel> _selectedShowTracks;

		[ObservableProperty]
		private TrackViewModel _selectedTrack;

		partial void OnSelectedShowChanged(ShowViewModel oldValue, ShowViewModel newValue)
		{
			if (oldValue is not null)
				oldValue.PropertyChanged -= AutoSaveShow;
			newValue.PropertyChanged += AutoSaveShow;

			SelectedShowTracks = new ObservableCollection<TrackViewModel>(newValue.Tracks.OrderBy(t => t.TrackNumber));
		}

		partial void OnSelectedTrackChanged(TrackViewModel oldValue, TrackViewModel newValue)
		{
			if (oldValue is not null)
				oldValue.PropertyChanged -= AutoSaveShow;
			newValue.PropertyChanged += AutoSaveShow;
		}

		private async void AutoSaveShow(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			Debug.WriteLine($"Saving {((ShowViewModel)sender).Title}...");
			await _showTrackRepo.UpdateShowAsync(_mapper.Map<ShowViewModel, ShowDto>((ShowViewModel)sender));
		}

		public async Task LoadAsync()
		{
			var shows = _mapper.Map<IEnumerable<ShowDto>, IEnumerable<ShowViewModel>>(await _showTrackRepo.GetAllShowsAsync());
			foreach (var show in shows)
				Shows.Add(show);
			SelectedShow = Shows.First();
		}
	}
}
