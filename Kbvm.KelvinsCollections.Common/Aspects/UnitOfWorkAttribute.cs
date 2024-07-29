//using DevExpress.Xpo;
//using Metalama.Framework.Advising;
//using Metalama.Framework.Aspects;
//using Metalama.Framework.Code;
//using Metalama.Framework.Eligibility;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Metadata.Ecma335;
//using System.Text;
//using System.Threading.Tasks;

//namespace Kbvm.KelvinsCollections.Common.Aspects
//{
//	public class UnitOfWorkAttribute : Attribute, IAspect<IMethod>
//	{
//		public void BuildAspect(IAspectBuilder<IMethod> builder)
//		{
//			builder.Advice.Override(builder.Target, nameof(this.OverrideAsyncMethod));
//		}

//		public void BuildEligibility(IEligibilityBuilder<IMethod> builder)
//		{
//			builder.AddRule(EligibilityRuleFactory.GetAdviceEligibilityRule(AdviceKind.OverrideMethod));
//			builder.MustNotBeStatic();
//			builder.Parameter("uow").Type().MustSatisfy(
//				t => t.IsNullable ?? false && t.DefaultValue == null && t.ToDisplayString(CodeDisplayFormat.MinimallyQualified) == "UnitOfWork",
//				t => $"{t} must be of type UnitOfWork");
//		}

//		[Template]
//		public async Task<dynamic?> OverrideAsyncMethod()
//		{
//			using var uow = new UnitOfWork();

//			// This should be safe because Eligibility guarentees a parameter named uow
//			var param = meta.Target.Parameters.First(p => p.Name == "uow");
//			param.Value = uow;

//			uow.BeginTransaction();

//			var result = await meta.ProceedAsync();

//			await uow.CommitChangesAsync();
//			
//			return result;
//		}

//	}
//}
