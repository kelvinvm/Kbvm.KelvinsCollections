using Kbvm.KelvinsCollections.Models.Models.DrDemento.Dto;
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

namespace Kbvm.KelvinsCollections.UI.Views.UserControls
{
	public partial class DrDementoUserControl : UserControl
	{
		private readonly DrDementoViewModel _vmDrDemento;

		public DrDementoUserControl(DrDementoViewModel vmDrDemento)
		{
			InitializeComponent();

			_vmDrDemento = vmDrDemento ?? throw new ArgumentNullException(nameof(vmDrDemento));
		}

		private void DrDementoUserControl_Load(object sender, EventArgs e)
		{
			drDementoViewModelBindingSource.DataSource = _vmDrDemento;
			_vmDrDemento.LoadCommand.Execute(null);
		}

		// ToDo: Why do I have to do this? Why doesn't the listbox data binding work?
		private void lstShows_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstShows.SelectedItem is ShowDto selectedShow)
				_vmDrDemento.SelectedShow = selectedShow;
		}
	}
}
