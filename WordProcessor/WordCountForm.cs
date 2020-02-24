using System;
using System.Globalization;
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
        public WordCountForm(
            int LinesCount = 0,
            int WordsCount = 0,
            int CharacterCountNoSpace = 0,
            int CharactersCountTotal = 0)
        {
            InitializeComponent();
            LinesCountTextBox.Text = LinesCount.ToString(CultureInfo.InvariantCulture);
            WordsCountTextBox.Text = WordsCount.ToString(CultureInfo.InvariantCulture);
            CharacterCountNoSpaceTextBox.Text = CharacterCountNoSpace.ToString(CultureInfo.InvariantCulture);
            CharactersCountTotalTextBox.Text = CharactersCountTotal.ToString(CultureInfo.InvariantCulture);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }


}
