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
		private const string End = "LEAVE - ";
		private const string Error = "ERROR - ";

		//[IntroduceDependency]
		//private readonly ILogger _logger;

		private List<string> MethodsToSkip = ["ToString", "Connect", "GetBindingConnector"];
		private List<string> EndsWithMethodsToSkip = ["Changing"];

		public void BuildAspect(IAspectBuilder<IMethod> builder)
		{
			if (builder.Target.DeclaringType.Attributes.OfAttributeType(typeof(NoLogAttribute)).Any())
				builder.SkipAspect();
			else if (MethodsToSkip.Contains(builder.Target.Name))
				builder.SkipAspect();
			else if (EndsWithMethodsToSkip.Any(builder.Target.Name.EndsWith))
				builder.SkipAspect();
			else if (builder.Target.Name.EndsWith("Changed"))
			{
				if (!(builder.Target.Attributes.OfAttributeType(typeof(NoLogAttribute)).Any()))
				{
					builder.Advice.Override(builder.Target, nameof(this.OverrideMethodWithBeforeAfter));
				}
				else
				{
					builder.SkipAspect();
				}
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
				return meta.Proceed();
			}
			finally
			{
				sw.Stop();

				using (var guard = LoggingRecursionGuard.Begin())
				{
					if (guard.CanLog)
						Debug.WriteLine(
							$"{End}" +
							$"{meta.Target.Type.ToDisplayString(CodeDisplayFormat.MinimallyQualified),-25}" +
							$"{meta.Target.Method.Name,-25} {sw.ElapsedMilliseconds,10} ms");
				}
			}
		}

		[Template]
		public dynamic? OverrideMethodWithBeforeAfter()
		{
			var sw = Stopwatch.StartNew();
			try
			{
				return meta.Proceed();
			}
			finally
			{
				sw.Stop();

				using (var guard = LoggingRecursionGuard.Begin())
				{
					if (meta.Target.Parameters.Count != 2)
					{
						if (!guard.CanLog)
							Debug.WriteLine($"***  {meta.Target.Method.Name} does not have 2 parameters. ****");
					}
					else
					{
						string paramOld = "";
						string paramNew = "";

						//bool oldIsNullable = ((INamedType)meta.Target.Parameters[0].Type).IsReferenceType ?? false;
						//bool newIsNullable = ((INamedType)meta.Target.Parameters[0].Type).IsReferenceType ?? false;


						//if (oldIsNullable && meta.Target.Parameters[0].Value is null)
						//	paramOld = "null";
						//else paramOld = meta.Target.Parameters[0].DeclarationKind == DeclarationKind.Indexer
						//	? "List"
						//	: (string)meta.Target.Parameters[0].Value.ToString();

						//if (newIsNullable && meta.Target.Parameters[1].Value is null)
						//	paramNew = "null";
						//else paramNew = meta.Target.Parameters[1].DeclarationKind == DeclarationKind.Indexer
						//? "List"
						//: (string)meta.Target.Parameters[1].Value.ToString();

						if (guard.CanLog)
							Debug.WriteLine(
								$"{Start}" +
								$"{meta.Target.Type.ToDisplayString(CodeDisplayFormat.MinimallyQualified),-25}" +
								$"{meta.Target.Method.Name,-25} +" +
								$"Old: {paramOld,-30}" +
								$"New: {paramNew,-30} " +
								$" {sw.ElapsedMilliseconds,10} ms");
					}
				}
			}
		}
	}
}
