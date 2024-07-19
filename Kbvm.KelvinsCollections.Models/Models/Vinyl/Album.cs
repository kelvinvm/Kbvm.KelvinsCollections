using DevExpress.Xpo;
using System;

namespace Kbvm.KelvinsCollections.Models.Models.Vinyl
{
    public class Album : XPObject
    {
		private string _title;
		private Artist _artist = default!;
		private Genre _genre = default!;
		private int _discCount;
		private SleeveType _sleeveType;
		private string _notes;

		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string Title
		{
			get => _title;
			set => SetPropertyValue(nameof(Title), ref _title, value);
		}

		public int DiscCount
		{
			get => _discCount;
			set => SetPropertyValue(nameof(DiscCount), ref _discCount, value);
		}

		public SleeveType SleeveType
		{
			get => _sleeveType;
			set => SetPropertyValue(nameof(SleeveType), ref _sleeveType, value);
		}

		[Size(1024)]
		public string Notes
		{
			get => _notes;
			set => SetPropertyValue(nameof(Notes), ref _notes, value);
		}

		[Association("Genre-Albums")]
		public Genre Genre
		{
			get => _genre;
			set => SetPropertyValue(nameof(Genre), ref _genre, value);
		}
		
		[Association("Artist-Albums")]
		public Artist Artist
		{
			get => _artist;
			set => SetPropertyValue(nameof(Artist), ref _artist, value);
		}

			[Aggregated, Association("Album-Tracks")]
		public XPCollection<RecordTrack> Tracks
		{
			get
			{
				return GetCollection<RecordTrack>(nameof(Tracks));
			}
		}

		public Album(Session session) : base(session)
        {
            _title = string.Empty;
            _sleeveType = SleeveType.Single;
            _notes = string.Empty;
        }
    }
}
