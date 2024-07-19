using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.Repository.Extensions
{
	public static class ShowNumberExtensions
	{
		public static string ToDiscNumber(this int showNumber)
		{
			return showNumber.ToString().Substring(0, 2);
		}

		public static string ToTrackNumber(this int showNumber)
		{
			return showNumber.ToString().Substring(2);
		}
	}
}
