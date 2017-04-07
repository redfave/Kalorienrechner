using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaloryLibrary.DAL;

namespace CaloryTest
{
    public partial class frmStart : Form
    {
        private CaloryContext context;
        public frmStart()
        {
            InitializeComponent();
            context = new CaloryContext();
        }

        private void btnBread_Click(object sender, EventArgs e)
        {
            string unit = "100g";
            lblBread.Text = "Brot hat " + context.Ingredients.Where(t => t.Name == "Brot").Single().GetCalories(unit).ToString() + "Kalorien auf " + unit + "!";
        }
    }
}
