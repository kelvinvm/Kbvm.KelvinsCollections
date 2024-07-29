using Metalama.Extensions.DependencyInjection;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Code.SyntaxBuilders;
using Metalama.Framework.CodeFixes;
using Metalama.Framework.Eligibility;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;

#pragma warning disable CS8618
#pragma warning disable CA2254

namespace Kbvm.KelvinsCollections.Common.Aspects
{
	public class LogMethodTimeAttribute : Attribute, IAspect<IMethod>
	{
		private const string Start = "ENTER - ";
		private const string End =   "LEAVE - ";
		private const string Error = "ERROR - ";
		
		[IntroduceDependency]
		private readonly ILogger _logger;

		public void BuildAspect(IAspectBuilder<IMethod> builder)
		{
			if (builder.Target.DeclaringType.Attributes.OfAttributeType(typeof(NoLogAttribute)).Any())
			{
				builder.SkipAspect();
			}
			else
			{
				if (!(builder.Target.Attributes.OfAttributeType(typeof(NoLogAttribute)).Any()))
				{
					builder.Advice.Override(builder.Target, nameof(this.OverrideMethod));
				}
				else
				{
					builder.SkipAspect();
				}
			}
		}

		public void BuildEligibility(IEligibilityBuilder<IMethod> builder)
		{
			builder.AddRule(EligibilityRuleFactory.GetAdviceEligibilityRule(AdviceKind.OverrideMethod));
			builder.MustNotBeStatic();
		}

		[Template]
		public dynamic? OverrideMethod()
		{
			var sw = Stopwatch.StartNew();
			try
			{
				using (var guard = LoggingRecursionGuard.Begin())
				{
					if (guard.CanLog)
						_logger.LogTrace(
							$"{Start}" +
							$"{meta.Target.Type.ToDisplayString(CodeDisplayFormat.MinimallyQualified),-25}" +
							$"{meta.Target.Method.Name,-25} ");
				}

				return meta.Proceed();
			}
			finally
			{
				sw.Stop();

				using (var guard = LoggingRecursionGuard.Begin())
				{
					if (guard.CanLog)
						_logger.LogTrace(
							$"{End}" +
							$"{meta.Target.Type.ToDisplayString(CodeDisplayFormat.MinimallyQualified),-25}" +
							$"{meta.Target.Method.Name,-25} {sw.ElapsedMilliseconds,10} ms");
				}
			}
		}
	}
}
