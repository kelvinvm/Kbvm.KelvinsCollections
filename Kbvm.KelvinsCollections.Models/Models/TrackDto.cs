using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.Models.Models
{
	public class TrackDto
	{
		public int Oid { get; set; } = -1;
		public string Name { get; set; } = string.Empty;
		public int TrackNumber { get; set; } = 0;
		public string Artist { get; set; } = string.Empty;

		public TrackDto()
		{
		}

		public TrackDto(string name, int trackNumber, string artist)
		{
			Name = name;
			TrackNumber = trackNumber;
			Artist = artist;
		}
	}
}
