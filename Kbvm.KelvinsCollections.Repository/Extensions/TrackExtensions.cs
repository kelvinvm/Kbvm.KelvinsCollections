using DevExpress.Xpo;
using Kbvm.KelvinsCollections.Models.Models;
using Kbvm.KelvinsCollections.Models.Models.DrDemento.Xpo;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.Repository.Extensions
{
	public static class TrackExtensions
	{
		public static Track ToNewTrack(this TrackDto trackDto, UnitOfWork uow, Show show)
		{
			return new Track(uow)
			{
				Name = trackDto.Name,
				TrackNumber = trackDto.TrackNumber,
				Artist = trackDto.Artist,
				Show = show
			};
		}

		public static TrackDto ToTrackDto(this Track track)
		{
			return new TrackDto(track.Name, track.TrackNumber, track.Artist);
		}
	}
}
