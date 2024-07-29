using AutoMapper;
using DevExpress.Xpo;
using Kbvm.DrDemento.Repository;
using Kbvm.KelvinsCollections.Common.Aspects;
using Kbvm.KelvinsCollections.Models.Interfaces;
using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using Kbvm.KelvinsCollections.Repository.Exceptions;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using System;
using System.Linq;
using System.Security.Cryptography;
using static DevExpress.Data.Helpers.ExpressiveSortInfo;

namespace Kbvm.KelvinsCollections.Repository.DrDemento
{

	public class ShowTrackRepository : RepositoryBase, IShowTrackRepository
	{
		private readonly IMapper _mapper;

		public ShowTrackRepository(IMapper mapper)
		{
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		[LogException]
		public async Task<IEnumerable<ShowDto>> GetAllShowsAsync()
		{
			return await QueryAsync(async uow =>
			{
				var shows = await uow.Query<Show>().ToListAsync();
				return _mapper.Map<IEnumerable<Show>, IEnumerable<ShowDto>>(shows.OrderByDescending(s => s.ShowNumber));
			});
		}

		[LogException]
		public async Task<int> SaveNewShowAsync(ShowDto showDto)
		{
			return await CommandAsync(uow =>
			{
				var show = _mapper.Map<ShowDto, Show>(showDto, new Show(uow));

				AddNewTracks(uow, show, showDto.Tracks);

				return show;
			});
		}

		[LogException]
		public async Task<ShowDto> UpdateShowAsync(ShowDto showDto)
		{
			ShowDto updatedShow = null!;

			await CommandAsync(async uow =>
			{
				Show show = await UpdateXpoObjectFromDtoAsync<ShowDto, Show>(uow, showDto);

				AddNewTracks(uow, show, showDto.Tracks.Where(t => t.Oid <= 0).ToList());

				await UpdateTracksAsync(uow, showDto.Tracks.Where(t => t.Oid > 0).ToList());

				updatedShow = _mapper.Map<Show, ShowDto>(show);
			});

			return updatedShow;
		}

		private void AddNewTracks(UnitOfWork uow, Show show, IList<TrackDto> tracks)
		{
			foreach (TrackDto trackDto in tracks)
				show.Tracks.Add(_mapper.Map<TrackDto, Track>(trackDto, new Track(uow)));
		}

		private async Task UpdateTracksAsync(UnitOfWork uow, List<TrackDto> tracks)
		{
			foreach (TrackDto trackDto in tracks)
				await UpdateXpoObjectFromDtoAsync<TrackDto, Track>(uow, trackDto);
		}

		[NoLog]
		private async Task<TXpo> UpdateXpoObjectFromDtoAsync<TDto, TXpo>(UnitOfWork uow, TDto dto) 
			where TXpo : XPObject
			where TDto : IHaveKey
		{
			var xpObject = await uow.GetObjectByKeyAsync<TXpo>(dto.Oid);
			if (xpObject == null)
				throw new XpoObjectCouldNotBeLoadedException(typeof(TXpo), dto.Oid);
			return _mapper.Map(dto, xpObject);
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
