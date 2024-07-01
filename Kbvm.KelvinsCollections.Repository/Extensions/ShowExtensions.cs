using DevExpress.Xpo;
using Kbvm.KelvinsCollections.Models.Models;
using Kbvm.KelvinsCollections.Models.Models.DrDemento.Dto;
using Kbvm.KelvinsCollections.Models.Models.DrDemento.Xpo;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.Repository.Extensions
{
	public static class ShowExtensions
	{
		public static Show ToNewShow(this ShowDto showDto, UnitOfWork uow, IEnumerable<TrackDto> tracks)
		{
			var newShow = new Show(uow)
			{
				ShowNumber = showDto.ShowNumber,
				BroadcastDate = showDto.BroadcastDate,
				Title = showDto.Title,
				Description = showDto.Description,
			};

			foreach (TrackDto track in tracks)
				newShow.TracksCollection.Add(track.ToNewTrack(uow, newShow));

			return newShow;
		}

		public static Show ToUpdatedShow(this Show show, ShowDto showDto)
		{
			show.ShowNumber = showDto.ShowNumber;
			show.BroadcastDate = showDto.BroadcastDate;
			show.Title = showDto.Title;
			show.Description = showDto.Description;

			return show;
		}
	}
}
