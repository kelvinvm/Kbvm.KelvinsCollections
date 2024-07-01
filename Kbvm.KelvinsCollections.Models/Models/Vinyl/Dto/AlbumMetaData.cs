using Kbvm.KelvinsCollections.Models.Interfaces;
using System;

namespace Kbvm.KelvinsCollections.Models.Models.Vinyl.Dto
{
	public class AlbumMetaData : IAlbumMetaData
	{
		public int Oid { get; set; }
		public string Name { get; set; }

		public AlbumMetaData()
		{
			Oid = -1;
			Name = string.Empty;
		}
	}
}
