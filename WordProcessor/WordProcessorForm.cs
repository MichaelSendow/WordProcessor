using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace WordProcessor
{
    /// <summary>
    /// Class that will fullfill the Version 3 of the second assignment of the course DVGB07,vt20 C#.NET 34465
    /// </summary>
    public partial class MyWordProcessor : Form
    {
        //Predicate to keep track if document has changed.
        private bool documentChanged = false;

        //The current file that is open.
        private string filePathName = "";

        //Some constants to set default filename and dialog-directory
        private const string defaultFileName = "dok1.txt";
        private const string initialDirectory = "%HomePath%\\Documents\\";

        //If the BGW is running when a exit is issued I need it to finish up and then exit the program.
        //This ensures it.
        private bool closeRequested = false;

        //Counters for the informationrow
        private int characterCount = 0;
        private int whitespaceCount = 0;
        private int wordCount = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        public MyWordProcessor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the form is loaded I set the titlebar text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WordProcessor_Load(object sender, EventArgs e)
        {
            //Set the titlebar text
            this.Text = $"{defaultFileName} - Vörd";

        }

        //Event-driven methods

        /// <summary>
        /// Displays the About-dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vörd 1.0" + "\r\n" + "Created by: Michael Sendow, 2020-02-17" + "\r\n" +
                "Created why: DVGB07,vt20 C#.NET 34465", "About Vörd");
        }

        /// <summary>
        /// Maintains the correct values for the word count feature without locking up the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //After some trial and error it seems to be alot faster to iterate over a copy of mainTextBox.Text than iterating over the textbox itself
            //It also seemed to slow down if I used progressreporting on the worker, so that got cut.

            char[] temporaryCharArray = mainTextBox.Text.ToCharArray();

            //Reset the counters
            characterCount = 0;
            whitespaceCount = 0;
            wordCount = 0;

            //Predicate to keep track of if we are in a word or not
            bool newWord = false;

            BackgroundWorker worker = sender as BackgroundWorker;

            //Loop through the entire text and determine the characteristics of it!
            foreach (char character in temporaryCharArray)
            {
                //A Close() or cancel was requested while work was being done by the backgroundworker.
                //No one is interested in the result so might as well break and end the work.

                if (worker.CancellationPending == true || closeRequested == true)
                {
                    e.Cancel = true;
                    break;
                }
                //If the character is carrige return or linefeed we are not in a word
                //set the predicate to false
                else if (character == '\r' || character == '\n')
                {
                    newWord = false;
                }
                //Character is not a whitespace
                else if (char.IsWhiteSpace(character) == false)
                {
                    //Count it!
                    characterCount++;

                    //We might have detected a new word! 
                    //If newWord is false we have detected a newWord.
                    //If newWord is true we are still in a old word and have already counted it.
                    //Let's only count if it's a new word and then set the newWord-predicate to true.
                    if (newWord == false)
                    {
                        wordCount++;
                        newWord = true;
                    }
                }
                //Count the whitespace and set the newWord-predicate to false since we are no longer in a word
                else
                {
                    //Count the whitespace!
                    whitespaceCount++;
                    newWord = false;
                }

            }
        }

        /// <summary>
        /// Runs when the backgroundworker has completed its work. Will start the BGW again if it was cancelled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Just in case something would go wrong with the BGW
            if (e.Error != null)
            {

                MessageBox.Show(e.Error.Message, "BackgroundWorker fault", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (e.Cancelled == false)
            {
                //Update the InfromationRowLabels with the work of the BGW
                charactersToolStripLabel.Text = $"{characterCount + whitespaceCount}";
                charactersNoWhitespacesToolStripLabel.Text = $"{characterCount}";
                wordsToolStripLabel.Text = $"{wordCount}";
                linesToolStripLabel.Text = mainTextBox.Lines.Length.ToString(CultureInfo.InvariantCulture);
            }
            //If the worker was canceled run it again.
            else if (e.Cancelled == true)
            {
                backgroundWorker.RunWorkerAsync();
            }

            //A Close() has been requested while the backgroundworker was busy. Let's close the program now that the BGW is completed.
            //Wait for BackgroundWorker finish, if running, at FormClosing time
            //https://stackoverflow.com/questions/45335750/wait-for-backgroundworker-finish-if-running-at-formclosing-time
            //2020-02-13
            if (closeRequested)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Copies the selected text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainTextBox.SelectionLength > 0)
            {
                mainTextBox.Copy();
            }
        }

        /// <summary>
        /// Cuts the selected text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainTextBox.SelectionLength != 0)
            {
                mainTextBox.Cut();
            }
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //i.e Form.Close() - Signals that user wants to close the application
            this.Close();
        }

        /// <summary>
        /// Opens the Font-dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Changes fontsettings.
            fontDialog.ShowColor = true;
            fontDialog.Font = mainTextBox.Font;
            fontDialog.Color = mainTextBox.ForeColor;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                //Change the font and color if users clicked on OK
                mainTextBox.Font = fontDialog.Font;
                mainTextBox.ForeColor = fontDialog.Color;
                mainTextBox.ScrollToCaret();
                //The textbox was misbehaving, this forces a redraw.
                mainTextBox.Visible = false;
                mainTextBox.Visible = true;
                mainTextBox.Focus();
            }
        }

        /// <summary>
        /// Shows a dialog of the WordCount form. It will calculate the values by itself to ensure correct numbers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InformationrRowToolStripLabel_Click(object sender, EventArgs e)
        {

            //Do a new word count
            int[] CountArray = UpdateLabels();

            using (WordCountForm wordCountForm = new WordCountForm(
                mainTextBox.Lines.Length,
                CountArray[2],
                CountArray[0],
                CountArray[0] + CountArray[1]))
            {
                wordCountForm.ShowDialog();
            }
        }

        /// <summary>
        /// Manages the drag and drop feature.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTextBox_DragDrop(object sender, DragEventArgs e)
        {
            var droppedData = e.Data.GetData(DataFormats.FileDrop);
            string[] fileNames = droppedData as string[];
            if (fileNames.Length > 0)
            {
                switch (Form.ModifierKeys)
                {
                    //Uncertain what the difference is so I just put in both keys.
                    //Ctrl-modifier should append at end of document.
                    case Keys.ControlKey:
                    case Keys.Control:
                        {
                            foreach (string fileName in fileNames)
                            {
                                //I allow for multiple files to be appended to the textbox
                                DragAndDropAppendFiles(fileName);
                            }
                        }
                        break;
                    //Uncertain what the difference is so I just put in both keys.
                    //Shift modifier should append file at cursor
                    case Keys.ShiftKey:
                    case Keys.Shift:
                        {
                            foreach (string fileName in fileNames)
                            {
                                //I allow for multiple files to be inserted at the cursor.
                                DragAndDropAppendFiles(fileName, true);
                            }
                        }
                        break;
                    default:
                        {
                            //Default action is to open the dropped file
                            if (droppedData != null)
                            {
                                if (fileNames.Length > 0 && fileNames.Length == 1)
                                {
                                    //I only allow for 1 file to be opened at a time
                                    DragAndDropOpenFile(fileNames[0]);
                                }
                                else
                                {
                                    //And I inform the user that's the case.

                                    MessageBox.Show("Only one file can be opened at a time.",


                                        "Drag and Drop: Open file",

                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                }

                            }
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Checks that it is a file that has been dropped into the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTextBox_DragEnter(object sender, DragEventArgs e)
        {
            //Check that it is a file that has been dropped into the textbox
            //If it is a file I allow it. Otherwise I deny it.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Maintains status of document and manages the backgroundworker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTextBox_TextChanged(object sender, EventArgs e)
        {
            //What todo when the text changes

            //1.Mark document as changed if it's not already
            if (documentChanged == false)
            {
                documentChanged = true;

                //2. Add a * to the "filename" in the Form title.
                if (filePathName.Length == 0)
                {
                    this.Text = $"{defaultFileName}* - Vörd";
                }
                else
                {
                    this.Text = $"{Path.GetFileName(filePathName)}* - Vörd";
                }

            }
            //3.Update the labels via a background worker as to not freeze up the UI.
            //I only run one bgw at a time. If it is running cancel it since it will get the latest and greatest values
            //I will start it again in BackgroundWorker_RunWorkerCompleted method
            if (backgroundWorker.IsBusy != true)
            {
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                backgroundWorker.CancelAsync();
            }
        }

        /// <summary>
        /// Resets the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            int selectionStart = mainTextBox.SelectionStart;
            int selectionLength = mainTextBox.SelectionLength;

            if (documentChanged == true)
            {
                result = AskIfUserWantsToSaveFile();

                if (result == DialogResult.Yes)
                {
                    result = SaveFile();
                    //If the user clicked on cancel we do nothing. 
                    //Only if the document was saved do we open a new one.
                    if (result == DialogResult.OK)
                    {
                        NewWindow();
                    }
                }
                else if (result == DialogResult.No)
                {
                    NewWindow();
                }
                else if (result == DialogResult.Cancel)
                {
                    //Sometimes the text was beeing selected. This is to ensure nothing changed
                    mainTextBox.SelectionStart = selectionStart;
                    mainTextBox.SelectionLength = selectionLength;
                }
            }
            else
            {
                //No need to save an unchanged document.
                NewWindow();
            }
        }

        /// <summary>
        /// Opens a new file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;

            if (documentChanged == true)
            {
                result = AskIfUserWantsToSaveFile();

                if (result == DialogResult.Yes)
                {
                    result = SaveFile();
                    //If the user clicked on cancel we do nothing. 
                    //Only if the document was saved do we proceed to ask to open the new one.
                    if (result == DialogResult.OK)
                    {
                        OpenFile();
                    }
                }
                else if (result == DialogResult.No)
                {
                    OpenFile();

                }
            }
            else
            {
                OpenFile();
            }


        }

        /// <summary>
        /// If the clipboard contains text it pastes it to the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                mainTextBox.Paste();
            }
        }

        /// <summary>
        /// Calls the SaveAsFile() method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        /// <summary>
        /// Calls the SaveFile() method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        /// <summary>
        /// Selects all text in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.SelectAll();
        }

        /// <summary>
        /// Uses the rudimentary undo feature of the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //The built in undo-stack is not great but it's something at least.
            if (mainTextBox.CanUndo == true)
            {
                mainTextBox.Undo();
            }
        }

        /// <summary>
        /// This method is run when a Close() has been initiated. It does some cleanup of the BGW and asks user to save changes before quitting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WordProcessor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //This method is run when a Close() has been initiated. 
            //It is called before any Dispose() is called.

            //Document is changed, ask user to save before shutdown
            if (documentChanged == true)
            {
                DialogResult result;
                result = AskIfUserWantsToSaveFile();

                //User wants to save changes and quit
                if (result == DialogResult.Yes)
                {
                    result = SaveFile();
                    //File is saved. Proceed to shutdown the program
                    if (result == DialogResult.OK)
                    {
                        //If BGW is busy we have to wait for it.
                        if (backgroundWorker.IsBusy == true)
                        {
                            //Cancel the shutdown but signal to BGW to try to shutdown the program when it has finishd its work
                            e.Cancel = true;
                            closeRequested = true; //<- the signal to the bgw
                        }
                    }
                    else
                    {
                        //User didn't save so we cancel the shutdown.
                        e.Cancel = true;
                    }
                }
                //Didn't want to quit after all. Cancel the shutdown
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                //User does not want to save changes.
                else if (result == DialogResult.No)
                {
                    //If BGW is busy we have to wait for it.
                    if (backgroundWorker.IsBusy == true)
                    {
                        //Cancel the shutdown but signal to BGW to try to shutdown the program when it has finishd its work
                        e.Cancel = true;
                        closeRequested = true; //<- the signal to the bgw
                    }
                }
            }
            else //Document doesn't need saving
            {
                //If BGW is busy we have to wait for it.
                if (backgroundWorker.IsBusy == true)
                {
                    //Cancel the shutdown but signal to BGW to try to shutdown the program when it has finishd its work
                    e.Cancel = true;
                    closeRequested = true; //<- the signal to the bgw
                }
            }
        }
        /// <summary>
        /// Toggles WordWrap on or off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Quick and easy way to flip the predicate for wordwrap
            int selectionStart = mainTextBox.SelectionStart;
            mainTextBox.WordWrap = !mainTextBox.WordWrap;
            mainTextBox.SelectionStart = selectionStart;
            mainTextBox.ScrollToCaret();
            mainTextBox.Focus();
        }

        //Auxiliary methods

        /// <summary>
        /// Shows a dialog that asks if user wants to save changes to the opened document.
        /// </summary>
        /// <returns>DialogResult</returns>
        private DialogResult AskIfUserWantsToSaveFile()
        {
            //Method for asking the user to save changes
            DialogResult result;

            if (filePathName.Length != 0)
            {
                result = MessageBox.Show(
                $"Do you want to save changes to {filePathName}?",
                "Save changes?",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
            }
            else
            {
                result = MessageBox.Show(
                $"Do you want to save changes to {defaultFileName}?",
                "Save changes?",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
            }

            return result;
        }

        /// <summary>
        /// Appends or inserts text into the mainTextBox.Text
        /// </summary>
        /// <param name="fileName">Path and filename to the file to be appended</param>
        /// <param name="insertAtCursor">If true inserts the text at cursor otherwise at end of text</param>
        private void DragAndDropAppendFiles(string fileName, bool insertAtCursor = false)
        {
            //Method to append textfiles to the document.

            //Default it appends text at the end of the document
            if (insertAtCursor == false)
            {
                mainTextBox.AppendText(File.ReadAllText(fileName));
                mainTextBox.SelectionStart = mainTextBox.Text.Length;
                mainTextBox.SelectionLength = 0;
            }
            else
            {
                //Otherwise it inserts it at cursor
                int cursorPosition = mainTextBox.SelectionStart;
                //I need to keep track of the length of the "original document" to be able to move the cursor. 
                //This way I get the length of the inserted text implicitly
                int oldLength = mainTextBox.Text.Length;

                //insert the file at cursorPosition
                mainTextBox.Text = mainTextBox.Text.Insert(cursorPosition, File.ReadAllText(fileName));

                //Move cursor to end of inserted text. 
                //new document length - old document length = inserted text length
                //oldposition + inserted document length = new cursor position. 
                //MATH!!!
                mainTextBox.SelectionStart = cursorPosition + mainTextBox.Text.Length - oldLength;
                //Make sure nothing is selected
                mainTextBox.SelectionLength = 0;
                mainTextBox.ScrollToCaret();
                mainTextBox.Focus();
            }
        }

        /// <summary>
        /// Opens the dragged and dropped file. Asks user to save changes if applicable.
        /// </summary>
        /// <param name="fileName"></param>
        private void DragAndDropOpenFile(string fileName)
        {
            DialogResult result;

            if (documentChanged == true)
            {
                result = AskIfUserWantsToSaveFile();

                if (result == DialogResult.Yes)
                {
                    result = SaveFile();
                    //If the user clicked on cancel we do nothing. 
                    //Only if the document was saved do we open the new one.
                    if (result == DialogResult.OK)
                    {
                        OpenFile(fileName);
                    }
                }
                else if (result == DialogResult.No)
                {
                    OpenFile(fileName);
                }
            }
            else
            {
                OpenFile(fileName);
            }
        }

        /// <summary>
        /// Clears the textbox
        /// </summary>
        /// <returns></returns>
        private DialogResult NewWindow()
        {
            //Resets the textbox
            DialogResult result;

            mainTextBox.Text = "";
            documentChanged = false;
            filePathName = "";
            this.Text = $"{defaultFileName} - Vörd";
            result = DialogResult.OK;

            return result;
        }

        /// <summary>
        /// Opens file via a dialog or via provided path and filename
        /// </summary>
        /// <param name="droppedFileName">Path and filename</param>
        /// <returns></returns>
        private DialogResult OpenFile(string droppedFileName = null)
        {
            //Opensfile either via a dialog or via a path. Default is via dialog.

            DialogResult result;

            if (droppedFileName == null)
            {
                result = openFileDialog.ShowDialog();
            }
            else
            {
                filePathName = droppedFileName;
                result = DialogResult.OK;
            }

            if (result == DialogResult.OK)
            {
                try
                {
                    if (droppedFileName == null)
                    {
                        filePathName = openFileDialog.FileName;
                    }

                    mainTextBox.Text = File.ReadAllText(filePathName);
                    mainTextBox.SelectionStart = mainTextBox.TextLength;
                    mainTextBox.SelectionLength = 0;
                    mainTextBox.ScrollToCaret();
                    this.Text = $"{ Path.GetFileName(filePathName)} - Vörd";
                    documentChanged = false;
                    mainTextBox.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Something went wrong.\r\nError Message: {ex.Message}\r\n" +
                            $"Details:\r\n{ex.StackTrace}", "OpenFile()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = DialogResult.Abort;
                }
            }
            return result;
        }

        /// <summary>
        /// Saves document to a new file via dialog
        /// </summary>
        /// <returns></returns>
        private DialogResult SaveAsFile()
        {
            DialogResult result;

            if (filePathName.Length == 0)
            {
                saveFileDialog.InitialDirectory = initialDirectory;
                saveFileDialog.FileName = defaultFileName;
            }

            try
            {
                result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    filePathName = saveFileDialog.FileName;
                    File.WriteAllText(filePathName, mainTextBox.Text);
                    documentChanged = false;
                    this.Text = $"{Path.GetFileName(filePathName)} - Vörd";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Something went wrong.\r\nError Message: {ex.Message}\r\n" +
                    $"Details:\r\n{ex.StackTrace}", "SaveAsToolStripMenuItem_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = DialogResult.Abort;
            }
            return result;
        }

        /// <summary>
        /// Saves the file to filePathName (public variable)
        /// </summary>
        /// <returns></returns>
        private DialogResult SaveFile()
        {
            DialogResult result;

            try
            {
                if (filePathName.Length != 0)
                {
                    //filePathName is already set and file is "open"
                    File.WriteAllText(filePathName, mainTextBox.Text);
                    documentChanged = false;
                    this.Text = $"{Path.GetFileName(filePathName)} - Vörd";
                    result = DialogResult.OK;
                }
                else
                {
                    result = SaveAsFile();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Something went wrong\r\nError Message: {ex.Message}\r\n" +
                    $"Details:\r\n{ex.StackTrace}", "SaveFile()", MessageBoxButtons.OK, MessageBoxIcon.Error);

                result = DialogResult.Abort;
            }
            return result;
        }

        /// <summary>
        /// Returns an int-array containing the character-count, whitespace-count and word-count of the mainTextBox.Text
        /// </summary>
        /// <returns>int[characterCount, whitespacecount, wordcount]</returns>
        private int[] UpdateLabels()
        {
            //Basicly a copy of the bgw-do work method but without interfering with the informationbars counters
            //After some trial and error it seems to be alot faster to iterate over a copy of mainTextBox.Text than iterating over the textbox itself

            char[] temporaryCharArray = mainTextBox.Text.ToCharArray();

            //Reset the counters
            int characterCount = 0;
            int whitespaceCount = 0;
            int wordCount = 0;

            //Predicate to keep track of if we are in a word or not
            bool newWord = false;

            //Loop through the entire text and determine the characteristics of it!

            foreach (char character in temporaryCharArray)
            {
                //If the character is carrige return or linefeed we are not in a word
                //set the predicate to false
                if (character == '\r' || character == '\n')
                {
                    newWord = false;
                }
                //Character is not a whitespace
                else if (char.IsWhiteSpace(character) == false)
                {
                    //Count it!
                    characterCount++;

                    //We might have detected a new word! 
                    //If newWord is false we have detected a newWord.
                    //If newWord is true we are still in a old word and have already counted it.
                    //Let's only count if it's a new word and then toggle the predicate to true.
                    if (newWord == false)
                    {
                        wordCount++;
                        newWord = true;
                    }
                }
                //Count the whitespace and set the predicate to false since we are no longer in a word
                else
                {
                    //Count the whitespace!
                    whitespaceCount++;
                    newWord = false;
                }

            }

            return new int[] { characterCount, whitespaceCount, wordCount };
        }

    }
}