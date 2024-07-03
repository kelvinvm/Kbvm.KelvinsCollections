using Kbvm.KelvinsCollections.Models.Models;
using Kbvm.KelvinsCollections.Models.Models.DrDemento.Dto;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kbvm.KelvinsCollections.ViewModels.Handlers
{
	public interface IDrDementoHandler
	{
		Task UpdateShowAsync(ShowDto showDto);
		Task DeleteShowAsync(int oid);
		IEnumerable<TrackDto> GetTracks(string tracks);
		Task<int> SaveShowAsync(ShowDto show);
		Task<IEnumerable<ShowDto>> LoadShowsAsync();
	}

	public class DrDementoHandler : IDrDementoHandler
	{
		private readonly IShowTrackRepository _repo;
		private readonly ITrackHandler _trackHandler;

		public DrDementoHandler(IShowTrackRepository repo, ITrackHandler trackHandler)
		{
			_repo = repo ?? throw new ArgumentNullException(nameof(repo));
			_trackHandler = trackHandler ?? throw new ArgumentNullException(nameof(trackHandler));
		}

		public async Task<IEnumerable<ShowDto>> LoadShowsAsync() 
			=> await _repo.LoadShowsAsync();

		public async Task<int> SaveShowAsync(ShowDto show)
			=> await _repo.SaveNewShowAsync(show);

		public async Task UpdateShowAsync(ShowDto showDto)
		{

		}

		public IEnumerable<TrackDto> GetTracks(string tracks)
			=> _trackHandler.GetTracks(tracks);		
		
		public async Task DeleteShowAsync(int oid)
			=> await _repo.DeleteShowAsync(oid);
	}
}
