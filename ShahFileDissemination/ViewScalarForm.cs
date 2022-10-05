using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShahFileDissemination
{
    public partial class ViewScalarForm : Form
    {
        private Dictionary<int, ScalarsFromIndex> ScalarsByIndex = new Dictionary<int, ScalarsFromIndex>();
        public ViewScalarForm(Dictionary<int, ScalarsFromIndex> scalarsByIndex)
        {
            InitializeComponent();
            this.ScalarsByIndex = scalarsByIndex;
        }

        private void ViewScalarForm_Load(object sender, EventArgs e)
        {
            foreach(var scalarByIndex in ScalarsByIndex)
            {
                ListViewGroup lvg = new ListViewGroup($"Index: {scalarByIndex.Key}");
                ScalarListView.Groups.Add(lvg);
                foreach(var scalarByNodeId in scalarByIndex.Value.ScalarsByNodeId)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Group = lvg;
                    lvi.Text = scalarByNodeId.Key.ToString();
                    lvi.SubItems.Add(scalarByNodeId.Value.Value.ToString());
                    ScalarListView.Items.Add(lvi);
                }
            }
        }
    }
}
