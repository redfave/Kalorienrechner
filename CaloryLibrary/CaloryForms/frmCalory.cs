using CaloryLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaloryForms
{
    public partial class frmCalory : Form
    {
        public frmCalory()
        {
            InitializeComponent();
        }

        private void CreateNewRecipe(object sender, EventArgs e)
        {

            Recipe newRecipe = new Recipe();
        }
    }
}
