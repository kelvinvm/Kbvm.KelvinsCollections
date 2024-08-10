//using Metalama.Framework.Advising;
//using Metalama.Framework.Aspects;
//using Metalama.Framework.Code;
//using Metalama.Framework.Code.DeclarationBuilders;
//using Metalama.Framework.Code.SyntaxBuilders;
//using System;
//using System.ComponentModel;
//using System.Linq;
//using System.Reflection.Emit;
//using System.Reflection.Metadata;
//using System.Runtime.InteropServices;

//namespace Kbvm.KelvinsCollections.Common.Aspects
//{
//	public class XpoObjectAttribute : TypeAspect
//	{
//		public override void BuildAspect(IAspectBuilder<INamedType> builder)
//		{
//			base.BuildAspect(builder);

//			//IAdviser<INamespace> nsAdviser = builder
//			//	.With(builder.Target.Compilation)
//			//	.WithNamespace(builder.Target.ContainingNamespace.FullName);

//			var xpoClassName = builder.Target.Name.Replace("Dto", "") + "Xpo";

//			var classBuilder = builder.IntroduceClass(xpoClassName, OverrideStrategy.Override,
//				buildType: type =>
//				{
//					type.Accessibility = Accessibility.Public;
//					type.BaseType = (INamedType)TypeFactory.GetType(typeof(DevExpress.Xpo.XPObject));
//				});

//			var sessionType = (INamedType)TypeFactory.GetType(typeof(DevExpress.Xpo.Session));

//			classBuilder.IntroduceConstructor(nameof(XpoConstructor),
//				buildConstructor: bldr =>
//				{
//					bldr.InitializerKind = ConstructorInitializerKind.Base;
//					bldr.AddInitializerArgument(bldr.Parameters[0]);
//				},
//				args: new { T = sessionType });

//			foreach (var member in builder.Target.AllProperties)
//			{
//				if (member.Name == "Oid")
//					continue;


//				var sizeAttributeType = (INamedType)TypeFactory.GetType(typeof(Kbvm.KelvinsCollections.Common.Attributes.SizeAttribute));
//				IAttribute? a = member.Attributes.FirstOrDefault(a => a.Type == sizeAttributeType);

//				if (member.Attributes.OfAttributeType(typeof(Attributes.SizeAttribute)).Any())
//				{
//					var camelCaseFieldName = AddBackingStore(classBuilder, member);
//					AddPropertyithSizeAttribute(classBuilder, member, camelCaseFieldName);
//				}
//				else if (member.Attributes.OfAttributeType(typeof(Attributes.CollectionAssociationAttribute)).Any())
//				{
//					AddCollectionPropertyWithAssociationAttribute(classBuilder, member);
//				}
//				else
//				{
//					var camelCaseFieldName = AddBackingStore(classBuilder, member);
//					AddUnAttributedProperty(classBuilder, member, camelCaseFieldName);
//				}

//			}
//		}

//		private static string AddBackingStore(IClassIntroductionAdviceResult classBuilder, IProperty member)
//		{
//			var camelCaseFieldName = char.ToLower(member.Name[0]) + member.Name.Substring(1);

//			classBuilder.IntroduceField(
//				nameof(BackingStoreField),
//				buildField: fld =>
//				{
//					fld.Name = $"_{camelCaseFieldName}";
//					fld.Type = member.Type;
//				});

//			return camelCaseFieldName;
//		}

//		private static void AddPropertyithSizeAttribute(IClassIntroductionAdviceResult classBuilder, IProperty member, string camelCaseFieldName)
//		{
//			IAttribute attrib = member.Attributes.OfAttributeType(typeof(Attributes.SizeAttribute)).First();
//			var size = (int?)attrib.ConstructorArguments[0].Value;
//			if (size == null)
//				throw new Exception("Size Attribute must have a size parameter."); // Shouldn't hap

//			var xpoSizeAttribute = AttributeConstruction.Create(
//				typeof(DevExpress.Xpo.SizeAttribute),
//				new object[] { size });

//			classBuilder.IntroduceProperty(
//				nameof(XpoProperty),
//				tags: new { member, camelCaseFieldName },
//				buildProperty: p =>
//				{
//					p.Name = member.Name;
//					p.Type = member.Type;
//					p.AddAttribute(xpoSizeAttribute);
//				});
//		}

//		private void AddCollectionPropertyWithAssociationAttribute(IClassIntroductionAdviceResult classBuilder, IProperty member)
//		{
//			IAttribute attrib = member.Attributes.OfAttributeType(typeof(Attributes.CollectionAssociationAttribute)).First();
//			var associationName = (string?)attrib.ConstructorArguments[0].Value!;
//			var collectionTypeName = (string?)attrib.ConstructorArguments[1].Value!;

//			var xpoColType = (INamedType)TypeFactory.GetType(typeof(DevExpress.Xpo.XPCollection<>));
//			var trackType = (INamedType)TypeFactory.GetType(collectionTypeName);

//			var xpoColGen = xpoColType.WithTypeArguments(trackType);
//					
//			if (string.IsNullOrEmpty(associationName))
//					throw new Exception("Association Name can not be null");

//			var xpoAssociationAttribute = AttributeConstruction.Create(
//				typeof(DevExpress.Xpo.AssociationAttribute),
//				new object[] { associationName });

//			classBuilder.IntroduceProperty(
//				nameof(XpoCollectionAssociationProperty),
//				tags: new { member, collectionTypeName },
//				buildProperty: p =>
//				{
//					p.Name = member.Name;
//					p.Type = xpoColGen;
//					p.AddAttribute(xpoAssociationAttribute);
//				});
//		}

//		private static void AddUnAttributedProperty(IClassIntroductionAdviceResult classBuilder, IProperty member, string camelCaseFieldName)
//		{
//			classBuilder.IntroduceProperty(
//					nameof(XpoProperty),
//					tags: new { member, camelCaseFieldName },
//					buildProperty: p =>
//					{
//						p.Name = member.Name;
//						p.Type = member.Type;
//					});
//		}

//		[Template]
//		public void XpoConstructor<[CompileTime] T>(T session)
//		{
//		}

//		[Template]
//		public dynamic XpoProperty
//		{
//			get => ExpressionFactory.Parse($"_{meta.Tags["camelCaseFieldName"]}").Value!;
//			set
//			{
//				IProperty member = (IProperty)meta.Tags["member"]!;
//				var ccName = (string)meta.Tags["camelCaseFieldName"]!;

//				var stmt = StatementFactory.Parse($"SetPropertyValue(nameof({member.Name}), ref _{ccName}, value);");
//				meta.InsertStatement(stmt);
//			}
//		}

//		[Template]
//		public dynamic XpoCollectionAssociationProperty
//		{
//			get
//			{
//				string collectionTypeName = (string)meta.Tags["collectionTypeName"]!;
//				IProperty member = (IProperty)meta.Tags["member"]!;

//				return meta.This.GetCollection<ExpressionFactory.Parse($"{collectionTypeName}").Value>(ExpressionFactory.Parse($"nameof({member.Name})").Value);
//			}
//		}

//		[Template]
//		private dynamic BackingStoreField;

//	}
//}
