using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromptConfig
{
    public partial class DocHtmlControl : UserControl
    {
        public DocHtmlControl()
        {
            InitializeComponent();
            txtTitlePrefix.Text = GlobalMethodsAndVars.DocHtmlVars.foreTitlePrefix;
            txtImagePrefix.Text = GlobalMethodsAndVars.DocHtmlVars.firstImagePrefix;
            txtFirstForePrompt.Text = GlobalMethodsAndVars.DocHtmlVars.forPrompt;
            txtSecondRunningPrompt.Text = GlobalMethodsAndVars.DocHtmlVars.runningPrompt;
            txtExtraTouch.Text = GlobalMethodsAndVars.DocHtmlVars.extraTouch;
        }

        private string dataFile = "Cdochtml.txt";

        public void SaveData()
        {
            string[] lines = {
                txtTitlePrefix.Text,
                txtImagePrefix.Text,
                txtFirstForePrompt.Text.Replace("\n",""), // Preserve line breaks
                txtSecondRunningPrompt.Text.Replace("\n",""), // Preserve line breaks
                txtExtraTouch.Text

            };
            GlobalMethodsAndVars.DocHtmlVars.foreTitlePrefix = lines[0];
            GlobalMethodsAndVars.DocHtmlVars.firstImagePrefix = lines[1];
            GlobalMethodsAndVars.DocHtmlVars.forPrompt = lines[2];
            GlobalMethodsAndVars.DocHtmlVars.runningPrompt = lines[3];
            GlobalMethodsAndVars.DocHtmlVars.extraTouch = lines[4];

            File.WriteAllLines(dataFile, lines);
            MessageBox.Show("Data saved successfully.");
        }

        public void LoadData()
        {
            if (!File.Exists(dataFile)) return;

            string[] lines = File.ReadAllLines(dataFile);
            if (lines.Length >= 5)
            {
                txtTitlePrefix.Text = lines[0];
                txtImagePrefix.Text = lines[1];
                txtFirstForePrompt.Text = lines[2];
                txtSecondRunningPrompt.Text = lines[3];
                txtExtraTouch.Text = lines[4];
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSaveDocHtml_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnLoadDocHtml_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
