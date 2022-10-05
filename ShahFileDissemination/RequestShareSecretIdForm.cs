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
    public partial class RequestShareSecretIdForm : Form
    {
        private List<int> secretIds { get;set;} 
        public RequestShareSecretIdForm(List<int> secretIds)
        {
            InitializeComponent();
            this.secretIds = secretIds;
        }
        public int SelectedSecretId;
        private void RequestShareSecretIdForm_Load(object sender, EventArgs e)
        {
            foreach(int secretId in secretIds)
            {
                SecretIdComboBox.Items.Add(secretId.ToString());
            }
            SecretIdComboBox.SelectedIndex = 0;
        }

        private void RequestBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedSecretId = int.Parse(SecretIdComboBox.Text);
                this.Close();
            }
            catch(Exception)
            {

            }
        }
    }
}
