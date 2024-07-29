using Kbvm.KelvinsCollections.Common.Aspects;
using Metalama.Framework.Code;
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

			//amender.Outbound.SelectMany(t 
			//	=> t.GlobalNamespace
			//		.DescendantsAndSelf()
			//		.Where(z => 
			//			!z.FullName.EndsWith("Extensions", StringComparison.Ordinal) &&
			//			!z.FullName.EndsWith("Exceptions", StringComparison.Ordinal)
			//		))
			//	.SelectMany(ns => ns.Types.SelectMany(t => t.Methods))
			//	.AddAspectIfEligible<LogMethodTimeAttribute>();
		}
	}
}
