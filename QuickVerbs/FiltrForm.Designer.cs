namespace QuickVerbs
{
    partial class frmCategory
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
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButtonElementary = new System.Windows.Forms.RadioButton();
            this.radioButtonPreIntermediate = new System.Windows.Forms.RadioButton();
            this.radioButtonIntermediate = new System.Windows.Forms.RadioButton();
            this.radioButtonUpperIntermediate = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.radioButtonAdvanced = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(12, 12);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(14, 13);
            this.radioButtonAll.TabIndex = 0;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // radioButtonElementary
            // 
            this.radioButtonElementary.AutoSize = true;
            this.radioButtonElementary.Location = new System.Drawing.Point(12, 36);
            this.radioButtonElementary.Name = "radioButtonElementary";
            this.radioButtonElementary.Size = new System.Drawing.Size(14, 13);
            this.radioButtonElementary.TabIndex = 1;
            this.radioButtonElementary.TabStop = true;
            this.radioButtonElementary.UseVisualStyleBackColor = true;
            // 
            // radioButtonPreIntermediate
            // 
            this.radioButtonPreIntermediate.AutoSize = true;
            this.radioButtonPreIntermediate.Location = new System.Drawing.Point(12, 60);
            this.radioButtonPreIntermediate.Name = "radioButtonPreIntermediate";
            this.radioButtonPreIntermediate.Size = new System.Drawing.Size(14, 13);
            this.radioButtonPreIntermediate.TabIndex = 2;
            this.radioButtonPreIntermediate.TabStop = true;
            this.radioButtonPreIntermediate.UseVisualStyleBackColor = true;
            // 
            // radioButtonIntermediate
            // 
            this.radioButtonIntermediate.AutoSize = true;
            this.radioButtonIntermediate.Location = new System.Drawing.Point(12, 84);
            this.radioButtonIntermediate.Name = "radioButtonIntermediate";
            this.radioButtonIntermediate.Size = new System.Drawing.Size(14, 13);
            this.radioButtonIntermediate.TabIndex = 3;
            this.radioButtonIntermediate.TabStop = true;
            this.radioButtonIntermediate.UseVisualStyleBackColor = true;
            // 
            // radioButtonUpperIntermediate
            // 
            this.radioButtonUpperIntermediate.AutoSize = true;
            this.radioButtonUpperIntermediate.Location = new System.Drawing.Point(12, 108);
            this.radioButtonUpperIntermediate.Name = "radioButtonUpperIntermediate";
            this.radioButtonUpperIntermediate.Size = new System.Drawing.Size(14, 13);
            this.radioButtonUpperIntermediate.TabIndex = 4;
            this.radioButtonUpperIntermediate.TabStop = true;
            this.radioButtonUpperIntermediate.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(57, 163);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "Применить";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(142, 163);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // radioButtonAdvanced
            // 
            this.radioButtonAdvanced.AutoSize = true;
            this.radioButtonAdvanced.Location = new System.Drawing.Point(12, 132);
            this.radioButtonAdvanced.Name = "radioButtonAdvanced";
            this.radioButtonAdvanced.Size = new System.Drawing.Size(14, 13);
            this.radioButtonAdvanced.TabIndex = 5;
            this.radioButtonAdvanced.TabStop = true;
            this.radioButtonAdvanced.UseVisualStyleBackColor = true;
            // 
            // frmCategory
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(229, 199);
            this.Controls.Add(this.radioButtonAdvanced);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.radioButtonUpperIntermediate);
            this.Controls.Add(this.radioButtonIntermediate);
            this.Controls.Add(this.radioButtonPreIntermediate);
            this.Controls.Add(this.radioButtonElementary);
            this.Controls.Add(this.radioButtonAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCategory";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Показать уровень";
            this.Load += new System.EventHandler(this.frmCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton radioButtonAll;
        public System.Windows.Forms.RadioButton radioButtonElementary;
        public System.Windows.Forms.RadioButton radioButtonPreIntermediate;
        public System.Windows.Forms.RadioButton radioButtonIntermediate;
        public System.Windows.Forms.RadioButton radioButtonUpperIntermediate;
        public System.Windows.Forms.RadioButton radioButtonAdvanced;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}