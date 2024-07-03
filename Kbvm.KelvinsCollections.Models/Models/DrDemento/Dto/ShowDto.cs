using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kbvm.KelvinsCollections.Models.Models.DrDemento.Dto
{
    public class ShowDto
    {
		public int Oid { get; set; }
		public int ShowNumber { get; set; }
		public DateTime BroadcastDate { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string FlacFileName { get; set; }
		public IList<TrackDto> Tracks { get; set; }
		public string ShowNumberTitle => $"{ShowNumber}: {Title}";

		public ShowDto()
		{
			Oid = -1;
			Title = string.Empty;
			Description = string.Empty;
			FlacFileName = string.Empty;
			Tracks = [];
		}
	}
}
