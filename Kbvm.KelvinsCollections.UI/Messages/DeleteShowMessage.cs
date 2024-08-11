using CommunityToolkit.Mvvm.Messaging.Messages;
using Kbvm.KelvinsCollections.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kbvm.KelvinsCollections.UI.Messages
{
    public class DeleteShowMessage : RequestMessage<ShowViewModel>
    {
		public int ShowOid { get; set; }

		public DeleteShowMessage(int showOid)
		{
			ShowOid = showOid;
		}
	}
}
