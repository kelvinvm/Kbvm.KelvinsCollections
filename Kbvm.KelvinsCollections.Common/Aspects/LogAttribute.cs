using Metalama.Framework.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Kbvm.KelvinsCollections.Common.Aspects
{
	public class LogAttribute : OverrideMethodAspect
	{
		public override dynamic? OverrideMethod()
		{
			Debugger.Log(0, "Logging Aspect", $"{meta.Target.Method} started.");

			try
			{
				var result = meta.Proceed();
				Debugger.Log(0, "Logging Aspect", $"{meta.Target.Method} succeeded.\n");
				return result;
			}
			catch (Exception ex)
			{
				Debugger.Log(0, "Logging Aspect", $"{meta.Target.Method} failed.\n{ex.Message}\n\n");
				throw;
			}
		}
	}
}
