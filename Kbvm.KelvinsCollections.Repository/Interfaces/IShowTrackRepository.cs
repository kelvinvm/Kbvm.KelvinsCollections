using Kbvm.KelvinsCollections.Models.Models;
using Kbvm.KelvinsCollections.Models.Models.DrDemento.Dto;
using System;
using System.ComponentModel;
using System.Linq;

namespace Kbvm.KelvinsCollections.Repository.Interfaces
{
    public interface IShowTrackRepository
    {
		Task UpdateShowAsync(ShowDto showDto);
		Task<int> SaveNewShowAsync(ShowDto showDto);
        Task<List<ShowDto>> LoadShowsAsync();
        Task DeleteShowAsync(int showNumber);
        Task<List<TrackDto>> GetTracksAsync(int oid);
    }
}
