using System;
using System.Windows.Forms;
using API = UdE.API; // Supondo que API esteja no namespace UdE

namespace AipolicyEditor
{
    public partial class TooltipForm : Form
    {
        private DataGridView dataGridView;

        public TooltipForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(800, 450);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellMouseEnter);
            this.dataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellMouseLeave);
            // 
            // TooltipForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Name = "TooltipForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        public void DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string cellValue = dataGridView[e.ColumnIndex, e.RowIndex].Value?.ToString();
                if (int.TryParse(cellValue, out int itemId) && itemId > 0)
                {
                    API.ShowToolTip(UdE.ItemType.PW_MONSTER_ESSENCE, itemId);
                }
            }
        }

        public void DataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            API.fHideToolTip();
        }
    }
}
