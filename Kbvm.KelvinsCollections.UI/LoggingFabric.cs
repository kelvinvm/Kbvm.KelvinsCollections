using Kbvm.KelvinsCollections.Common.Aspects;
using Metalama.Framework.Fabrics;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI
{
	public class LoggingFabric : ProjectFabric
	{
		public override void AmendProject(IProjectAmender amender)
		{
			amender
				.SelectMany(p => p.Types)
				.SelectMany(t => t.Methods)
				.AddAspectIfEligible<LogMethodTimeAttribute>();
		}
	}
}
