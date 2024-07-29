using Metalama.Extensions.DependencyInjection;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Eligibility;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kbvm.KelvinsCollections.Common.Aspects
{
	public class LogExceptionAttribute : Attribute, IAspect<IMethod>
	{
		private const string Start = "ENTER - ";
		private const string End = "LEAVE - ";
		private const string Error = "ERROR - ";

		[IntroduceDependency]
		private readonly ILogger _logger;

		public void BuildAspect(IAspectBuilder<IMethod> builder)
		{
			builder.Advice.Override(builder.Target, nameof(this.OverrideMethod));
		}

		public void BuildEligibility(IEligibilityBuilder<IMethod> builder)
		{
			builder.AddRule(EligibilityRuleFactory.GetAdviceEligibilityRule(AdviceKind.OverrideMethod));
			builder.MustNotBeStatic();
		}

		[Template]
		public dynamic? OverrideMethod()
		{
			try
			{
				return meta.Proceed();
			}
			catch (Exception ex)
			{
				using (var guard = LoggingRecursionGuard.Begin())
				{
					if (guard.CanLog)
						_logger.LogTrace(
							$"{Error}" +
							$"{meta.Target.Type.ToDisplayString(CodeDisplayFormat.MinimallyQualified),-25}" +
							$"{meta.Target.Method.Name,-25} "+
							$"{ex}");
				}

				throw;
			}
		}


	}
}
