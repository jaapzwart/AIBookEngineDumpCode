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
                txtFirstForePrompt.Text.Replace("\n",""),
                txtSecondRunningPrompt.Text.Replace("\n",""),
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

        public void LoadData(string dataFile)
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

        private void btnSaveDocHtml_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnLoadDocHtml_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath; // Set to program location
                openFileDialog.Filter = "HTML files (*.html;*.htm)|*.html;*.htm|All files (*.*)|*.*";
                openFileDialog.Title = "Select an HTML document";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    // Pass the path to LoadData or load it directly here
                    LoadData(selectedFilePath);
                }
            }
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
                " somewhat good and green good? But give only ONE color in your return. Do not name the others." +
                " But DO give an example WHY you think it is the color you gave." +
                " And give detailed suggestions on prompt improvements of the one given.";

            string sColor = await LargeGPTPrompt.CallLargeChatGPT(sCall, "o1");

            if (sColor.Contains("GREEN") || sColor.Contains("Green") || sColor.Contains("green"))
            {
                foreBox.BackColor = Color.Green;
            }
            else if (sColor.Contains("ORANGE") || sColor.Contains("Orange") || sColor.Contains("orange"))
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
                " somewhat good and green good? But give only ONE color in your return. Do not name the others." +
                " But DO give an example WHY you think it is the color you gave." +
                " And give detailed suggestions on prompt improvements of the one given.";

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
                " somewhat good and green good? But give only ONE color in your return. Do not name the others." +
                " But DO give an example WHY you think it is the color you gave" +
                " And give detailed suggestions on prompt improvements of the one given.";

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
            lblStatus.Text = "...";
            lblStatus.Refresh();

            return sColor;
        }

        private void btnSaveAsDocHtml_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Application.StartupPath;
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Prompt Data As";
                saveFileDialog.FileName = "PromptData.txt"; // Optional default name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;

                    string[] lines =
                    {
                        txtTitlePrefix.Text.Replace("\n", ""),
                        txtImagePrefix.Text.Replace("\n", ""),
                        txtFirstForePrompt.Text.Replace("\n", ""),
                        txtSecondRunningPrompt.Text.Replace("\n", ""),
                        txtExtraTouch.Text.Replace("\n", "")
                    };

                    File.WriteAllLines(savePath, lines);
                    MessageBox.Show("File saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void btnGeneratePrompts_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Working on the title prefix.";
                lblStatus.Refresh();
                string sCall = DocHtmlVars.foreTitlePrefix;

                string sPrompt = sCall;
                txtTitlePrefix.Text = sPrompt.Replace("\n", "");
                txtImagePrefix.Refresh();

                lblStatus.Text = "Working on the fore prompt.";
                lblStatus.Refresh();
                sCall = "Craft a chapter to guide the writing of a science fiction thriller," +
                    " unfolding in chronological order as a natural foundation for the chapters that follow. Craft a subtle yet robust" +
                    " introduction to the broader story arc, with the chapter title intricately woven into the narrative as a symbolic " +
                    "and thematic lodestone, anchoring the tale with seamless intelligence. Infuse the writing with rich, deep, and " +
                    "intelligent dialogue—witty, layered with psychological nuance, and brimming with emotional resonance—shared between " +
                    "complex characters whose words spark intrigue and reveal hidden depths. Blend vivid, atmospheric descriptions of natural " +
                    "and constructed settings, from eerie alien landscapes and sterile corridors to brooding cities and secretive chambers, " +
                    "each scene rendered with thrilling clarity to pull the reader into the world. Plumb the characters’ inner lives with " +
                    "immersive psychological detail, unveiling motives, doubts, and ideological frictions through intricate thoughts and monologues " +
                    "that ripple with tension and foreshadow evolution. Let this chapter ignite a slow-burning intrigue and taut suspense, laying a " +
                    "subtle yet unshakable narrative and philosophical groundwork for the full plot, resulting in a piece of rich, gripping literature " +
                    "that sets the stage for an unforgettable journey. Do not mention the title of the chapter in the chapter itself" +
                    " but make sure its used and present in the plotline of the chapter itself in a subtle manner. Also make sure that interesting, intelligent," +
                    " thought provoking, witty, deep, innovative, creative and exciting dialogues between the characters are present throughout the chapter." + 
                    " Build this chapter upon this plot:" + GlobalVars.BookPlot;



                //sPrompt = await LargeGPTPrompt.CallLargeChatGPT(sCall, "o3-mini");
                sPrompt = sCall;
                txtFirstForePrompt.Text = sPrompt.Replace("\n", "");
                txtFirstForePrompt.Refresh();

                lblStatus.Text = "Working on the second prompt.";
                lblStatus.Refresh();
                sCall = "Craft a chapter that seamlessly flows as a natural " +
                    "continuation of its predecessor, threading together rich, deep, and intelligent dialogue—crackling with wit, " +
                    "psychological complexity, and thought-provoking exchanges that unravel the characters’ minds and motives. " +
                    "Weave in vivid, atmospheric descriptions of scenery, capturing the untamed sprawl of natural landscapes and " +
                    "the haunting allure or stark precision of constructed settings, from claustrophobic chambers to gleaming " +
                    "futuristic cities or decaying alien structures, each brushstroke of detail amplifying the pulse of suspense. " +
                    "Embed immersive inner monologues and intricate character thoughts that lay bare profound emotional currents, " +
                    "wrenching moral quandaries, and the shifting tides of relationships, deepening the stakes with every revelation. " +
                    "Ensure every element fuels a thrilling narrative that seizes the reader’s senses, guided silently yet firmly by the " +
                    "chapter title as a beacon for mounting tension, narrative momentum, and thematic cohesion, resulting in a tapestry of " +
                    "rich, evocative literature that builds irresistibly from the story’s prior beats.  Do not mention the title of the chapter in the chapter itself" +
                    " but make sure its used and present in the plotline of the chapter itself in a subtle manner. Above all, make sure this chapter is" +
                    " a continuation of the end of the previous chapter and builds further on its story line. Also make sure that interesting, intelligent," +
                    " thought provoking, witty, deep, innovative, creative and exciting dialogues between the characters are present throughout the chapter.";


                //sPrompt = await LargeGPTPrompt.CallLargeChatGPT(sCall, "o3-mini");
                sPrompt = sCall;
                txtSecondRunningPrompt.Text = sPrompt.Replace("\n", "");
                txtSecondRunningPrompt.Refresh();

                lblStatus.Text = "Working on the extra touch prompt.";
                lblStatus.Refresh();
                sCall = "Steer the writing of the of " +
                    "the chapter to make extra sure that the dialogues between characters are intelligent, " +
                    "thought provoking, rich, vivid and witty. Make extra sure that the description and integration " +
                    "of the scenery of the environments are very well integrated into the story, rich, in depth, " +
                    "intelligent and really are part of the overall story line. ";
                sPrompt = sCall;
                //sPrompt = await LargeGPTPrompt.CallLargeChatGPT(sCall, "o3-mini");
                txtExtraTouch.Text = sPrompt.Replace("\n", "");
                txtExtraTouch.Refresh();

                lblStatus.Text = "...";
                lblStatus.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void DocHtmlControl_Load(object sender, EventArgs e)
        {

        }
    }
}
