using DevExpress.Xpo;
using System;

namespace Kbvm.KelvinsCollections.Models.Models.Vinyl
{
    public class RecordTrack : XPObject
    {
		private int _trackNumber;
		private Artist _artist = default!;
		private Album _album = default!;
		private string _name = string.Empty;

		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string Name
		{
			get => _name;
			set => SetPropertyValue(nameof(Name), ref _name, value);
		}

		[Association("Artist-RecordTracks")]
		public Artist Artist
		{
			get => _artist;
			set => SetPropertyValue(nameof(Artist), ref _artist, value);
		}

		public int TrackNumber
		{
			get => _trackNumber;
			set => SetPropertyValue(nameof(TrackNumber), ref _trackNumber, value);
		}

		[Association("Album-Tracks")]
        public Album Album
        {
            get => _album;
            set => SetPropertyValue(nameof(Album), ref _album, value);
        }

        public RecordTrack(Session session) : base(session)
        {
        }
    }
}
