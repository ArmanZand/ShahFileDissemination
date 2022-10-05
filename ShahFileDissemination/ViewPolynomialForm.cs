using ShahFileDissemination.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShahFileDissemination
{
    public partial class ViewPolynomialForm : Form
    {
        private PolynomialSequence PolynomialSequence { get; set; }
        public ViewPolynomialForm(PolynomialSequence polynomialSequence)
        {
            InitializeComponent();
            this.PolynomialSequence = polynomialSequence;
        }

        private void ViewPolynomialForm_Load(object sender, EventArgs e)
        {
            for(int i =0; i < PolynomialSequence.PolyByIndex.Count; i++)
            {
                ListViewGroup lvg = new ListViewGroup($"Index: {i}");
                PolyListView.Groups.Add(lvg);
                for(int j = 0; j < PolynomialSequence.PolyByIndex[i].coeffs.Length; j++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Group = lvg;
                    lvi.Text = j.ToString();
                    lvi.SubItems.Add(PolynomialSequence.PolyByIndex[i].coeffs[j].ToString());
                    PolyListView.Items.Add(lvi);
                }
            }
            
        }
    }
}
