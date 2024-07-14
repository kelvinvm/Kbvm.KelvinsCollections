using DevExpress.Xpo;

namespace Kbvm.KelvinsCollections.Models.Models.DrDemento.Xpo
{
    public class Track(Session session) : XPObject(session)
    {
        private string _artist = string.Empty;
        private int _trackNumber;
        private string _name = string.Empty;

        [Size(256)]
        public string Name
        {
            get => _name;
            set => SetPropertyValue(nameof(Name), ref _name, value);
        }

        public int TrackNumber
        {
            get => _trackNumber;
            set => SetPropertyValue(nameof(TrackNumber), ref _trackNumber, value);
        }

        public string Artist
        {
            get => _artist;
            set => SetPropertyValue(nameof(Artist), ref _artist, value);
        }

        private Show _show = default!;
        [Association("ShowTrack")]
        public Show Show
        {
            get { return _show; }
            set { SetPropertyValue(nameof(Show), ref _show, value); }
        }
	}
}
