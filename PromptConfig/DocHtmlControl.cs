using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            txtTitlePrefix.Text = DocHtmlVars.foreTitlePrefix;
            txtImagePrefix.Text = DocHtmlVars.firstImagePrefix;
            txtFirstForePrompt.Text = DocHtmlVars.forPrompt;
            txtSecondRunningPrompt.Text = DocHtmlVars.runningPrompt;
            txtExtraTouch.Text = DocHtmlVars.extraTouch;
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
            DocHtmlVars.foreTitlePrefix = lines[0];
            DocHtmlVars.firstImagePrefix = lines[1];
            DocHtmlVars.forPrompt = lines[2];
            DocHtmlVars.runningPrompt = lines[3];
            DocHtmlVars.extraTouch = lines[4];

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

        private async void btnCheckPrompts_Click(object sender, EventArgs e)
        {
            picForePromptStatus.BackColor = Color.Yellow;
            picSecondPromptStatus.BackColor = Color.Yellow;
            picTitlePrefixPromptStatus.BackColor = Color.Yellow;
            

            string getBookGoals = txtBookGoals.Text;
            string sColor = await CheckPrompt(txtFirstForePrompt.Text, txtSecondRunningPrompt.Text, txtTitlePrefix.Text,
                getBookGoals, picForePromptStatus, picSecondPromptStatus, picTitlePrefixPromptStatus,
                lblStatus);
            
        }
        public static async Task<string> CheckPrompt(string forePrompt, string secondPrompt, string titlePrompt, string sGoal,
            PictureBox foreBox, PictureBox secondBox, PictureBox titleBox, Label lblStatus)
        {

            lblStatus.Text = "Working on checking the fore prompt....";  
            lblStatus.Refresh();
            // Checking the forePrompt
            //
            string sCall = "Given the goals of the book being - " + sGoal
                + " and compare it with the prompt " + forePrompt + " then what color would you give the" +
                " efficiency of the given prompt supporting the book goals in colors when red is bad, orange " +
                " somewhat good and green good?";

            string sColor = await LargeGPTPrompt.CallLargeChatGPT(sCall, "o1");

            if (sColor.Contains("GREEN") || sColor.Contains("Green") || sColor.Contains("green"))
            {
                foreBox.BackColor = Color.Green;
            }
            else if(sColor.Contains("ORANGE") || sColor.Contains("Orange") || sColor.Contains("orange"))
            {
                foreBox.BackColor = Color.Orange;
            }
            else if (sColor.Contains("RED") || sColor.Contains("Red") || sColor.Contains("red"))
            {
                foreBox.BackColor = Color.Red;
            }
            MessageBox.Show("Status foreFront:" + sColor);

            lblStatus.Text = "Working on checking the second prompt....";
            lblStatus.Refresh();
            // Checking the second prompt
            //
            sCall = "Given the goals of the book being - " + sGoal
                + " and compare it with the prompt " + secondPrompt + " then what color would you give the" +
                " efficiency of the given prompt supporting the book goals in colors when red is bad, orange " +
                " somewhat good and green good?";

            sColor = await LargeGPTPrompt.CallLargeChatGPT(sCall, "o1");

            if (sColor.Contains("GREEN") || sColor.Contains("Green") || sColor.Contains("green"))
            {
                secondBox.BackColor = Color.Green;
            }
            else if (sColor.Contains("ORANGE") || sColor.Contains("Orange") || sColor.Contains("orange"))
            {
                secondBox.BackColor = Color.Orange;
            }
            else if (sColor.Contains("RED") || sColor.Contains("Red") || sColor.Contains("red"))
            {
                secondBox.BackColor = Color.Red;
            }
            MessageBox.Show("Status secondFront:" + sColor);

            lblStatus.Text = "Working on checking the title prompt....";
            lblStatus.Refresh();
            // Checking the title prompt
            //
            sCall = "Given the goals of the book being - " + sGoal
                + " and compare it with the prompt " + titlePrompt + " then what color would you give the" +
                " efficiency of the given prompt supporting the book goals in colors when red is bad, orange " +
                " somewhat good and green good?";

            sColor = await LargeGPTPrompt.CallLargeChatGPT(sCall, "o1");

            if (sColor.Contains("GREEN") || sColor.Contains("Green") || sColor.Contains("green"))
            {
                titleBox.BackColor = Color.Green;
            }
            else if (sColor.Contains("ORANGE") || sColor.Contains("Orange") || sColor.Contains("orange"))
            {
                titleBox.BackColor = Color.Orange;
            }
            else if (sColor.Contains("RED") || sColor.Contains("Red") || sColor.Contains("red"))
            {
                titleBox.BackColor = Color.Red;
            }
            MessageBox.Show("Status titleFront:" + sColor);

            return sColor;
        }
    }
}
