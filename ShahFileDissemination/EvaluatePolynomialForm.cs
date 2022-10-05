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
    public partial class EvaluatePolynomialForm : Form
    {
        private PolynomialSequence PolynomialSequence { get; set; }
        public EvaluatePolynomialForm(PolynomialSequence polynomialSequence)
        {
            InitializeComponent();
            this.PolynomialSequence = polynomialSequence;
            maxIndexLabel.Text = (PolynomialSequence.PolyByIndex.Count -1).ToString();
        }

        private void EvaluatePolynomialForm_Load(object sender, EventArgs e)
        {
            
            ResultTextBox.Text = PolynomialSequence.PolyByIndex[0].Eval(0).Value.ToString();
        }

        private void EvaluateTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int bi = int.Parse(EvaluateTextBox.Text);
                int polyIndex = int.Parse(PolyIndexTextBox.Text);
                ResultTextBox.Text = PolynomialSequence.PolyByIndex[polyIndex].Eval(bi).Value.ToString();
            }
            catch(Exception)
            {
                ResultTextBox.Text = "Incorrect Parameters";
            }
        }

        private void PolyIndexTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int bi = int.Parse(EvaluateTextBox.Text);
                int polyIndex = int.Parse(PolyIndexTextBox.Text);
                ResultTextBox.Text = PolynomialSequence.PolyByIndex[polyIndex].Eval(bi).Value.ToString();
            }
            catch (Exception)
            {
                ResultTextBox.Text = "Incorrect Parameters";
            }
        }
    }
}
