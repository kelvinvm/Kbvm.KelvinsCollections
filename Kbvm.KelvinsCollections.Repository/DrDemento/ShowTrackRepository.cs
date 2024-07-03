using DevExpress.Xpo;
using Kbvm.KelvinsCollections.Models.Models;
using Kbvm.KelvinsCollections.Models.Models.DrDemento.Dto;
using Kbvm.KelvinsCollections.Models.Models.DrDemento.Xpo;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using Kbvm.KelvinsCollections.Repository.Extensions;
using System;
using System.Linq;
using Kbvm.DrDemento.Repository;
using Kbvm.KelvinsCollections.Models.Models.Vinyl.Dto;
using Kbvm.KelvinsCollections.Models.Models.Vinyl;
using static DevExpress.Data.Helpers.ExpressiveSortInfo;

namespace Kbvm.KelvinsCollections.Repository.DrDemento
{

    public class ShowTrackRepository : RepositoryBase, IShowTrackRepository
    {
		//private readonly ITrackHandler _trackHandler;

		//public ShowTrackRepository(ITrackHandler trackHandler)
		//{
		//    _trackHandler = trackHandler ?? throw new ArgumentNullException(nameof(trackHandler));
		//}

		public ShowTrackRepository()
		{
		}

		public async Task<int> SaveNewShowAsync(ShowDto showDto)
        {
			return await CommandAsync(uow =>
			{
                var show = new Show(uow)
                {
                    ShowNumber = showDto.ShowNumber,
                    BroadcastDate = showDto.BroadcastDate,
                    Title = showDto.Title,
                    Description = showDto.Description
                };

                AddTracks(uow, show, showDto.Tracks);
				return show;
			});
        }

        public async Task UpdateShowAsync(ShowDto showDto)
        {
            return await CommandAsync(async uow =>
            {
                var show = await LoadShowByOidAsync(uow, showDto.Oid);
                if (show == null)
                    return;

                show.ShowNumber = showDto.ShowNumber;
                show.BroadcastDate = showDto.BroadcastDate;
                show.Title = showDto.Title;
                show.Description = showDto.Description;

                AddTracks(uow, show, showDto.Tracks.Where(t => t.Oid <= 0);

            });
        }

        public async Task<List<ShowDto>> LoadShowsAsync()
        {
            using var uow = new UnitOfWork();
            var shows = await uow.Query<Show>().ToListAsync();

            var result = new List<ShowDto>();

            foreach (Show show in shows)
                result.Add(new ShowDto()
                {
                    Oid = show.Oid,
                    ShowNumber = show.ShowNumber,
                    BroadcastDate = show.BroadcastDate,
                    Title = show.Title,
                    Description = show.Description,
                    Tracks = show.TracksCollection.Select(t => t.ToTrackDto()).ToList() 
                });

            return result;
        }

        public async Task DeleteShowAsync(int oid)
        {
            using var uow = new UnitOfWork();
            var showToDelete = await LoadShowByOidAsync(uow, oid);
            if (showToDelete == null)
                return;

            showToDelete.Delete();
            await uow.CommitChangesAsync();
        }

        public async Task<List<TrackDto>> GetTracksAsync(int showNumber)
        {
            using var uow = new UnitOfWork();
            var show = await LoadShowByOidAsync(uow, showNumber);
            if (show == null)
                return Enumerable.Empty<TrackDto>().ToList();

            var results = new List<TrackDto>();
            foreach (Track track in show.TracksCollection)
                results.Add(track.ToTrackDto());

            return results;
        }

        private async Task<Show> LoadShowByOidAsync(UnitOfWork uow, int oid)
            => await uow.GetObjectByKeyAsync<Show>(oid);

        private void AddTracks(UnitOfWork uow, Show show, IList<TrackDto> tracks)
        {

			foreach (TrackDto trackDto in tracks)
			{
				var track = new Track(uow)
				{
					Artist = trackDto.Artist,
					TrackNumber = trackDto.TrackNumber,
					Name = trackDto.Name
				};

				show.TracksCollection.Add(track);
			}
		}
    }
}
