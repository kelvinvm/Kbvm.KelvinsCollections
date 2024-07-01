namespace Kbvm.KelvinsCollections.UI.Views.Forms
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tabs = new TabControl();
			tabDrDemento = new TabPage();
			tabVinyl = new TabPage();
			tabs.SuspendLayout();
			SuspendLayout();
			// 
			// tabs
			// 
			tabs.Controls.Add(tabDrDemento);
			tabs.Controls.Add(tabVinyl);
			tabs.Dock = DockStyle.Fill;
			tabs.Location = new Point(0, 0);
			tabs.Name = "tabs";
			tabs.SelectedIndex = 0;
			tabs.Size = new Size(483, 833);
			tabs.TabIndex = 0;
			// 
			// tabDrDemento
			// 
			tabDrDemento.Location = new Point(4, 24);
			tabDrDemento.Name = "tabDrDemento";
			tabDrDemento.Padding = new Padding(3);
			tabDrDemento.Size = new Size(475, 805);
			tabDrDemento.TabIndex = 0;
			tabDrDemento.Text = "Dr. Demento";
			tabDrDemento.UseVisualStyleBackColor = true;
			// 
			// tabVinyl
			// 
			tabVinyl.Location = new Point(4, 24);
			tabVinyl.Name = "tabVinyl";
			tabVinyl.Padding = new Padding(3);
			tabVinyl.Size = new Size(475, 754);
			tabVinyl.TabIndex = 1;
			tabVinyl.Text = "Vinyl";
			tabVinyl.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(483, 833);
			Controls.Add(tabs);
			Name = "MainForm";
			Text = "Kelvin's Collections";
			Load += MainForm_Load;
			tabs.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TabControl tabs;
		private TabPage tabDrDemento;
		private TabPage tabVinyl;
	}
}