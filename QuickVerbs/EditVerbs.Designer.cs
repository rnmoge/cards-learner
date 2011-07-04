namespace QuickVerbs
{
    partial class EditVerbs
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
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.radRadioButtonCheck = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButtonUncheck = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButtonCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButtonUncheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(88, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.ThemeName = "Desert";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(12, 90);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 24);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Изменить";
            this.btnOK.ThemeName = "Desert";
            // 
            // radRadioButtonCheck
            // 
            this.radRadioButtonCheck.Location = new System.Drawing.Point(13, 19);
            this.radRadioButtonCheck.Name = "radRadioButtonCheck";
            this.radRadioButtonCheck.Size = new System.Drawing.Size(110, 18);
            this.radRadioButtonCheck.TabIndex = 0;
            this.radRadioButtonCheck.Text = "Выучен";
            // 
            // radRadioButtonUncheck
            // 
            this.radRadioButtonUncheck.Location = new System.Drawing.Point(13, 48);
            this.radRadioButtonUncheck.Name = "radRadioButtonUncheck";
            this.radRadioButtonUncheck.Size = new System.Drawing.Size(110, 18);
            this.radRadioButtonUncheck.TabIndex = 1;
            this.radRadioButtonUncheck.Text = "Не выучен";
            // 
            // EditVerbs
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(170, 129);
            this.Controls.Add(this.radRadioButtonUncheck);
            this.Controls.Add(this.radRadioButtonCheck);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditVerbs";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактировать";
            this.ThemeName = "Desert";
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButtonCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButtonUncheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnOK;
        public Telerik.WinControls.UI.RadRadioButton radRadioButtonCheck;
        public Telerik.WinControls.UI.RadRadioButton radRadioButtonUncheck;
    }
}
