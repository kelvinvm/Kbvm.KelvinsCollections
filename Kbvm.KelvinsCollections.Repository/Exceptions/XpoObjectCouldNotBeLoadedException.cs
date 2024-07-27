using DevExpress.Xpo;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.Repository.Exceptions
{
	public class XpoObjectCouldNotBeLoadedException : Exception
	{
		public Type XpObjectType { get; set; }
		public int Oid { get; set; }

		public XpoObjectCouldNotBeLoadedException(Type xpObjectType, int oid, Exception? innerException = null) 
			: base(FormatMessage(xpObjectType, oid), innerException)
		{
			XpObjectType = xpObjectType;
			Oid = oid;
		}

		private static string FormatMessage(Type xpType, int oid) 
			=> $"Could not load Key {oid} for type {xpType.Name}";
	}
}
