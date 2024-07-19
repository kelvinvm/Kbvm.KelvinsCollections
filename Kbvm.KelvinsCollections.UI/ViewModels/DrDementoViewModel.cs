using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
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
		}

		[ObservableProperty]
		private List<string> _items = ["one", "two", "three", "four", "five"];

		[ObservableProperty]
		private ObservableCollection<ShowViewModel> _shows = [];

		public async Task LoadAsync()
		{
			var shows = _mapper.Map<IEnumerable<ShowDto>, IEnumerable<ShowViewModel>>(await _showTrackRepo.GetAllShowsAsync());
			foreach (var show in shows)
				Shows.Add(show);
		}
	}
}
