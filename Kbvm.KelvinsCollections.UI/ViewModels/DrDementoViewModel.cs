using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
		[NotifyPropertyChangedRecipients]
		private ObservableCollection<ShowViewModel> _shows = [];

		[ObservableProperty]
		private ShowViewModel _selectedShow;

		partial void OnSelectedShowChanged(ShowViewModel value)
		{
			SelectedShow.PropertyChanged += _selectedShow_PropertyChanged;
		}

		private void _selectedShow_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{

		}

		public async Task LoadAsync()
		{
			var shows = _mapper.Map<IEnumerable<ShowDto>, IEnumerable<ShowViewModel>>(await _showTrackRepo.GetAllShowsAsync());
			foreach (var show in shows)
				Shows.Add(show);
		}
	}
}
