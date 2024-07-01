namespace Kbvm.KelvinsCollections.UI.Views.UserControls
{
	partial class VinylUserControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btnReports = new Button();
			btnClear = new Button();
			btnDelete = new Button();
			lstVinyl = new ListBox();
			label1 = new Label();
			txtTrackList = new TextBox();
			btnSave = new Button();
			txtNotes = new TextBox();
			txtTitle = new TextBox();
			lblDescription = new Label();
			lblTitle = new Label();
			label2 = new Label();
			label3 = new Label();
			cmbGenre = new ComboBox();
			label4 = new Label();
			numDiscCount = new NumericUpDown();
			rdoSingle = new RadioButton();
			rdoGatefold = new RadioButton();
			rdoBox = new RadioButton();
			cmbArtist = new ComboBox();
			txtOid = new TextBox();
			((System.ComponentModel.ISupportInitialize)numDiscCount).BeginInit();
			SuspendLayout();
			// 
			// btnReports
			// 
			btnReports.Location = new Point(368, 129);
			btnReports.Name = "btnReports";
			btnReports.Size = new Size(75, 23);
			btnReports.TabIndex = 10;
			btnReports.Text = "Reports";
			btnReports.UseVisualStyleBackColor = true;
			btnReports.Visible = false;
			// 
			// btnClear
			// 
			btnClear.Location = new Point(368, 41);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(75, 23);
			btnClear.TabIndex = 11;
			btnClear.Text = "Clear";
			btnClear.UseVisualStyleBackColor = true;
			// 
			// btnDelete
			// 
			btnDelete.Location = new Point(368, 12);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(75, 23);
			btnDelete.TabIndex = 12;
			btnDelete.Text = "Delete";
			btnDelete.UseVisualStyleBackColor = true;
			// 
			// lstVinyl
			// 
			lstVinyl.FormattingEnabled = true;
			lstVinyl.ItemHeight = 15;
			lstVinyl.Location = new Point(12, 12);
			lstVinyl.Name = "lstVinyl";
			lstVinyl.Size = new Size(350, 169);
			lstVinyl.TabIndex = 91;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(23, 378);
			label1.Name = "label1";
			label1.Size = new Size(55, 15);
			label1.TabIndex = 90;
			label1.Text = "Track List";
			// 
			// txtTrackList
			// 
			txtTrackList.Location = new Point(80, 378);
			txtTrackList.Multiline = true;
			txtTrackList.Name = "txtTrackList";
			txtTrackList.Size = new Size(363, 318);
			txtTrackList.TabIndex = 8;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(368, 158);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 9;
			btnSave.Text = "Save";
			btnSave.UseVisualStyleBackColor = true;
			// 
			// txtNotes
			// 
			txtNotes.Location = new Point(79, 327);
			txtNotes.Multiline = true;
			txtNotes.Name = "txtNotes";
			txtNotes.Size = new Size(363, 45);
			txtNotes.TabIndex = 7;
			// 
			// txtTitle
			// 
			txtTitle.Location = new Point(80, 213);
			txtTitle.Name = "txtTitle";
			txtTitle.Size = new Size(363, 23);
			txtTitle.TabIndex = 0;
			// 
			// lblDescription
			// 
			lblDescription.AutoSize = true;
			lblDescription.Location = new Point(34, 327);
			lblDescription.Name = "lblDescription";
			lblDescription.Size = new Size(38, 15);
			lblDescription.TabIndex = 83;
			lblDescription.Text = "Notes";
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Location = new Point(44, 217);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(29, 15);
			lblTitle.TabIndex = 82;
			lblTitle.Text = "Title";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(38, 246);
			label2.Name = "label2";
			label2.Size = new Size(35, 15);
			label2.TabIndex = 100;
			label2.Text = "Artist";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(35, 275);
			label3.Name = "label3";
			label3.Size = new Size(38, 15);
			label3.TabIndex = 102;
			label3.Text = "Genre";
			// 
			// cmbGenre
			// 
			cmbGenre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cmbGenre.AutoCompleteSource = AutoCompleteSource.ListItems;
			cmbGenre.FormattingEnabled = true;
			cmbGenre.Location = new Point(79, 271);
			cmbGenre.Name = "cmbGenre";
			cmbGenre.Size = new Size(363, 23);
			cmbGenre.TabIndex = 2;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(8, 304);
			label4.Name = "label4";
			label4.Size = new Size(65, 15);
			label4.TabIndex = 104;
			label4.Text = "Disc Count";
			// 
			// numDiscCount
			// 
			numDiscCount.Location = new Point(80, 300);
			numDiscCount.Name = "numDiscCount";
			numDiscCount.Size = new Size(39, 23);
			numDiscCount.TabIndex = 3;
			numDiscCount.TextAlign = HorizontalAlignment.Right;
			numDiscCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// rdoSingle
			// 
			rdoSingle.AutoSize = true;
			rdoSingle.Checked = true;
			rdoSingle.Location = new Point(152, 302);
			rdoSingle.Name = "rdoSingle";
			rdoSingle.Size = new Size(57, 19);
			rdoSingle.TabIndex = 4;
			rdoSingle.TabStop = true;
			rdoSingle.Text = "Single";
			rdoSingle.UseVisualStyleBackColor = true;
			// 
			// rdoGatefold
			// 
			rdoGatefold.AutoSize = true;
			rdoGatefold.Location = new Point(226, 302);
			rdoGatefold.Name = "rdoGatefold";
			rdoGatefold.Size = new Size(70, 19);
			rdoGatefold.TabIndex = 5;
			rdoGatefold.Text = "Gatefold";
			rdoGatefold.UseVisualStyleBackColor = true;
			// 
			// rdoBox
			// 
			rdoBox.AutoSize = true;
			rdoBox.Location = new Point(314, 302);
			rdoBox.Name = "rdoBox";
			rdoBox.Size = new Size(45, 19);
			rdoBox.TabIndex = 6;
			rdoBox.Text = "Box";
			rdoBox.UseVisualStyleBackColor = true;
			// 
			// cmbArtist
			// 
			cmbArtist.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cmbArtist.AutoCompleteSource = AutoCompleteSource.ListItems;
			cmbArtist.FormattingEnabled = true;
			cmbArtist.Location = new Point(79, 242);
			cmbArtist.Name = "cmbArtist";
			cmbArtist.Size = new Size(363, 23);
			cmbArtist.TabIndex = 1;
			// 
			// txtOid
			// 
			txtOid.Location = new Point(368, 100);
			txtOid.Name = "txtOid";
			txtOid.Size = new Size(75, 23);
			txtOid.TabIndex = 105;
			txtOid.Text = "-1";
			txtOid.Visible = false;
			// 
			// VinylUserControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(txtOid);
			Controls.Add(cmbArtist);
			Controls.Add(rdoBox);
			Controls.Add(rdoGatefold);
			Controls.Add(rdoSingle);
			Controls.Add(numDiscCount);
			Controls.Add(label4);
			Controls.Add(cmbGenre);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(btnReports);
			Controls.Add(btnClear);
			Controls.Add(btnDelete);
			Controls.Add(lstVinyl);
			Controls.Add(label1);
			Controls.Add(txtTrackList);
			Controls.Add(btnSave);
			Controls.Add(txtNotes);
			Controls.Add(txtTitle);
			Controls.Add(lblDescription);
			Controls.Add(lblTitle);
			Name = "VinylUserControl";
			Size = new Size(457, 718);
			((System.ComponentModel.ISupportInitialize)numDiscCount).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button btnReports;
		private Button btnClear;
		private Button btnDelete;
		private ListBox lstVinyl;
		private Label label1;
		private TextBox txtTrackList;
		private Button btnSave;
		private TextBox txtNotes;
		private TextBox txtTitle;
		private Label lblDescription;
		private Label lblTitle;
		private Label label2;
		private Label label3;
		private ComboBox cmbGenre;
		private Label label4;
		private NumericUpDown numDiscCount;
		private RadioButton rdoSingle;
		private RadioButton rdoGatefold;
		private RadioButton rdoBox;
		private ComboBox cmbArtist;
		private TextBox txtOid;
	}
}
