using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Telerik.WinControls.Primitives;

namespace QuickVerbs
{
    /// <summary>
    /// represent the busness grid form 
    /// </summary>    
    //--------------------------------------------------------------------------
    public partial class MainForm2 : ShapedForm
    {
        //private int columnIDCounter = 0;
        private const int OleHeaderSize = 78;
        private Font segoeFont = new Font("Segoe UI", 8.25f, FontStyle.Regular);
        //--------------------------------------------------------------------------
        public MainForm2()
        {
            InitializeComponent();

            //TODO:
            vl.Add(new Verbs(Verbs.A11, Verbs.A12, Verbs.A13, Verbs.A14, 0, true));
            vl.Add(new Verbs(Verbs.A21, Verbs.A22, Verbs.A23, Verbs.A24, 0, true));
            vl.Add(new Verbs(Verbs.A31, Verbs.A32, Verbs.A33, Verbs.A34, 0, true));
            radGridView.DataSource = vl;

            Shape = new RoundRectShape(7);
            BorderWidth = 1;
            radGridView.TableElement.RowHeight = 80;
            radGridView.RowsChanging += new GridViewCollectionChangingEventHandler(radGridView1_RowsChanging);
            radGridView.DefaultValuesNeeded += new GridViewRowEventHandler(radGridView1_DefaultValuesNeeded);
        }
        //--------------------------------------------------------------------------
        private void MainForm_Load(object sender, EventArgs e)
        {
            //newButton.Image = this.LoadImage("Telerik.Examples.WinControls.GridView.FirstLook.Images.buttonNew.png");
            //deleteButton.Image = this.LoadImage("Telerik.Examples.WinControls.GridView.FirstLook.Images.buttonDelete.png");
            //radTitleBar.BackgroundImageLayout = ImageLayout.Center;
            //((TextPrimitive)radTitleBar.TitleBarElement.Children[2].Children[1]).Text = String.Empty;
            //((ImagePrimitive)radTitleBar.TitleBarElement.Children[2].Children[0]).Image = null;

            RoundRectShape panelShapeTopRounded = new RoundRectShape(3);
            panelShapeTopRounded.BottomRightRounded = false;
            panelShapeTopRounded.BottomLeftRounded = false;

            radPanel4.PanelElement.Shape = panelShapeTopRounded;
            RoundRectShape panelShapeBottomRounded = new RoundRectShape(3);
            panelShapeBottomRounded.TopLeftRounded = false;
            panelShapeBottomRounded.TopRightRounded = false;
            radPanel1.PanelElement.Shape = panelShapeBottomRounded;
            radPanel3.PanelElement.Shape = panelShapeTopRounded;
            radTextBoxDimension.Font = segoeFont;
            radTextBoxManufacturer.Font = segoeFont;
            radTextBoxMaterial.Font = segoeFont;
            radTextBoxProductName.Font = segoeFont;
            updateButton.Font = segoeFont;
            cancelButton.Font = segoeFont;
            radLabel2.Font = segoeFont;
            radLabel3.Font = segoeFont;
            radLabel4.Font = segoeFont;
            radLabel5.Font = segoeFont;
            radLabel6.Font = segoeFont;
            this.radGridView.TableElement.Padding = new Padding(0);
            this.radGridView.TableElement.DrawBorder = false;
            this.radGridView.TableElement.CellSpacing = -1;
            this.radGridView.TableElement.Text = "";
            this.radGridView.MasterTemplate.BestFitColumns();
            this.radGridView.Columns["Photo"].Width = 106;
            this.radGridView.TableElement.RowHeight = 60;
        }

        private void radGridView1_DefaultValuesNeeded(object sender, GridViewRowEventArgs e)
        {
            //e.Rows[0].Cells["Price"].Value = 0;
            //e.Rows[0].Cells["Quantity"].Value = 0;
            //e.Rows[0].Cells["ID"].Value = this.columnIDCounter++;
        }

