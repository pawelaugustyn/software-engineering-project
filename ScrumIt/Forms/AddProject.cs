using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class AddProject : MetroForm
    {
        public AddProject()
        {
            InitializeComponent();
        }


        private void newProjectMetroButton_Click(object sender, EventArgs e)
        {
            var name = newProjectNameMetroTextBox.Text;
            var color = SelectProjectColorButton.BackColor;
            //wyślij dane do bazy
            //potrzebna metoda!
        }
        
        private void SelectProjectColorButton_Click(object sender, EventArgs e)
        {
            var c = new Color();
            if (newProjectColorDialog.ShowDialog() == DialogResult.OK)
            {
                c = newProjectColorDialog.Color;
            }
            SelectProjectColorButton.BackColor = c;
        }
    }
}
