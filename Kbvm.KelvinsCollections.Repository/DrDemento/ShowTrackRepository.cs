using DevExpress.Xpo;
using Kbvm.KelvinsCollections.Models.Models;
using Kbvm.KelvinsCollections.Models.Models.DrDemento.Dto;
using Kbvm.KelvinsCollections.Models.Models.DrDemento.Xpo;
using Kbvm.KelvinsCollections.Repository.Interfaces;
using Kbvm.KelvinsCollections.Repository.Extensions;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.Repository.DrDemento
{

    public class ShowTrackRepository : IShowTrackRepository
    {
		//private readonly ITrackHandler _trackHandler;

		//public ShowTrackRepository(ITrackHandler trackHandler)
		//{
		//    _trackHandler = trackHandler ?? throw new ArgumentNullException(nameof(trackHandler));
		//}

		public ShowTrackRepository()
		{
		}

		public async Task SaveNewShowAsync(ShowDto showDto)
        {
            using var uow = new UnitOfWork();

            //var tracks = _trackHandler.GetTracks(showDto.ShowNotes);
            //var show = await LoadShowByShowNumberAsync(uow, showDto.ShowNumber);

            //var newShow = show == null
            //    ? showDto.ToNewShow(uow, tracks)
            //    : show.ToUpdatedShow(showDto);

            await uow.CommitChangesAsync();
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

        public async Task DeleteShowAsync(int showNumber)
        {
            using var uow = new UnitOfWork();
            var showToDelete = await LoadShowByShowNumberAsync(uow, showNumber);
            if (showToDelete == null)
                return;

            showToDelete.Delete();
            await uow.CommitChangesAsync();
        }

        public async Task<List<TrackDto>> GetTracksAsync(int showNumber)
        {
            using var uow = new UnitOfWork();
            var show = await LoadShowByShowNumberAsync(uow, showNumber);
            if (show == null)
                return Enumerable.Empty<TrackDto>().ToList();

            var results = new List<TrackDto>();
            foreach (Track track in show.TracksCollection)
                results.Add(track.ToTrackDto());

            return results;
        }

        public async Task<List<ShowTrackDto>> GetAllShowTracksAsync()
        {
            using var uow = new UnitOfWork();
            var shows = await uow.Query<Show>().ToListAsync();

            var result = new List<ShowTrackDto>();

            foreach (Show show in shows)
                foreach (Track track in show.TracksCollection)
                    result.Add(new ShowTrackDto(show.Title, show.ShowNumber, track.Artist, track.Name));

            return result;
        }


        private async Task<Show> LoadShowByShowNumberAsync(UnitOfWork uow, int showNumber)
            => await uow.Query<Show>().FirstOrDefaultAsync(s => s.ShowNumber == showNumber);
    }
}
