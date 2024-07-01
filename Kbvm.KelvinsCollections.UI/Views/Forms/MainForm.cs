using Kbvm.KelvinsCollections.UI.Views.UserControls;
using Kbvm.KelvinsCollections.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kbvm.KelvinsCollections.UI.Views.Forms
{
	public partial class MainForm : Form
	{
		private readonly DrDementoUserControl _ucDrDemento;
		private readonly VinylUserControl _ucVinyl;


		public MainForm(DrDementoUserControl ucDrDemento, VinylUserControl ucVinyl, DrDementoViewModel vmDrDemento)
		{
			InitializeComponent();

			_ucDrDemento = ucDrDemento;
			_ucVinyl = ucVinyl ?? throw new ArgumentNullException(nameof(ucVinyl));
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			tabs.TabPages[0].Controls.Add(_ucDrDemento);
			tabs.TabPages[1].Controls.Add(_ucVinyl);

			tabs.TabIndex = 0;
			tabs.SelectedIndex = 0;
		}
	}
}
