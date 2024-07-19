﻿using AutoMapper;
using DevExpress.Xpo;
using Kbvm.DrDemento.Repository;
using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.Repository.DrDemento
{

    public class ShowTrackRepository : RepositoryBase, IShowTrackRepository
    {
		private readonly IMapper _mapper;

		public ShowTrackRepository(IMapper mapper)
		{
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<ShowDto>> GetAllShowsAsync()
		{
			return await QueryAsync(async uow =>
			{
				var shows = await uow.Query<Show>().ToListAsync();
				return _mapper.Map<IEnumerable<Show>, IEnumerable<ShowDto>>(shows.OrderByDescending(s => s.ShowNumber));
			});
		}

		//public async Task<int> SaveNewShowAsync(ShowDto showDto)
		//      {
		//	return await CommandAsync(uow =>
		//	{
		//              var show = new Show(uow)
		//              {
		//                  ShowNumber = showDto.ShowNumber,
		//                  BroadcastDate = showDto.BroadcastDate,
		//                  Title = showDto.Title,
		//                  Description = showDto.Description
		//              };

		//              AddTracks(uow, show, showDto.Tracks);
		//		return show;
		//	});
		//      }

		//      public async Task<ShowDto> UpdateShowAsync(ShowDto showDto)
		//      {
		//          ShowDto updatedShow = null!;

		//          await CommandAsync(async uow =>
		//          {
		//              var show = await LoadShowByOidAsync(uow, showDto.Oid);
		//              if (show == null)
		//			throw new Exception("Show Could Not Be Loaded!");

		//		show.ShowNumber = showDto.ShowNumber;
		//              show.BroadcastDate = showDto.BroadcastDate;
		//              show.Title = showDto.Title;
		//              show.Description = showDto.Description;

		//              AddTracks(uow, show, showDto.Tracks.Where(t => t.Oid <= 0).ToList());

		//              showDto.Tracks.Where(t => t.Oid > 0).ToList().ForEach(t =>
		//              {
		//                  var track = show.TracksCollection.First(st => st.Oid == t.Oid);
		//                  track.Name = t.Name;
		//                  track.TrackNumber = t.TrackNumber;
		//                  track.Artist = t.Artist;
		//              });

		//              updatedShow = show.ToShowDto();
		//          });

		//          return updatedShow;
		//      }

		//      public async Task<List<ShowDto>> LoadShowsAsync()
		//      {
		//          using var uow = new UnitOfWork();
		//          var shows = await uow.Query<Show>().ToListAsync();

		//          var result = new List<ShowDto>();

		//          foreach (Show show in shows)
		//              result.Add(show.ToShowDto());

		//          return result;
		//      }

		//      public async Task DeleteShowAsync(int oid)
		//      {
		//          using var uow = new UnitOfWork();
		//          var showToDelete = await LoadShowByOidAsync(uow, oid);
		//          if (showToDelete == null)
		//              return;

		//          showToDelete.Delete();
		//          await uow.CommitChangesAsync();
		//      }

		//      public async Task<List<TrackDto>> GetTracksAsync(int showNumber)
		//      {
		//          using var uow = new UnitOfWork();
		//          var show = await LoadShowByOidAsync(uow, showNumber);
		//          if (show == null)
		//              return Enumerable.Empty<TrackDto>().ToList();

		//          var results = new List<TrackDto>();
		//          foreach (Track track in show.TracksCollection)
		//              results.Add(track.ToTrackDto());

		//          return results;
		//      }

		//      private async Task<Show> LoadShowByOidAsync(UnitOfWork uow, int oid)
		//          => await uow.GetObjectByKeyAsync<Show>(oid);

		//      private void AddTracks(UnitOfWork uow, Show show, IList<TrackDto> tracks)
		//      {

		//	foreach (TrackDto trackDto in tracks)
		//	{
		//		var track = new Track(uow)
		//		{
		//			Artist = trackDto.Artist,
		//			TrackNumber = trackDto.TrackNumber,
		//			Name = trackDto.Name
		//		};

		//		show.TracksCollection.Add(track);
		//	}
		//}
	}
}
