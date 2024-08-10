using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kbvm.KelvinsCollections.Common.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
	public class SizeAttribute : Attribute
    {
		public int Size { get; set; }

		public SizeAttribute(int size)
		{
			Size = size;
		}
	}
}
