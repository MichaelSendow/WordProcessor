using System;
using System.Windows.Forms;

namespace WordProcessor
{
    /// <summary>
    /// Form used as a dialog for the WordProcessor
    /// </summary>
    public partial class WordCountForm : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
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
