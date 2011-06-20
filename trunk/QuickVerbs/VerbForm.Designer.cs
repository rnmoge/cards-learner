namespace QuickVerbs
{
    partial class MainForm1
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radPanelTop = new Telerik.WinControls.UI.RadPanel();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem3 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem4 = new Telerik.WinControls.UI.RadMenuItem();
            this.radGridView = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelTop)).BeginInit();
            this.radPanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanelTop
            // 
            this.radPanelTop.Controls.Add(this.radMenu1);
            this.radPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanelTop.Location = new System.Drawing.Point(0, 0);
            this.radPanelTop.Name = "radPanelTop";
            this.radPanelTop.Size = new System.Drawing.Size(961, 21);
            this.radPanelTop.TabIndex = 1;
            this.radPanelTop.Text = "radPanelTop";
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem2,
            this.radMenuItem3,
            this.radMenuItem4});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(961, 20);
            this.radMenu1.TabIndex = 4;
            this.radMenu1.Text = "radMenu1";
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.Class = "";
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "Выход";
            // 
            // radMenuItem3
            // 
            this.radMenuItem3.Class = "";
            this.radMenuItem3.Name = "radMenuItem3";
            this.radMenuItem3.Text = "Настройки";
            // 
            // radMenuItem4
            // 
            this.radMenuItem4.Class = "";
            this.radMenuItem4.Name = "radMenuItem4";
            this.radMenuItem4.Text = "О программе";
            // 
            // radGridView
            // 
            this.radGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView.Location = new System.Drawing.Point(0, 21);
            // 
            // radGridView
            // 
            this.radGridView.MasterTemplate.AllowAddNewRow = false;
            this.radGridView.MasterTemplate.AllowDeleteRow = false;
            this.radGridView.MasterTemplate.AllowDragToGroup = false;
            this.radGridView.MasterTemplate.AllowEditRow = false;
            this.radGridView.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn7.FieldName = "FirstForm";
            gridViewTextBoxColumn7.FormatString = "";
            gridViewTextBoxColumn7.HeaderText = "Infinitive";
            gridViewTextBoxColumn7.Name = "column1Form";
            gridViewTextBoxColumn7.Width = 200;
            gridViewTextBoxColumn8.FieldName = "SEcondForm";
            gridViewTextBoxColumn8.FormatString = "";
            gridViewTextBoxColumn8.HeaderText = "Past Participle";
            gridViewTextBoxColumn8.Name = "column2Form";
            gridViewTextBoxColumn8.Width = 200;
            gridViewTextBoxColumn9.FieldName = "ThirdForm";
            gridViewTextBoxColumn9.FormatString = "";
            gridViewTextBoxColumn9.HeaderText = "Past Participle";
            gridViewTextBoxColumn9.Name = "column3Form";
            gridViewTextBoxColumn9.Width = 200;
            gridViewTextBoxColumn10.FieldName = "Translate";
            gridViewTextBoxColumn10.FormatString = "";
            gridViewTextBoxColumn10.HeaderText = "Перевод";
            gridViewTextBoxColumn10.Name = "columnTranslate";
            gridViewTextBoxColumn10.Width = 200;
            gridViewTextBoxColumn11.FieldName = "Category";
            gridViewTextBoxColumn11.FormatString = "";
            gridViewTextBoxColumn11.HeaderText = "Категория";
            gridViewTextBoxColumn11.Name = "columnCategory";
            gridViewTextBoxColumn11.Width = 70;
            gridViewTextBoxColumn12.FieldName = "VerbChecked";
            gridViewTextBoxColumn12.FormatString = "";
            gridViewTextBoxColumn12.HeaderText = "Выбран";
            gridViewTextBoxColumn12.Name = "columnChecked";
            this.radGridView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.radGridView.MasterTemplate.EnableGrouping = false;
            this.radGridView.Name = "radGridView";
            this.radGridView.ShowGroupPanel = false;
            this.radGridView.Size = new System.Drawing.Size(961, 452);
            this.radGridView.TabIndex = 3;
            this.radGridView.Text = "radGridView";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 473);
            this.Controls.Add(this.radGridView);
            this.Controls.Add(this.radPanelTop);
            this.Name = "MainForm";
            this.Text = "Таблица неправильных глаголов";
            ((System.ComponentModel.ISupportInitialize)(this.radPanelTop)).EndInit();
            this.radPanelTop.ResumeLayout(false);
            this.radPanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanelTop;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem3;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem4;
        private Telerik.WinControls.UI.RadGridView radGridView;

    }
}

