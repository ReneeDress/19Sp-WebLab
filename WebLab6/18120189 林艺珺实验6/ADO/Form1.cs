using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebLab6
{
    public partial class Data : Form
    {
        public Data()
        {
            InitializeComponent();
        }

        private void sBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.jxglDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“jxglDataSet.S”中。您可以根据需要移动或删除它。
            this.sTableAdapter.Fill(this.jxglDataSet.S);

        }

        private void sDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
