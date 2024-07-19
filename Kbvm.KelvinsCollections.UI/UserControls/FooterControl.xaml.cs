using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

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
