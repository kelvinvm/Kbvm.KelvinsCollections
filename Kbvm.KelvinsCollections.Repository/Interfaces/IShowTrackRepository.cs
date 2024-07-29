using DevExpress.Xpo;
using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.Repository.Interfaces
{
    public interface IShowTrackRepository
    {
		Task<ShowDto> UpdateShowAsync(ShowDto showDto);
		Task<int> SaveNewShowAsync(ShowDto showDto);
		Task<IEnumerable<ShowDto>> GetAllShowsAsync();
	}
}
