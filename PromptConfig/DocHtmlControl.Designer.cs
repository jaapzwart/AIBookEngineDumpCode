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
            SuspendLayout();
            // 
            // btnLoadDocHtml
            // 
            btnLoadDocHtml.Location = new Point(873, 752);
            btnLoadDocHtml.Name = "btnLoadDocHtml";
            btnLoadDocHtml.Size = new Size(94, 29);
            btnLoadDocHtml.TabIndex = 15;
            btnLoadDocHtml.Text = "Load";
            btnLoadDocHtml.UseVisualStyleBackColor = true;
            btnLoadDocHtml.Click += btnLoadDocHtml_Click;
            // 
            // btnSaveDocHtml
            // 
            btnSaveDocHtml.Location = new Point(984, 752);
            btnSaveDocHtml.Name = "btnSaveDocHtml";
            btnSaveDocHtml.Size = new Size(94, 29);
            btnSaveDocHtml.TabIndex = 14;
            btnSaveDocHtml.Text = "Save";
            btnSaveDocHtml.UseVisualStyleBackColor = true;
            btnSaveDocHtml.Click += btnSaveDocHtml_Click;
            // 
            // txtFirstForePrompt
            // 
            txtFirstForePrompt.Location = new Point(206, 186);
            txtFirstForePrompt.Multiline = true;
            txtFirstForePrompt.Name = "txtFirstForePrompt";
            txtFirstForePrompt.ScrollBars = ScrollBars.Vertical;
            txtFirstForePrompt.Size = new Size(985, 151);
            txtFirstForePrompt.TabIndex = 13;
            // 
            // txtImagePrefix
            // 
            txtImagePrefix.Location = new Point(206, 146);
            txtImagePrefix.Multiline = true;
            txtImagePrefix.Name = "txtImagePrefix";
            txtImagePrefix.Size = new Size(983, 34);
            txtImagePrefix.TabIndex = 12;
            // 
            // txtTitlePrefix
            // 
            txtTitlePrefix.Location = new Point(206, 11);
            txtTitlePrefix.Multiline = true;
            txtTitlePrefix.Name = "txtTitlePrefix";
            txtTitlePrefix.ScrollBars = ScrollBars.Vertical;
            txtTitlePrefix.Size = new Size(983, 129);
            txtTitlePrefix.TabIndex = 11;
            // 
            // lblFirstPageInit
            // 
            lblFirstPageInit.AutoSize = true;
            lblFirstPageInit.Location = new Point(17, 189);
            lblFirstPageInit.Name = "lblFirstPageInit";
            lblFirstPageInit.Size = new Size(125, 20);
            lblFirstPageInit.TabIndex = 10;
            lblFirstPageInit.Text = "First Fore Prompt:";
            // 
            // lblFirstImagePrefix
            // 
            lblFirstImagePrefix.AutoSize = true;
            lblFirstImagePrefix.Location = new Point(17, 146);
            lblFirstImagePrefix.Name = "lblFirstImagePrefix";
            lblFirstImagePrefix.Size = new Size(126, 20);
            lblFirstImagePrefix.TabIndex = 9;
            lblFirstImagePrefix.Text = "First Image Prefix:";
            // 
            // lblTitlePrefix
            // 
            lblTitlePrefix.AutoSize = true;
            lblTitlePrefix.Location = new Point(18, 14);
            lblTitlePrefix.Name = "lblTitlePrefix";
            lblTitlePrefix.Size = new Size(80, 20);
            lblTitlePrefix.TabIndex = 8;
            lblTitlePrefix.Text = "Title prefix";
            // 
            // txtSecondRunningPrompt
            // 
            txtSecondRunningPrompt.Location = new Point(208, 343);
            txtSecondRunningPrompt.Multiline = true;
            txtSecondRunningPrompt.Name = "txtSecondRunningPrompt";
            txtSecondRunningPrompt.ScrollBars = ScrollBars.Vertical;
            txtSecondRunningPrompt.Size = new Size(983, 288);
            txtSecondRunningPrompt.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 346);
            label1.Name = "label1";
            label1.Size = new Size(172, 20);
            label1.TabIndex = 16;
            label1.Text = "Second Running Prompt:";
            // 
            // btnSaveAsDocHtml
            // 
            btnSaveAsDocHtml.Location = new Point(1097, 752);
            btnSaveAsDocHtml.Name = "btnSaveAsDocHtml";
            btnSaveAsDocHtml.Size = new Size(94, 29);
            btnSaveAsDocHtml.TabIndex = 18;
            btnSaveAsDocHtml.Text = "Save As";
            btnSaveAsDocHtml.UseVisualStyleBackColor = true;
            // 
            // txtExtraTouch
            // 
            txtExtraTouch.Location = new Point(206, 637);
            txtExtraTouch.Multiline = true;
            txtExtraTouch.Name = "txtExtraTouch";
            txtExtraTouch.Size = new Size(985, 75);
            txtExtraTouch.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 640);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 19;
            label2.Text = "The Extra Touch:";
            // 
            // DocHtmlControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
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
            Name = "DocHtmlControl";
            Size = new Size(1221, 888);
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
    }
}
