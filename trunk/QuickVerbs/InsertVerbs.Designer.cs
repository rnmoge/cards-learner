namespace QuickVerbs
{
    partial class InsertVerbs
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
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.radListControlVerbs = new Telerik.WinControls.UI.RadListControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeselect = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListControlVerbs)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(89, 308);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.ThemeName = "Desert";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(13, 308);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Добавить";
            this.btnOK.ThemeName = "Desert";
            // 
            // radListControlVerbs
            // 
            this.radListControlVerbs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radListControlVerbs.AutoScroll = true;
            this.radListControlVerbs.CaseSensitiveSort = true;
            this.radListControlVerbs.ContextMenuStrip = this.contextMenuStrip;
            this.radListControlVerbs.Location = new System.Drawing.Point(12, 12);
            this.radListControlVerbs.Name = "radListControlVerbs";
            this.radListControlVerbs.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.radListControlVerbs.Size = new System.Drawing.Size(147, 282);
            this.radListControlVerbs.TabIndex = 0;
            this.radListControlVerbs.Text = "radListControl1";
            this.radListControlVerbs.ThemeName = "Desert";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSelect,
            this.toolStripMenuItemDeselect});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(219, 48);
            this.contextMenuStrip.Text = "Выбрать все";
            // 
            // toolStripMenuItemSelect
            // 
            this.toolStripMenuItemSelect.Image = global::QuickVerbs.Properties.Resources.hourglass_plus;
            this.toolStripMenuItemSelect.Name = "toolStripMenuItemSelect";
            this.toolStripMenuItemSelect.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItemSelect.Text = "Выбрать все";
            this.toolStripMenuItemSelect.Click += new System.EventHandler(this.toolStripMenuItemSelect_Click);
            // 
            // toolStripMenuItemDeselect
            // 
            this.toolStripMenuItemDeselect.Image = global::QuickVerbs.Properties.Resources.hourglass_exclamation;
            this.toolStripMenuItemDeselect.Name = "toolStripMenuItemDeselect";
            this.toolStripMenuItemDeselect.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItemDeselect.Text = "Отменить выбор для всех";
            this.toolStripMenuItemDeselect.Click += new System.EventHandler(this.toolStripMenuItemDeselect_Click);
            // 
            // InsertVerbs
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(171, 344);
            this.Controls.Add(this.radListControlVerbs);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertVerbs";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить";
            this.ThemeName = "Desert";
            this.Load += new System.EventHandler(this.InsertVerbs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListControlVerbs)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnOK;
        public Telerik.WinControls.UI.RadListControl radListControlVerbs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSelect;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeselect;
    }
}
