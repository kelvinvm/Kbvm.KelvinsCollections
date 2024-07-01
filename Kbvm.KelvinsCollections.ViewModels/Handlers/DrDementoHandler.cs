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
		Task<IEnumerable<ShowDto>> LoadShowsAsync();
	}

	public class DrDementoHandler : IDrDementoHandler
	{
		private readonly IShowTrackRepository _repo;

		public DrDementoHandler(IShowTrackRepository repo)
		{
			_repo = repo ?? throw new ArgumentNullException(nameof(repo));
		}

		public async Task<IEnumerable<ShowDto>> LoadShowsAsync() 
			=> await _repo.LoadShowsAsync();


	}
}
