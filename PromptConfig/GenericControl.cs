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
    public partial class GenericControl : UserControl
    {
        public GenericControl()
        {
            InitializeComponent();
            txtTitleBook.Text = GlobalVars.TitleOfBook;
            txtMainHtmlImageTop.Text = GlobalVars.MainHtmlImageAtTop;
            txtFirstPageInitiation.Text = GlobalVars.FirstPageInitiation;
        }

        private void GenericControl_Load(object sender, EventArgs e)
        {

        }
        private string dataFile = "Cbookdata.txt";

        public void SaveData()
        {
            string[] lines = {
                txtMainHtmlImageTop.Text,
                txtTitleBook.Text,
                txtFirstPageInitiation.Text.Replace(Environment.NewLine, "\\n"), // Preserve line breaks
                txtMainTopTitleBook.Text,
                txtNameOfBook.Text,
                txtAmountOfChapters.Text
            };
            GlobalVars.MainHtmlImageAtTop = lines[0];
            GlobalVars.TitleOfBook = lines[1];
            GlobalVars.FirstPageInitiation = lines[2];
            GlobalVars.HeaderTitleOfBook = lines[3];
            GlobalVars.NameOfBook = lines[4];
            GlobalVars.NumberOfPages = lines[5];

            File.WriteAllLines(dataFile, lines);
            MessageBox.Show("Data saved successfully.");
        }
        public void SaveDataFile()
        {
            string[] lines = {
                txtMainHtmlImageTop.Text,
                txtTitleBook.Text,
                txtFirstPageInitiation.Text.Replace(Environment.NewLine, "\\n"), // Preserve line breaks
                txtMainTopTitleBook.Text,
                txtNameOfBook.Text,
                txtAmountOfChapters.Text
            };

            // Update global variables
            GlobalVars.MainHtmlImageAtTop = lines[0];
            GlobalVars.TitleOfBook = lines[1];
            GlobalVars.FirstPageInitiation = lines[2];
            GlobalVars.HeaderTitleOfBook = lines[3];
            GlobalVars.NameOfBook = lines[4];
            GlobalVars.NumberOfPages = lines[5];

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Book Data";
                saveFileDialog.FileName = "BookData.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllLines(saveFileDialog.FileName, lines);
                        MessageBox.Show("Data saved successfully.", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while saving the file:\n" + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void LoadData()
        {
            if (!File.Exists(dataFile)) return;

            string[] lines = File.ReadAllLines(dataFile);
            if (lines.Length >= 3)
            {
                txtMainHtmlImageTop.Text = lines[0];
                txtTitleBook.Text = lines[1];
                txtFirstPageInitiation.Text = lines[2].Replace("\\n", Environment.NewLine);
                txtMainTopTitleBook.Text = lines[3];
                txtNameOfBook.Text = lines[4];
                txtAmountOfChapters.Text = lines[5];
            }
        }
        public void LoadDataFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.Title = "Open Book Data";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(openFileDialog.FileName);

                        if (lines.Length >= 6)
                        {
                            txtMainHtmlImageTop.Text = lines[0];
                            txtTitleBook.Text = lines[1];
                            txtFirstPageInitiation.Text = lines[2].Replace("\\n", Environment.NewLine);
                            txtMainTopTitleBook.Text = lines[3];
                            txtNameOfBook.Text = lines[4];
                            txtAmountOfChapters.Text = lines[5];

                            // Update global variables
                            GlobalVars.MainHtmlImageAtTop = lines[0];
                            GlobalVars.TitleOfBook = lines[1];
                            GlobalVars.FirstPageInitiation = lines[2];
                            GlobalVars.HeaderTitleOfBook = lines[3];
                            GlobalVars.NameOfBook = lines[4];
                            GlobalVars.NumberOfPages = lines[5];

                            MessageBox.Show("Data loaded successfully.", "Load Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The selected file does not contain enough data.", "Load Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading the file:\n" + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

        private void btSaveAs_Click(object sender, EventArgs e)
        {
            SaveDataFile();
        }

        private void btnLoadFrom_Click(object sender, EventArgs e)
        {
            LoadDataFile();
        }
    }
}
