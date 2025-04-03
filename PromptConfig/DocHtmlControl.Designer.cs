namespace PromptConfig
{
    partial class DocHtmlControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLoadDocHtml = new Button();
            btnSaveDocHtml = new Button();
            txtFirstForePrompt = new TextBox();
            txtImagePrefix = new TextBox();
            txtTitlePrefix = new TextBox();
            lblFirstPageInit = new Label();
            lblFirstImagePrefix = new Label();
            lblTitlePrefix = new Label();
            txtSecondRunningPrompt = new TextBox();
            label1 = new Label();
            btnSaveAsDocHtml = new Button();
            txtExtraTouch = new TextBox();
            label2 = new Label();
            cmbTypeOfBook = new ComboBox();
            lblTypeOfBook = new Label();
            btnCheckPrompts = new Button();
            txtBookGoals = new TextBox();
            lblBookGoals = new Label();
            picForePromptStatus = new PictureBox();
            picSecondPromptStatus = new PictureBox();
            picTitlePrefixPromptStatus = new PictureBox();
            lblStatus = new Label();
            btnGeneratePrompts = new Button();
            ((System.ComponentModel.ISupportInitialize)picForePromptStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSecondPromptStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTitlePrefixPromptStatus).BeginInit();
            SuspendLayout();
            // 
            // btnLoadDocHtml
            // 
            btnLoadDocHtml.Location = new Point(764, 564);
            btnLoadDocHtml.Margin = new Padding(3, 2, 3, 2);
            btnLoadDocHtml.Name = "btnLoadDocHtml";
            btnLoadDocHtml.Size = new Size(82, 22);
            btnLoadDocHtml.TabIndex = 15;
            btnLoadDocHtml.Text = "Load";
            btnLoadDocHtml.UseVisualStyleBackColor = true;
            btnLoadDocHtml.Click += btnLoadDocHtml_Click;
            // 
            // btnSaveDocHtml
            // 
            btnSaveDocHtml.Location = new Point(861, 564);
            btnSaveDocHtml.Margin = new Padding(3, 2, 3, 2);
            btnSaveDocHtml.Name = "btnSaveDocHtml";
            btnSaveDocHtml.Size = new Size(82, 22);
            btnSaveDocHtml.TabIndex = 14;
            btnSaveDocHtml.Text = "Save";
            btnSaveDocHtml.UseVisualStyleBackColor = true;
            btnSaveDocHtml.Click += btnSaveDocHtml_Click;
            // 
            // txtFirstForePrompt
            // 
            txtFirstForePrompt.Location = new Point(180, 140);
            txtFirstForePrompt.Margin = new Padding(3, 2, 3, 2);
            txtFirstForePrompt.Multiline = true;
            txtFirstForePrompt.Name = "txtFirstForePrompt";
            txtFirstForePrompt.ScrollBars = ScrollBars.Vertical;
            txtFirstForePrompt.Size = new Size(872, 114);
            txtFirstForePrompt.TabIndex = 13;
            // 
            // txtImagePrefix
            // 
            txtImagePrefix.Location = new Point(180, 110);
            txtImagePrefix.Margin = new Padding(3, 2, 3, 2);
            txtImagePrefix.Multiline = true;
            txtImagePrefix.Name = "txtImagePrefix";
            txtImagePrefix.Size = new Size(872, 26);
            txtImagePrefix.TabIndex = 12;
            // 
            // txtTitlePrefix
            // 
            txtTitlePrefix.Location = new Point(180, 8);
            txtTitlePrefix.Margin = new Padding(3, 2, 3, 2);
            txtTitlePrefix.Multiline = true;
            txtTitlePrefix.Name = "txtTitlePrefix";
            txtTitlePrefix.ScrollBars = ScrollBars.Vertical;
            txtTitlePrefix.Size = new Size(872, 98);
            txtTitlePrefix.TabIndex = 11;
            // 
            // lblFirstPageInit
            // 
            lblFirstPageInit.AutoSize = true;
            lblFirstPageInit.Location = new Point(15, 142);
            lblFirstPageInit.Name = "lblFirstPageInit";
            lblFirstPageInit.Size = new Size(101, 15);
            lblFirstPageInit.TabIndex = 10;
            lblFirstPageInit.Text = "First Fore Prompt:";
            // 
            // lblFirstImagePrefix
            // 
            lblFirstImagePrefix.AutoSize = true;
            lblFirstImagePrefix.Location = new Point(15, 110);
            lblFirstImagePrefix.Name = "lblFirstImagePrefix";
            lblFirstImagePrefix.Size = new Size(101, 15);
            lblFirstImagePrefix.TabIndex = 9;
            lblFirstImagePrefix.Text = "First Image Prefix:";
            // 
            // lblTitlePrefix
            // 
            lblTitlePrefix.AutoSize = true;
            lblTitlePrefix.Location = new Point(16, 10);
            lblTitlePrefix.Name = "lblTitlePrefix";
            lblTitlePrefix.Size = new Size(62, 15);
            lblTitlePrefix.TabIndex = 8;
            lblTitlePrefix.Text = "Title prefix";
            // 
            // txtSecondRunningPrompt
            // 
            txtSecondRunningPrompt.Location = new Point(182, 257);
            txtSecondRunningPrompt.Margin = new Padding(3, 2, 3, 2);
            txtSecondRunningPrompt.Multiline = true;
            txtSecondRunningPrompt.Name = "txtSecondRunningPrompt";
            txtSecondRunningPrompt.ScrollBars = ScrollBars.Vertical;
            txtSecondRunningPrompt.Size = new Size(870, 217);
            txtSecondRunningPrompt.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 260);
            label1.Name = "label1";
            label1.Size = new Size(140, 15);
            label1.TabIndex = 16;
            label1.Text = "Second Running Prompt:";
            // 
            // btnSaveAsDocHtml
            // 
            btnSaveAsDocHtml.Location = new Point(960, 564);
            btnSaveAsDocHtml.Margin = new Padding(3, 2, 3, 2);
            btnSaveAsDocHtml.Name = "btnSaveAsDocHtml";
            btnSaveAsDocHtml.Size = new Size(82, 22);
            btnSaveAsDocHtml.TabIndex = 18;
            btnSaveAsDocHtml.Text = "Save As";
            btnSaveAsDocHtml.UseVisualStyleBackColor = true;
            btnSaveAsDocHtml.Click += btnSaveAsDocHtml_Click;
            // 
            // txtExtraTouch
            // 
            txtExtraTouch.Location = new Point(180, 478);
            txtExtraTouch.Margin = new Padding(3, 2, 3, 2);
            txtExtraTouch.Multiline = true;
            txtExtraTouch.Name = "txtExtraTouch";
            txtExtraTouch.ScrollBars = ScrollBars.Vertical;
            txtExtraTouch.Size = new Size(872, 57);
            txtExtraTouch.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 480);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 19;
            label2.Text = "The Extra Touch:";
            // 
            // cmbTypeOfBook
            // 
            cmbTypeOfBook.FormattingEnabled = true;
            cmbTypeOfBook.Items.AddRange(new object[] { "Science Fiction", "Horror", "Thriller", "Detective", "Urban", "Fantasy", "Techno Sci Fi" });
            cmbTypeOfBook.Location = new Point(180, 547);
            cmbTypeOfBook.Margin = new Padding(3, 2, 3, 2);
            cmbTypeOfBook.Name = "cmbTypeOfBook";
            cmbTypeOfBook.Size = new Size(238, 23);
            cmbTypeOfBook.TabIndex = 21;
            cmbTypeOfBook.Text = "Science Fiction";
            // 
            // lblTypeOfBook
            // 
            lblTypeOfBook.AutoSize = true;
            lblTypeOfBook.Location = new Point(24, 549);
            lblTypeOfBook.Name = "lblTypeOfBook";
            lblTypeOfBook.Size = new Size(78, 15);
            lblTypeOfBook.TabIndex = 22;
            lblTypeOfBook.Text = "Type of book:";
            // 
            // btnCheckPrompts
            // 
            btnCheckPrompts.Location = new Point(434, 546);
            btnCheckPrompts.Margin = new Padding(3, 2, 3, 2);
            btnCheckPrompts.Name = "btnCheckPrompts";
            btnCheckPrompts.Size = new Size(276, 22);
            btnCheckPrompts.TabIndex = 23;
            btnCheckPrompts.Text = "Check Prompts against your goals";
            btnCheckPrompts.UseVisualStyleBackColor = true;
            btnCheckPrompts.Click += btnCheckPrompts_Click;
            // 
            // txtBookGoals
            // 
            txtBookGoals.Location = new Point(15, 615);
            txtBookGoals.Margin = new Padding(3, 2, 3, 2);
            txtBookGoals.Multiline = true;
            txtBookGoals.Name = "txtBookGoals";
            txtBookGoals.ScrollBars = ScrollBars.Vertical;
            txtBookGoals.Size = new Size(1037, 93);
            txtBookGoals.TabIndex = 24;
            // 
            // lblBookGoals
            // 
            lblBookGoals.AutoSize = true;
            lblBookGoals.Location = new Point(16, 598);
            lblBookGoals.Name = "lblBookGoals";
            lblBookGoals.Size = new Size(68, 15);
            lblBookGoals.TabIndex = 25;
            lblBookGoals.Text = "Book goals:";
            // 
            // picForePromptStatus
            // 
            picForePromptStatus.Location = new Point(143, 226);
            picForePromptStatus.Margin = new Padding(3, 2, 3, 2);
            picForePromptStatus.Name = "picForePromptStatus";
            picForePromptStatus.Size = new Size(32, 27);
            picForePromptStatus.TabIndex = 26;
            picForePromptStatus.TabStop = false;
            // 
            // picSecondPromptStatus
            // 
            picSecondPromptStatus.Location = new Point(143, 446);
            picSecondPromptStatus.Margin = new Padding(3, 2, 3, 2);
            picSecondPromptStatus.Name = "picSecondPromptStatus";
            picSecondPromptStatus.Size = new Size(32, 27);
            picSecondPromptStatus.TabIndex = 27;
            picSecondPromptStatus.TabStop = false;
            // 
            // picTitlePrefixPromptStatus
            // 
            picTitlePrefixPromptStatus.Location = new Point(143, 78);
            picTitlePrefixPromptStatus.Margin = new Padding(3, 2, 3, 2);
            picTitlePrefixPromptStatus.Name = "picTitlePrefixPromptStatus";
            picTitlePrefixPromptStatus.Size = new Size(32, 27);
            picTitlePrefixPromptStatus.TabIndex = 28;
            picTitlePrefixPromptStatus.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(764, 710);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(16, 15);
            lblStatus.TabIndex = 29;
            lblStatus.Text = "...";
            // 
            // btnGeneratePrompts
            // 
            btnGeneratePrompts.Location = new Point(434, 580);
            btnGeneratePrompts.Margin = new Padding(3, 2, 3, 2);
            btnGeneratePrompts.Name = "btnGeneratePrompts";
            btnGeneratePrompts.Size = new Size(276, 22);
            btnGeneratePrompts.TabIndex = 30;
            btnGeneratePrompts.Text = "Generate prompts on plotline";
            btnGeneratePrompts.UseVisualStyleBackColor = true;
            btnGeneratePrompts.Click += btnGeneratePrompts_Click;
            // 
            // DocHtmlControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnGeneratePrompts);
            Controls.Add(lblStatus);
            Controls.Add(picTitlePrefixPromptStatus);
            Controls.Add(picSecondPromptStatus);
            Controls.Add(picForePromptStatus);
            Controls.Add(lblBookGoals);
            Controls.Add(txtBookGoals);
            Controls.Add(btnCheckPrompts);
            Controls.Add(lblTypeOfBook);
            Controls.Add(cmbTypeOfBook);
            Controls.Add(txtExtraTouch);
            Controls.Add(label2);
            Controls.Add(btnSaveAsDocHtml);
            Controls.Add(txtSecondRunningPrompt);
            Controls.Add(label1);
            Controls.Add(btnLoadDocHtml);
            Controls.Add(btnSaveDocHtml);
            Controls.Add(txtFirstForePrompt);
            Controls.Add(txtImagePrefix);
            Controls.Add(txtTitlePrefix);
            Controls.Add(lblFirstPageInit);
            Controls.Add(lblFirstImagePrefix);
            Controls.Add(lblTitlePrefix);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DocHtmlControl";
            Size = new Size(1068, 729);
            Load += DocHtmlControl_Load;
            ((System.ComponentModel.ISupportInitialize)picForePromptStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSecondPromptStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)picTitlePrefixPromptStatus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadDocHtml;
        private Button btnSaveDocHtml;
        private TextBox txtFirstForePrompt;
        private TextBox txtImagePrefix;
        private TextBox txtTitlePrefix;
        private Label lblFirstPageInit;
        private Label lblFirstImagePrefix;
        private Label lblTitlePrefix;
        private TextBox txtSecondRunningPrompt;
        private Label label1;
        private Button btnSaveAsDocHtml;
        private TextBox txtExtraTouch;
        private Label label2;
        private ComboBox cmbTypeOfBook;
        private Label lblTypeOfBook;
        private Button btnCheckPrompts;
        private TextBox txtBookGoals;
        private Label lblBookGoals;
        private PictureBox picForePromptStatus;
        private PictureBox picSecondPromptStatus;
        private PictureBox picTitlePrefixPromptStatus;
        private Label lblStatus;
        private Button btnGeneratePrompts;
    }
}
