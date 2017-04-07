using CaloryLibrary.DAL;
using CaloryLibrary.Models;
using CaloryLibrary.Repository;
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
    public partial class frmNewRecipe : Form
    {
        CaloryRepository repo = new CaloryRepository();
        public frmNewRecipe()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            lbIngredients.DataBindings.
            lbIngredients.Items.AddRange(repo.GetAll<Ingredient>()) ;
        }
    }
}
