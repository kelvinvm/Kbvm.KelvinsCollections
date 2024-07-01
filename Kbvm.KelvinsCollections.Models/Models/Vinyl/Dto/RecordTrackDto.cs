using Kbvm.KelvinsCollections.Models.Interfaces;
using System;

namespace Kbvm.KelvinsCollections.Models.Models.Vinyl.Dto
{
	public class RecordTrackDto
	{
		public int Oid { get; set; }
		public IAlbumMetaData Artist { get; set; }
		public string Name { get; set; }
		public int TrackNumber { get; set; }

		public RecordTrackDto()
		{
			Oid = -1;
			Artist = new AlbumMetaData();
			Name = string.Empty;
		}
	}
}
