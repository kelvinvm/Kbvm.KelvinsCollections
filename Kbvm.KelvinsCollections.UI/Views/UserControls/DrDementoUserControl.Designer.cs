namespace Kbvm.KelvinsCollections.UI.Views.UserControls
{
	partial class DrDementoUserControl
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
			components = new System.ComponentModel.Container();
			btnReports = new Button();
			btnClear = new Button();
			btnDelete = new Button();
			btnBrowse = new Button();
			txtFileName = new TextBox();
			label2 = new Label();
			lstShows = new ListBox();
			showsBindingSource = new BindingSource(components);
			drDementoViewModelBindingSource = new BindingSource(components);
			label1 = new Label();
			txtPlayList = new TextBox();
			btnSave = new Button();
			txtDescription = new TextBox();
			txtTitle = new TextBox();
			dtBroadcastDate = new DateTimePicker();
			txtShowNumber = new TextBox();
			lblDescription = new Label();
			lblTitle = new Label();
			lblBroadcastDate = new Label();
			lblShowNumber = new Label();
			chkIgnoreDatabase = new CheckBox();
			chkIgnoreMetadata = new CheckBox();
			dlgOpenFile = new OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)showsBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)drDementoViewModelBindingSource).BeginInit();
			SuspendLayout();
			// 
			// btnReports
			// 
			btnReports.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnReports.Location = new Point(368, 132);
			btnReports.Name = "btnReports";
			btnReports.Size = new Size(75, 23);
			btnReports.TabIndex = 77;
			btnReports.Text = "Reports";
			btnReports.UseVisualStyleBackColor = true;
			// 
			// btnClear
			// 
			btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnClear.DataBindings.Add(new Binding("Command", drDementoViewModelBindingSource, "ClearCommand", true));
			btnClear.Location = new Point(368, 44);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(75, 23);
			btnClear.TabIndex = 76;
			btnClear.Text = "Clear";
			btnClear.UseVisualStyleBackColor = true;
			// 
			// btnDelete
			// 
			btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnDelete.Location = new Point(368, 15);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(75, 23);
			btnDelete.TabIndex = 75;
			btnDelete.Text = "Delete";
			btnDelete.UseVisualStyleBackColor = true;
			// 
			// btnBrowse
			// 
			btnBrowse.Location = new Point(368, 197);
			btnBrowse.Name = "btnBrowse";
			btnBrowse.Size = new Size(75, 23);
			btnBrowse.TabIndex = 74;
			btnBrowse.Text = "Browse";
			btnBrowse.UseVisualStyleBackColor = true;
			// 
			// txtFileName
			// 
			txtFileName.Location = new Point(104, 197);
			txtFileName.Name = "txtFileName";
			txtFileName.Size = new Size(258, 23);
			txtFileName.TabIndex = 73;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(42, 200);
			label2.Name = "label2";
			label2.Size = new Size(56, 15);
			label2.TabIndex = 72;
			label2.Text = "FLAC File";
			// 
			// lstShows
			// 
			lstShows.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lstShows.CausesValidation = false;
			lstShows.DataSource = showsBindingSource;
			lstShows.DisplayMember = "ShowNumberTitle";
			lstShows.FormattingEnabled = true;
			lstShows.ItemHeight = 15;
			lstShows.Location = new Point(12, 15);
			lstShows.Name = "lstShows";
			lstShows.Size = new Size(350, 169);
			lstShows.TabIndex = 71;
			lstShows.ValueMember = "Oid";
			lstShows.SelectedIndexChanged += lstShows_SelectedIndexChanged;
			// 
			// showsBindingSource
			// 
			showsBindingSource.DataMember = "Shows";
			showsBindingSource.DataSource = drDementoViewModelBindingSource;
			// 
			// drDementoViewModelBindingSource
			// 
			drDementoViewModelBindingSource.DataSource = typeof(ViewModels.DrDementoViewModel);
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(41, 442);
			label1.Name = "label1";
			label1.Size = new Size(50, 15);
			label1.TabIndex = 70;
			label1.Text = "Play List";
			// 
			// txtPlayList
			// 
			txtPlayList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			txtPlayList.DataBindings.Add(new Binding("Text", drDementoViewModelBindingSource, "PlayList", true));
			txtPlayList.Location = new Point(104, 439);
			txtPlayList.Multiline = true;
			txtPlayList.Name = "txtPlayList";
			txtPlayList.Size = new Size(339, 299);
			txtPlayList.TabIndex = 69;
			// 
			// btnSave
			// 
			btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnSave.DataBindings.Add(new Binding("Command", drDementoViewModelBindingSource, "SaveShowCommand", true));
			btnSave.Location = new Point(368, 161);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 68;
			btnSave.Text = "Save";
			btnSave.UseVisualStyleBackColor = true;
			// 
			// txtDescription
			// 
			txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtDescription.DataBindings.Add(new Binding("Text", drDementoViewModelBindingSource, "Description", true));
			txtDescription.Location = new Point(104, 330);
			txtDescription.Multiline = true;
			txtDescription.Name = "txtDescription";
			txtDescription.Size = new Size(339, 93);
			txtDescription.TabIndex = 67;
			// 
			// txtTitle
			// 
			txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtTitle.DataBindings.Add(new Binding("Text", drDementoViewModelBindingSource, "Title", true));
			txtTitle.Location = new Point(104, 292);
			txtTitle.Name = "txtTitle";
			txtTitle.Size = new Size(339, 23);
			txtTitle.TabIndex = 66;
			// 
			// dtBroadcastDate
			// 
			dtBroadcastDate.DataBindings.Add(new Binding("Value", drDementoViewModelBindingSource, "BroadcastDate", true));
			dtBroadcastDate.Location = new Point(104, 259);
			dtBroadcastDate.Name = "dtBroadcastDate";
			dtBroadcastDate.Size = new Size(224, 23);
			dtBroadcastDate.TabIndex = 65;
			// 
			// txtShowNumber
			// 
			txtShowNumber.DataBindings.Add(new Binding("Text", drDementoViewModelBindingSource, "ShowNumber", true));
			txtShowNumber.Location = new Point(104, 226);
			txtShowNumber.Name = "txtShowNumber";
			txtShowNumber.Size = new Size(124, 23);
			txtShowNumber.TabIndex = 64;
			// 
			// lblDescription
			// 
			lblDescription.AutoSize = true;
			lblDescription.Location = new Point(31, 330);
			lblDescription.Name = "lblDescription";
			lblDescription.Size = new Size(67, 15);
			lblDescription.TabIndex = 63;
			lblDescription.Text = "Description";
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Location = new Point(69, 296);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(29, 15);
			lblTitle.TabIndex = 62;
			lblTitle.Text = "Title";
			// 
			// lblBroadcastDate
			// 
			lblBroadcastDate.AutoSize = true;
			lblBroadcastDate.Location = new Point(12, 263);
			lblBroadcastDate.Name = "lblBroadcastDate";
			lblBroadcastDate.Size = new Size(86, 15);
			lblBroadcastDate.TabIndex = 61;
			lblBroadcastDate.Text = "Broadcast Date";
			// 
			// lblShowNumber
			// 
			lblShowNumber.AutoSize = true;
			lblShowNumber.Location = new Point(15, 230);
			lblShowNumber.Name = "lblShowNumber";
			lblShowNumber.Size = new Size(83, 15);
			lblShowNumber.TabIndex = 60;
			lblShowNumber.Text = "Show Number";
			// 
			// chkIgnoreDatabase
			// 
			chkIgnoreDatabase.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			chkIgnoreDatabase.AutoSize = true;
			chkIgnoreDatabase.Location = new Point(105, 741);
			chkIgnoreDatabase.Name = "chkIgnoreDatabase";
			chkIgnoreDatabase.Size = new Size(111, 19);
			chkIgnoreDatabase.TabIndex = 78;
			chkIgnoreDatabase.Text = "Ignore Database";
			chkIgnoreDatabase.UseVisualStyleBackColor = true;
			// 
			// chkIgnoreMetadata
			// 
			chkIgnoreMetadata.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			chkIgnoreMetadata.AutoSize = true;
			chkIgnoreMetadata.Location = new Point(237, 741);
			chkIgnoreMetadata.Name = "chkIgnoreMetadata";
			chkIgnoreMetadata.Size = new Size(113, 19);
			chkIgnoreMetadata.TabIndex = 79;
			chkIgnoreMetadata.Text = "Ignore Metadata";
			chkIgnoreMetadata.UseVisualStyleBackColor = true;
			// 
			// dlgOpenFile
			// 
			dlgOpenFile.FileName = "openFileDialog1";
			dlgOpenFile.Filter = "FLAC|*.flac";
			// 
			// DrDementoUserControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(chkIgnoreMetadata);
			Controls.Add(chkIgnoreDatabase);
			Controls.Add(btnReports);
			Controls.Add(btnClear);
			Controls.Add(btnDelete);
			Controls.Add(btnBrowse);
			Controls.Add(txtFileName);
			Controls.Add(label2);
			Controls.Add(lstShows);
			Controls.Add(label1);
			Controls.Add(txtPlayList);
			Controls.Add(btnSave);
			Controls.Add(txtDescription);
			Controls.Add(txtTitle);
			Controls.Add(dtBroadcastDate);
			Controls.Add(txtShowNumber);
			Controls.Add(lblDescription);
			Controls.Add(lblTitle);
			Controls.Add(lblBroadcastDate);
			Controls.Add(lblShowNumber);
			Name = "DrDementoUserControl";
			Size = new Size(459, 780);
			Load += DrDementoUserControl_Load;
			((System.ComponentModel.ISupportInitialize)showsBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)drDementoViewModelBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnReports;
		private Button btnClear;
		private Button btnDelete;
		private Button btnBrowse;
		private TextBox txtFileName;
		private Label label2;
		private ListBox lstShows;
		private Label label1;
		private TextBox txtPlayList;
		private Button btnSave;
		private TextBox txtDescription;
		private TextBox txtTitle;
		private DateTimePicker dtBroadcastDate;
		private TextBox txtShowNumber;
		private Label lblDescription;
		private Label lblTitle;
		private Label lblBroadcastDate;
		private Label lblShowNumber;
		private CheckBox chkIgnoreDatabase;
		private CheckBox chkIgnoreMetadata;
		private OpenFileDialog dlgOpenFile;
		private BindingSource drDementoViewModelBindingSource;
		private BindingSource showsBindingSource;
	}
}
