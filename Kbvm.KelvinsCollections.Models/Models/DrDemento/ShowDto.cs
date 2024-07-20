namespace Kbvm.KelvinsCollections.Models.Models.DrDemento
{
	public class ShowDto
	{
		public int Oid { get; set; }
		public int ShowNumber { get; set; } = -1;
		public DateTime BroadcastDate { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public List<TrackDto> Tracks { get; set; } = [];
	}
}
