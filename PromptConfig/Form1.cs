using System;
using System.Windows.Forms;

namespace PromptConfig
{
    public partial class Form1 : Form
    {
        private SplitContainer splitContainer;
        private TreeView treeMenu;
        private Panel configPanel;

        // UserControls
        private UserControl genericControl = new GenericControl();
        private UserControl docHtmlControl = new DocHtmlControl();
        private UserControl docLongHtmlControl = new DocLongHtmlControl();
        private UserControl docLearningControl = new DocLearningControl();

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Fullscreen on launch
            this.FormBorderStyle = FormBorderStyle.Sizable; // Optional: allow resizing
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                IsSplitterFixed = false
            };

            treeMenu = new TreeView { Dock = DockStyle.Fill };
            treeMenu.Nodes.Add("Generic");
            treeMenu.Nodes.Add("dochtml");
            treeMenu.Nodes.Add("doclonghtml");
            treeMenu.Nodes.Add("doclearning");
            treeMenu.AfterSelect += TreeMenu_AfterSelect;

            configPanel = new Panel { Dock = DockStyle.Fill, BackColor = System.Drawing.Color.White };

            splitContainer.Panel1.Controls.Add(treeMenu);
            splitContainer.Panel2.Controls.Add(configPanel);
            this.Controls.Add(splitContainer);

            // Hook to resize event to set splitter after form is shown
            this.Shown += (s, e) =>
            {
                splitContainer.SplitterDistance = (int)(this.ClientSize.Width * 0.2); // 20%
            };
        }


        private void TreeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            configPanel.Controls.Clear();

            switch (e.Node.Text.ToLower())
            {
                case "generic":
                    configPanel.Controls.Add(genericControl);
                    break;
                case "dochtml":
                    configPanel.Controls.Add(docHtmlControl);
                    break;
                case "doclonghtml":
                    configPanel.Controls.Add(docLongHtmlControl);
                    break;
                case "doclearning":
                    configPanel.Controls.Add(docLearningControl);
                    break;
            }
        }
    }
}
