using Kbvm.KelvinsCollections.Common.Aspects;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Kbvm.KelvinsCollections.UI.UserControls
{
	public sealed partial class FooterControl : UserControl
	{
		public string CopyrightStatement => $"{"\u00a9"} Copyright {DateTime.Now.Year} All Rights Reserved";
		public string Version => "Version 1.0 Alpha";

		public FooterControl()
		{
			this.InitializeComponent();
		}
	}
}
