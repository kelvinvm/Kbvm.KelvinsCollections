using DevExpress.Xpo;
using Kbvm.KelvinsCollections.Models.Interfaces;
using System;

namespace Kbvm.KelvinsCollections.Models.Models.Vinyl
{
    public class Artist : XPObject, IAlbumMetaData
	{
        private string _artistName;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => _artistName;
            set => SetPropertyValue(nameof(Name), ref _artistName, value);
        }

        [Association("Artist-Albums")]
        public XPCollection<Album> Albums
        {
            get
            {
                return GetCollection<Album>(nameof(Albums));
            }
        }

        [Association("Artist-RecordTracks")]
        public XPCollection<RecordTrack> RecordTracks
        {
            get
            {
                return GetCollection<RecordTrack>(nameof(RecordTracks));
            }
        }

		public Artist(Session session) : base(session)
        {
            _artistName = string.Empty;
        }

		public Artist()
		{
            // This will throw a Session is null error if called, but must be defined
            // for me to use activator to call the other constructor
            _artistName = string.Empty;
		}
	}
}
