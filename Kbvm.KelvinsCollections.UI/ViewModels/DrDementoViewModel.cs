﻿using AutoMapper;
using ColorCode.Common;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Kbvm.KelvinsCollections.Common.Aspects;
using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using Kbvm.KelvinsCollections.UI.Messages;
using Kbvm.KelvinsCollections.UI.UserControls;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

			WeakReferenceMessenger.Default.Register<DeleteShowMessage>(this, async (r, m) => await DeleteShowAsync(m));
			WeakReferenceMessenger.Default.Register<DeleteTrackMessage>(this, (r, m) => DeleteTrackAsync(m));
		}

		[ObservableProperty]
		private ObservableCollection<ShowViewModel> _shows = [];

		[ObservableProperty]
		private ShowViewModel _selectedShow;

		[ObservableProperty]
		private ObservableCollection<TrackViewModel> _selectedShowTracks;

		[ObservableProperty]
		private TrackViewModel _selectedTrack;

		[LogMethodTime]
		partial void OnSelectedShowChanged(ShowViewModel oldValue, ShowViewModel newValue)
		{
			if (oldValue is not null)
				oldValue.PropertyChanged -= AutoSaveShow;
			newValue.PropertyChanged += AutoSaveShow;

			if (newValue.Tracks == null)
				SelectedShowTracks = new ObservableCollection<TrackViewModel>();
			else
				SelectedShowTracks = new ObservableCollection<TrackViewModel>(newValue.Tracks.OrderBy(t => t.TrackNumber));

			SelectedTrack = SelectedShowTracks.FirstOrDefault();
		}

		[LogMethodTime]
		partial void OnSelectedTrackChanged(TrackViewModel oldValue, TrackViewModel newValue)
		{
			if (oldValue is not null)
				oldValue.PropertyChanged -= AutoSaveShow; 
			if (newValue is not null)
				newValue.PropertyChanged += AutoSaveShow;
		}

		[LogMethodTime]
		private async void AutoSaveShow(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			await _showTrackRepo.UpdateShowAsync(_mapper.Map<ShowViewModel, ShowDto>(SelectedShow));
		}

		[LogMethodTime]
		[RelayCommand]
		private async Task AddNewShow()
		{
			var newShow = new ShowViewModel()
			{
				Title = "New Show",
				BroadcastDate = DateTime.Now
			};
			newShow.Oid = await _showTrackRepo.SaveNewShowAsync(_mapper.Map<ShowViewModel, ShowDto>(newShow));
			Shows.Insert(0, newShow);
			SelectedShow = newShow;
		}

		[LogMethodTime]
		[RelayCommand]
		private void AddNewTrack()
		{
			var newTrackNumber = SelectedShow.Tracks == null ? 1 : SelectedShow.Tracks.OrderBy(t => t.TrackNumber).Last().TrackNumber + 1;
			var newTrack = new TrackViewModel()
			{
				Name = "New Track",
				TrackNumber = newTrackNumber,
				Artist = "New Artist"
			};

			if (SelectedShow.Tracks is null)
				SelectedShow.Tracks = new ObservableCollection<TrackViewModel> { newTrack };
			else
				SelectedShow.Tracks.Add(newTrack);

			if (SelectedShowTracks is null)
				SelectedShowTracks = new ObservableCollection<TrackViewModel> { newTrack };
			else
				SelectedShowTracks.Add(newTrack);

			SelectedTrack = SelectedShowTracks.Last();
		}

		public async Task LoadAsync()
		{
			var shows = _mapper.Map<IEnumerable<ShowDto>, IEnumerable<ShowViewModel>>(await _showTrackRepo.GetAllShowsAsync());
			foreach (var show in shows)
				Shows.Add(show);
			SelectedShow = Shows.First();
		}

		public async Task DeleteShowAsync(DeleteShowMessage message)
		{
			var showToDelete = Shows.FirstOrDefault(s => s.Oid == message.ShowOid);
			if (showToDelete == null)
				return;

			await _showTrackRepo.DeleteShowAsync(message.ShowOid);
			Shows.Remove(showToDelete);

			if (SelectedShow.Oid == showToDelete.Oid)
				SelectedShow = Shows.First();
		}

		private async Task DeleteTrackAsync(DeleteTrackMessage message)
		{
			var trackToDelete = SelectedShow.Tracks.FirstOrDefault(s => s.Oid == message.TrackOid);
			if (trackToDelete == null)
				return;

			SelectedShowTracks.Remove(trackToDelete);
			SelectedShow.Tracks.Remove(trackToDelete);

			SelectedTrack = SelectedShowTracks.First();

			await _showTrackRepo.UpdateShowAsync(_mapper.Map<ShowViewModel, ShowDto>(SelectedShow));
		}
	}
}
