using Kbvm.KelvinsCollections.Models.Interfaces;
using System;

namespace Kbvm.KelvinsCollections.Models.Models.Vinyl.Dto
{
    public class AlbumDto
    {
		public int Oid { get; set; }
		public string Title { get; set; }
        public IAlbumMetaData Artist {  get; set; }
		public IAlbumMetaData Genre { get; set; }
		public int DiscCount { get; set; }
        public SleeveType SleeveType { get; set; }
        public string Notes { get; set; }
        public IEnumerable<TrackDto> Tracks { get; set; }

        public string Display => $"{Artist.Name}: {Title}";

        public AlbumDto()
        {
            Oid = -1;
            Title = string.Empty;
            Artist = new AlbumMetaData();
            Genre = new AlbumMetaData();
            DiscCount = 1;
            SleeveType = SleeveType.Single;
            Notes = string.Empty;
            Tracks = new List<TrackDto>();
		}
    }
}
