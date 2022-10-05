using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShahFileDissemination
{
    public partial class ViewShareForm : Form
    {
        private Dictionary<int, SharesFromIndex> SharesByIndex = new Dictionary<int, SharesFromIndex>();
        public ViewShareForm(Dictionary<int, SharesFromIndex> sharesByIndex)
        {
            InitializeComponent();
            SharesByIndex = sharesByIndex;
        }

        private void ViewShareForm_Load(object sender, EventArgs e)
        {
            foreach(var shareByIndex in SharesByIndex)
            {
                ListViewGroup lvg = new ListViewGroup($"Index: {shareByIndex.Key}");
                ShareListView.Groups.Add(lvg);
                foreach(var shareByNodeId in shareByIndex.Value.SharesByNodeId)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Group = lvg;
                    lvi.Text = shareByNodeId.Key.ToString();
                    lvi.SubItems.Add(shareByNodeId.Value.Value.ToString());
                    ShareListView.Items.Add(lvi);
                }
            }
        }
    }
}
