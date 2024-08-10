using Kbvm.KelvinsCollections.Common.Aspects;
using Kbvm.KelvinsCollections.Models.Interfaces;
using Kbvm.KelvinsCollections.Common.Attributes;
using DevExpress.Xpo;


namespace Kbvm.KelvinsCollections.Models.Models.DrDemento
{
	public partial class ShowDto : IHaveKey
	{
		public int Oid { get; set; }
		public int ShowNumber { get; set; } = -1;
		public DateTime BroadcastDate { get; set; }
		
		[Common.Attributes.Size(63)]
		public string Title { get; set; } = string.Empty;
		
		[Common.Attributes.Size(2048)]
		public string Description { get; set; } = string.Empty;

		[CollectionAssociation("ShowTrack", "Kbvm.KelvinsCollections.Models.Models.DrDemento.Track")]
		public List<TrackDto> Tracks { get; set; } = [];

		public override string ToString()
		{
			return $"{ShowNumber}-{Title}";
		}
	}
}
