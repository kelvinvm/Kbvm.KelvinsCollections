using Kbvm.KelvinsCollections.Models.Models;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.Repository.Interfaces
{
    public interface ITrackHandler
    {
        IEnumerable<TrackDto> GetTracks(string showNotes, string? artist = null);
    }
}
