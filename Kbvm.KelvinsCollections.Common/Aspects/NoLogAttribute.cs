using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kbvm.KelvinsCollections.Common.Aspects
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
	public sealed class NoLogAttribute : Attribute
	{
	}
}
