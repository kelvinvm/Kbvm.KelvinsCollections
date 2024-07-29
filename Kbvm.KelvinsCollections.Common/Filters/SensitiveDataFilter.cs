using Kbvm.KelvinsCollections.Common.Aspects;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace Kbvm.KelvinsCollections.Common.Filters
{
	/// <summary>
	/// A sensitive data filter.
	/// </summary>
	///
	/// <remarks></remarks>

	[CompileTime]
	internal static class SensitiveDataFilter
	{
		#region Constants
		const string fallback = "password,pwd,secret";

		#endregion

		#region Public Methods
		/// <summary>
		/// Query if 'parameter' has sensitive parameters.
		/// </summary>
		///
		/// <remarks></remarks>
		///
		/// <param name="parameter">The parameter.</param>
		/// <param name="sensitiveParameterNames">List of names of the sensitive parameters.</param>
		///
		/// <returns>True if sensitive parameters, false if not.</returns>

		public static bool HasSensitiveParameters(IParameter parameter, string sensitiveParameterNames)
		{
			return false;
		}

		#endregion
	}
}