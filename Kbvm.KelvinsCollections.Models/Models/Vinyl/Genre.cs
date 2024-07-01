using DevExpress.Xpo;
using Kbvm.KelvinsCollections.Models.Interfaces;
using System;

namespace Kbvm.KelvinsCollections.Models.Models.Vinyl
{
    public class Genre : XPObject, IAlbumMetaData
	{
        private string _genreName;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => _genreName;
            set => SetPropertyValue(nameof(Genre), ref _genreName, value);
        }

        [Association("Genre-Albums")]
        public XPCollection<Album> Albums
        {
            get
            {
                return GetCollection<Album>(nameof(Albums));
            }
        }

        public Genre(Session session) : base(session)
        {
            _genreName = string.Empty;
        }

		public Genre()
		{
			// This will throw a Session is null error if called, but must be defined
			// for me to use activator to call the other constructor
			_genreName = string.Empty;
		}
	}
}
