using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.Repository.Interfaces
{
    public interface IShowTrackRepository
    {
		Task<IEnumerable<ShowDto>> GetAllShowsAsync();
	}
}
