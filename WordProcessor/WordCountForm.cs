using System;
using System.Windows.Forms;

namespace WordProcessor
{
    public partial class WordCountForm : Form
    {
        public WordCountForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }


}
