using CommunityToolkit.Mvvm.Messaging.Messages;
using Kbvm.KelvinsCollections.UI.ViewModels;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI.Messages
{
	public class DeleteTrackMessage : RequestMessage<ShowViewModel>
	{
		public int TrackOid { get; set; }

		public DeleteTrackMessage(int showOid)
		{
			TrackOid = showOid;
		}
	}
}
