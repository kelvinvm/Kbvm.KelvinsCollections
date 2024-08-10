using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.Common.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
	public class CollectionAssociationAttribute : Attribute
	{
		public string AssociationName { get; set; }
		public string CollectionType { get; set; }

		public CollectionAssociationAttribute(string associationName, string collectionType)
		{
			AssociationName = associationName;
			CollectionType = collectionType;
		}
	}
}
