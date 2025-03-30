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
    public partial class DocPlotline : UserControl
    {
        public DocPlotline()
        {
            InitializeComponent();
        }

        private void btnSavePlotAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Application.StartupPath;
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Plot As";
                saveFileDialog.FileName = "Plot.txt"; // Optional default name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;

                    string[] lines = {
                        txtBookDescription.Text.Replace("\n",""),
                        txtBookPlotLine.Text.Replace("\n",""),
                        txtSteerPlot.Text.Replace("\n",""),
                        txtSteeringWriters.Text,
                        txtBookSteeringWheelUniverse.Text
                    };
                    GlobalVars.BookDescription = lines[0];
                    GlobalVars.BookPlot = lines[1];
                    GlobalVars.BookPlotSteering = lines[2];
                    GlobalVars.BookPlotSteerWheelWriters = lines[3];
                    GlobalVars.BookPlotSteerWheelUniverse = lines[4];

                    File.WriteAllLines(savePath, lines); // Save the content of the plot box
                    MessageBox.Show("Plot saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void GeneratePlot_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSteerPlot.Text) || string.IsNullOrWhiteSpace(txtBookDescription.Text))
                {
                    MessageBox.Show("Please fill in both the 'Plot Direction' and 'Book Description' fields.",
                                    "Missing Information",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Stop execution
                }
                lblInfo.Text = "Working on the plot....";
                lblInfo.Refresh();
                string askPlot = "Generate a plotline of 4 fat paragraphs for a book. This is the main direction for the book plot line - " + txtSteerPlot.Text
                    + " and it should be based upon - " + txtBookDescription.Text
                    + " Give the plotline without extra characters and no linefeeds."
                    + " Give the plot in 4 fat paragraphs.";
                string sPlot = await LargeGPTPrompt.CallLargeChatGPT(askPlot, "o1");
                txtBookPlotLine.Text = sPlot;
                GlobalVars.BookPlot = sPlot;
                lblInfo.Text = "...";
                lblInfo.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtLoadPlot_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Application.StartupPath;
                    openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.Title = "Load Book Data";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFilePath = openFileDialog.FileName;

                        if (!File.Exists(selectedFilePath)) return;

                        string[] lines = File.ReadAllLines(selectedFilePath);
                        if (lines.Length >= 3)
                        {
                            txtBookDescription.Text = lines[0].Replace("\n", "");
                            txtBookPlotLine.Text = lines[1].Replace("\n", "");
                            txtSteerPlot.Text = lines[2].Replace("\n", "");
                            txtSteeringWriters.Text = lines[3].Replace("\n", "");
                            txtBookSteeringWheelUniverse.Text = lines[4].Replace("\n", "");
                        }
                        GlobalVars.BookDescription = txtBookDescription.Text;
                        GlobalVars.BookPlot = txtBookPlotLine.Text;
                        GlobalVars.BookPlotSteering = txtSteerPlot.Text;
                        GlobalVars.BookPlotSteerWheelWriters = txtSteeringWriters.Text;
                        GlobalVars.BookPlotSteerWheelUniverse = txtBookSteeringWheelUniverse.Text;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message );
            }
        }
       

    }
}
