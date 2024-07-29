using Kbvm.KelvinsCollections.Models.Interfaces;

namespace Kbvm.KelvinsCollections.Models.Models.DrDemento
{
	public class TrackDto : IHaveKey 
	{
		public int Oid { get; set; }
		public string Name { get; set; } = string.Empty;
		public int TrackNumber { get; set; } = -1;
		public string Artist { get; set; } = string.Empty;

		public override string ToString()
		{
			return $"{Name.Substring(0, Math.Min(10, Name.Length)),-10}";
		}
	}
}
