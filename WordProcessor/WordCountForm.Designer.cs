namespace WordProcessor
{
    partial class WordCountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LinesCountTextBox = new System.Windows.Forms.Label();
            this.WordsCountTextBox = new System.Windows.Forms.Label();
            this.CharacterCountNoSpaceTextBox = new System.Windows.Forms.Label();
            this.CharactersCountTextBox = new System.Windows.Forms.Label();
            this.LinesLabel = new System.Windows.Forms.Label();
            this.CharactersNoSpacesLabel = new System.Windows.Forms.Label();
            this.WordsLabel = new System.Windows.Forms.Label();
            this.CharacterWithSpacesLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.LabelGroupBox = new System.Windows.Forms.GroupBox();
            this.CountsGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.LabelGroupBox.SuspendLayout();
            this.CountsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LinesCountTextBox
            // 
            this.LinesCountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LinesCountTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LinesCountTextBox.Location = new System.Drawing.Point(38, 118);
            this.LinesCountTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.LinesCountTextBox.Name = "LinesCountTextBox";
            this.LinesCountTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LinesCountTextBox.Size = new System.Drawing.Size(124, 19);
            this.LinesCountTextBox.TabIndex = 0;
            this.LinesCountTextBox.Text = "0";
            // 
            // WordsCountTextBox
            // 
            this.WordsCountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WordsCountTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.WordsCountTextBox.Location = new System.Drawing.Point(38, 86);
            this.WordsCountTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.WordsCountTextBox.Name = "WordsCountTextBox";
            this.WordsCountTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.WordsCountTextBox.Size = new System.Drawing.Size(124, 19);
            this.WordsCountTextBox.TabIndex = 0;
            this.WordsCountTextBox.Text = "0";
            // 
            // CharacterCountNoSpaceTextBox
            // 
            this.CharacterCountNoSpaceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CharacterCountNoSpaceTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CharacterCountNoSpaceTextBox.Location = new System.Drawing.Point(38, 54);
            this.CharacterCountNoSpaceTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.CharacterCountNoSpaceTextBox.Name = "CharacterCountNoSpaceTextBox";
            this.CharacterCountNoSpaceTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CharacterCountNoSpaceTextBox.Size = new System.Drawing.Size(124, 19);
            this.CharacterCountNoSpaceTextBox.TabIndex = 0;
            this.CharacterCountNoSpaceTextBox.Text = "0";
            // 
            // CharactersCountTextBox
            // 
            this.CharactersCountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CharactersCountTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CharactersCountTextBox.Location = new System.Drawing.Point(38, 22);
            this.CharactersCountTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.CharactersCountTextBox.Name = "CharactersCountTextBox";
            this.CharactersCountTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CharactersCountTextBox.Size = new System.Drawing.Size(124, 19);
            this.CharactersCountTextBox.TabIndex = 0;
            this.CharactersCountTextBox.Text = "0";
            // 
            // LinesLabel
            // 
            this.LinesLabel.AutoSize = true;
            this.LinesLabel.Location = new System.Drawing.Point(6, 118);
            this.LinesLabel.Name = "LinesLabel";
            this.LinesLabel.Size = new System.Drawing.Size(51, 20);
            this.LinesLabel.TabIndex = 0;
            this.LinesLabel.Text = "Lines:";
            // 
            // CharactersNoSpacesLabel
            // 
            this.CharactersNoSpacesLabel.AutoSize = true;
            this.CharactersNoSpacesLabel.Location = new System.Drawing.Point(6, 54);
            this.CharactersNoSpacesLabel.Name = "CharactersNoSpacesLabel";
            this.CharactersNoSpacesLabel.Size = new System.Drawing.Size(178, 20);
            this.CharactersNoSpacesLabel.TabIndex = 0;
            this.CharactersNoSpacesLabel.Text = "Characters (no spaces):";
            // 
            // WordsLabel
            // 
            this.WordsLabel.AutoSize = true;
            this.WordsLabel.Location = new System.Drawing.Point(6, 86);
            this.WordsLabel.Name = "WordsLabel";
            this.WordsLabel.Size = new System.Drawing.Size(59, 20);
            this.WordsLabel.TabIndex = 0;
            this.WordsLabel.Text = "Words:";
            // 
            // CharacterWithSpacesLabel
            // 
            this.CharacterWithSpacesLabel.AutoSize = true;
            this.CharacterWithSpacesLabel.Location = new System.Drawing.Point(6, 22);
            this.CharacterWithSpacesLabel.Name = "CharacterWithSpacesLabel";
            this.CharacterWithSpacesLabel.Size = new System.Drawing.Size(188, 20);
            this.CharacterWithSpacesLabel.TabIndex = 0;
            this.CharacterWithSpacesLabel.Text = "Characters (with spaces):";
            // 
            // CloseButton
            // 
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CloseButton.Location = new System.Drawing.Point(0, 163);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(388, 36);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.LabelGroupBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.CountsGroupBox);
            this.splitContainer.Size = new System.Drawing.Size(388, 199);
            this.splitContainer.SplitterDistance = 202;
            this.splitContainer.SplitterWidth = 10;
            this.splitContainer.TabIndex = 9;
            // 
            // LabelGroupBox
            // 
            this.LabelGroupBox.Controls.Add(this.CharacterWithSpacesLabel);
            this.LabelGroupBox.Controls.Add(this.LinesLabel);
            this.LabelGroupBox.Controls.Add(this.WordsLabel);
            this.LabelGroupBox.Controls.Add(this.CharactersNoSpacesLabel);
            this.LabelGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelGroupBox.Location = new System.Drawing.Point(0, 0);
            this.LabelGroupBox.Name = "LabelGroupBox";
            this.LabelGroupBox.Size = new System.Drawing.Size(202, 199);
            this.LabelGroupBox.TabIndex = 0;
            this.LabelGroupBox.TabStop = false;
            // 
            // CountsGroupBox
            // 
            this.CountsGroupBox.Controls.Add(this.LinesCountTextBox);
            this.CountsGroupBox.Controls.Add(this.CharactersCountTextBox);
            this.CountsGroupBox.Controls.Add(this.CharacterCountNoSpaceTextBox);
            this.CountsGroupBox.Controls.Add(this.WordsCountTextBox);
            this.CountsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CountsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.CountsGroupBox.Name = "CountsGroupBox";
            this.CountsGroupBox.Size = new System.Drawing.Size(176, 199);
            this.CountsGroupBox.TabIndex = 0;
            this.CountsGroupBox.TabStop = false;
            // 
            // WordCountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 199);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 255);
            this.Name = "WordCountForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Word Count";
            this.TopMost = true;
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.LabelGroupBox.ResumeLayout(false);
            this.LabelGroupBox.PerformLayout();
            this.CountsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LinesLabel;
        private System.Windows.Forms.Label CharactersNoSpacesLabel;
        private System.Windows.Forms.Label WordsLabel;
        private System.Windows.Forms.Label CharacterWithSpacesLabel;
        public System.Windows.Forms.Button CloseButton;
        public System.Windows.Forms.Label LinesCountTextBox;
        public System.Windows.Forms.Label WordsCountTextBox;
        public System.Windows.Forms.Label CharacterCountNoSpaceTextBox;
        public System.Windows.Forms.Label CharactersCountTextBox;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox LabelGroupBox;
        private System.Windows.Forms.GroupBox CountsGroupBox;
    }
}