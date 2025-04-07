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

        public void LoadData()
        {
            if (!File.Exists(dataFile)) return;

            string[] lines = File.ReadAllLines(dataFile);
            if (lines.Length >= 3)
            {
                txtMainHtmlImageTop.Text = lines[0];
                txtTitleBook.Text = lines[1];
                txtFirstPageInitiation.Text = lines[2].Replace("\\n", Environment.NewLine);
                txtMainTopTitleBook.Text= lines[3];
                txtNameOfBook.Text = lines[4];
                txtAmountOfChapters.Text = lines[5];
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
    }
}
