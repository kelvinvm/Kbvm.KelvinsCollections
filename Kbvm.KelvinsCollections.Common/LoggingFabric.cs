using Kbvm.KelvinsCollections.Common.Aspects;
using Metalama.Framework.Fabrics;
using Metalama.Framework.Code;
using System;
using System.Linq;


namespace Kbvm.KelvinsCollections.UI
{
	public class LoggingFabric : ProjectFabric
	{
		public override void AmendProject(IProjectAmender amender)
		{
			amender.Outbound
				.SelectMany(p => p.Types)
				.SelectMany(t => t.Methods)
				.AddAspectIfEligible<LogAttribute>();
		}
	}
}
