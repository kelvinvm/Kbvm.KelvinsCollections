using DevExpress.Xpo;

namespace Kbvm.KelvinsCollections.Models.Models.DrDemento.Xpo
{
    public class Show(Session session) : XPObject(session)
    {
        private DateTime _broadcastDate;
        private int _showNumber;
        private string _title = string.Empty;
        private string _description = string.Empty;

        public int ShowNumber
        {
            get => _showNumber;
            set => SetPropertyValue(nameof(ShowNumber), ref _showNumber, value);
        }

        public DateTime BroadcastDate
        {
            get => _broadcastDate;
            set => SetPropertyValue(nameof(BroadcastDate), ref _broadcastDate, value);
        }

        [Size(63)]
        public string Title
        {
            get => _title;
            set => SetPropertyValue(nameof(Title), ref _title, value);
        }

        [Size(2048)]
        public string Description
        {
            get => _description;
            set => SetPropertyValue(nameof(Description), ref _description, value);
        }

        [Association("ShowTrack")]
        public XPCollection<Track> TracksCollection
        {
            get { return GetCollection<Track>(nameof(TracksCollection)); }
        }
	}
}
