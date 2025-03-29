using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalMethodsAndVars;

namespace PromptConfig
{
    public partial class GenericControl : UserControl
    {
        public GenericControl()
        {
            InitializeComponent();
            txtTitleBook.Text = GlobalMethodsAndVars.GlobalVars.TitleOfBook;
            txtMainHtmlImageTop.Text = GlobalMethodsAndVars.GlobalVars.MainHtmlImageAtTop;
            txtFirstPageInitiation.Text = GlobalMethodsAndVars.GlobalVars.FirstPageInitiation;
        }

        private void GenericControl_Load(object sender, EventArgs e)
        {

        }

    }
}
