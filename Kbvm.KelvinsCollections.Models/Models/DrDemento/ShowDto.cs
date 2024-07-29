using Kbvm.KelvinsCollections.Models.Interfaces;

namespace Kbvm.KelvinsCollections.Models.Models.DrDemento
{
	public class ShowDto : IHaveKey
	{
		public int Oid { get; set; }
		public int ShowNumber { get; set; } = -1;
		public DateTime BroadcastDate { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public List<TrackDto> Tracks { get; set; } = [];

		public override string ToString()
		{
			return $"{ShowNumber}-{Title}";
		}
	}
}