        private void radGridView1_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
            if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Remove)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete this product?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }

        private void radGridView1_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            //UpdatePanelInfo(this.radGridView1.CurrentRow);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateGridInfo(this.radGridView.CurrentRow);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (this.radGridView.CurrentRow != null)
            {
                //UpdatePanelInfo(this.radGridView1.CurrentRow);
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            this.radGridView.AllowAddNewRow = !this.radGridView.AllowAddNewRow;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            GridViewDataRowInfo dataRowInfo = this.radGridView.CurrentRow as GridViewDataRowInfo;
            if (dataRowInfo != null)
            {
                this.radGridView.Rows.Remove(dataRowInfo);
                //this.UpdatePanelInfo(this.radGridView1.CurrentRow);
            }
        }

        private void UpdatePanelInfo(GridViewRowInfo currentRow)
        {
            if (currentRow != null && !(currentRow is GridViewNewRowInfo))
            {
                this.radTextBoxProductName.Text = this.GetSafeString(currentRow.Cells["ProductName"].Value);
                this.radTextBoxManufacturer.Text = this.GetSafeString(currentRow.Cells["Manufacturer"].Value);
                this.radTextBoxMaterial.Text = this.GetSafeString(currentRow.Cells["Lining"].Value);
                this.radTextBoxDimension.Text = this.GetSafeString(currentRow.Cells["Dimensions"].Value);
                object photoValue = currentRow.Cells["Photo"].Value;
                if (!Convert.IsDBNull(photoValue) && photoValue != null)
                {
                    Image image = GetImageFromBytes(currentRow.Cells["Photo"].Value as byte[]);
                    this.radPanel2.BackgroundImage = new Bitmap(image);
                }
                else
                {
                    this.radPanel2.BackgroundImage = new Bitmap(10, 10);
                }
                string salesPerson = this.GetSafeString(currentRow.Cells["SalesRepresentative"].Value);

                if (!string.IsNullOrEmpty(salesPerson.Trim()))
                {
                    this.radComboBox1.SelectedItem = salesPerson;
                }
                else
                {
                    this.radComboBox1.SelectedIndex = -1;
                    this.radComboBox1.Text = string.Empty;
                }
            }
            else
            {
                this.radTextBoxProductName.Text = string.Empty;
                this.radTextBoxManufacturer.Text = string.Empty;
                this.radTextBoxMaterial.Text = string.Empty;
                this.radTextBoxDimension.Text = string.Empty;
                this.radPanel2.BackgroundImage = new Bitmap(10, 10);
                this.radComboBox1.SelectedItem = -1;
                this.radComboBox1.Text = string.Empty;
            }
        }

        private void UpdateGridInfo(GridViewRowInfo currentRow)
        {
            if (currentRow == null)
            {
                return;
            }
            this.radGridView.CloseEditor();
            currentRow.Cells["ProductName"].Value = radTextBoxProductName.Text;
            currentRow.Cells["Manufacturer"].Value = radTextBoxManufacturer.Text;
            currentRow.Cells["Lining"].Value = radTextBoxMaterial.Text;
            currentRow.Cells["Dimensions"].Value = radTextBoxDimension.Text;
            if (this.radComboBox1.SelectedIndex != -1)
            {
                currentRow.Cells["SalesRepresentative"].Value = ((RadComboBoxItem)this.radComboBox1.SelectedItem).Text;
            }
            GridViewNewRowInfo newRowInfo = currentRow as GridViewNewRowInfo;

            if (newRowInfo != null)
            {
                currentRow.InvalidateRow();
            }
            else
            {
                ((IEditableObject)this.radGridView.CurrentRow.DataBoundItem).EndEdit();
            }
        }
        private void FillComboBox()
        {
            this.radComboBox1.Items.Clear();
            string basePath = Path.GetDirectoryName(Application.ExecutablePath);
            foreach (string fileName in Directory.GetFiles(Path.Combine(basePath, "..\\GridView\\FirstLook\\Images\\People"), "*.jpg"))
            {
                Image image = Image.FromFile(fileName);
                RadComboBoxItem comboboxItem = new RadComboBoxItem();
                comboboxItem.Font = this.radComboBox1.Font;
                comboboxItem.ForeColor = Color.Black;
                comboboxItem.TextImageRelation = TextImageRelation.ImageBeforeText;
                comboboxItem.Text = Path.GetFileNameWithoutExtension(fileName);
                comboboxItem.Image = image;
                this.radComboBox1.Items.Add(comboboxItem);
            }
        }
        private string GetSafeString(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return value.ToString();
        }
        private Image LoadImage(string name)
        {
            Stream stream = Assembly.GetAssembly(this.GetType()).GetManifestResourceStream(name);
            if (stream == null)
            {
                throw new NullReferenceException("Cannot find " + name);
            }
            return new Bitmap(stream);
        }
        private Image GetImageFromBytes(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return null;
            }
            Image result = null;

            MemoryStream stream = null;
            try
            {
                int count;
                int start;
                if (IsOleContainer(bytes))
                {
                    count = bytes.Length - OleHeaderSize;
                    start = OleHeaderSize;
                }
                else
                {
                    count = bytes.Length;
                    start = 0;
                }
                stream = new MemoryStream(bytes, start, count);
                result = Image.FromStream(stream);
            }
            catch
            {
                result = null;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return result;
        }
        private bool IsOleContainer(byte[] imageData)
        {
            return (imageData != null && imageData[0] == 0x15 && imageData[1] == 0x1C);
        }

        private void radMenuItemFile_Click(object sender, EventArgs e)
        {

        }

        private void menuAbout_Click(object sender, EventArgs e)
        {

        }

        private void radGridView_Click(object sender, EventArgs e)
        {

        }
    }
}