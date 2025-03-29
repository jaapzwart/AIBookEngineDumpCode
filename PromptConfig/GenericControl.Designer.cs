namespace PromptConfig
{
    partial class GenericControl
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
            lblImageHtmlTop = new Label();
            lblTitleOfBook = new Label();
            lblFirstPageInit = new Label();
            txtMainHtmlImageTop = new TextBox();
            txtTitleBook = new TextBox();
            txtFirstPageInitiation = new TextBox();
            btnSave = new Button();
            btnLoad = new Button();
            SuspendLayout();
            // 
            // lblImageHtmlTop
            // 
            lblImageHtmlTop.AutoSize = true;
            lblImageHtmlTop.Location = new Point(38, 37);
            lblImageHtmlTop.Name = "lblImageHtmlTop";
            lblImageHtmlTop.Size = new Size(174, 20);
            lblImageHtmlTop.TabIndex = 0;
            lblImageHtmlTop.Text = "Main Html Image at Top:";
            // 
            // lblTitleOfBook
            // 
            lblTitleOfBook.AutoSize = true;
            lblTitleOfBook.Location = new Point(38, 87);
            lblTitleOfBook.Name = "lblTitleOfBook";
            lblTitleOfBook.Size = new Size(97, 20);
            lblTitleOfBook.TabIndex = 1;
            lblTitleOfBook.Text = "Title of Book:";
            // 
            // lblFirstPageInit
            // 
            lblFirstPageInit.AutoSize = true;
            lblFirstPageInit.Location = new Point(38, 145);
            lblFirstPageInit.Name = "lblFirstPageInit";
            lblFirstPageInit.Size = new Size(138, 20);
            lblFirstPageInit.TabIndex = 2;
            lblFirstPageInit.Text = "First Page initiation:";
            // 
            // txtMainHtmlImageTop
            // 
            txtMainHtmlImageTop.Location = new Point(235, 34);
            txtMainHtmlImageTop.Name = "txtMainHtmlImageTop";
            txtMainHtmlImageTop.Size = new Size(497, 27);
            txtMainHtmlImageTop.TabIndex = 3;
            // 
            // txtTitleBook
            // 
            txtTitleBook.Location = new Point(235, 87);
            txtTitleBook.Name = "txtTitleBook";
            txtTitleBook.Size = new Size(497, 27);
            txtTitleBook.TabIndex = 4;
            // 
            // txtFirstPageInitiation
            // 
            txtFirstPageInitiation.Location = new Point(235, 142);
            txtFirstPageInitiation.Multiline = true;
            txtFirstPageInitiation.Name = "txtFirstPageInitiation";
            txtFirstPageInitiation.ScrollBars = ScrollBars.Vertical;
            txtFirstPageInitiation.Size = new Size(497, 133);
            txtFirstPageInitiation.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(638, 307);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(527, 307);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // GenericControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(txtFirstPageInitiation);
            Controls.Add(txtTitleBook);
            Controls.Add(txtMainHtmlImageTop);
            Controls.Add(lblFirstPageInit);
            Controls.Add(lblTitleOfBook);
            Controls.Add(lblImageHtmlTop);
            Name = "GenericControl";
            Size = new Size(761, 537);
            Load += GenericControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblImageHtmlTop;
        private Label lblTitleOfBook;
        private Label lblFirstPageInit;
        private TextBox txtMainHtmlImageTop;
        private TextBox txtTitleBook;
        private TextBox txtFirstPageInitiation;
        private Button btnSave;
        private Button btnLoad;
    }
}
