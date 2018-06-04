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

        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");
        
        private void addProjectButton_Click(object sender, EventArgs e)
        {
            var name = projectNameTextBox.Text;
            var color = changeColorButton.BackColor;

            if (name != "")
            {
                try
                {
                    ProjectModel.CreateNewProject(new ProjectModel
                    {
                        ProjectName = name,
                        ProjectColor = ToHexValue(color)
                    });
                    MessageBox.Show("Pomyślnie dodano nowy projekt");
                    this.Close();
                }
                catch (ArgumentException err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                MessageBox.Show("Podaj nazwe projektu");
            }
        }

        private void SelectProjectColorButton_Click(object sender, EventArgs e)
        {
            var c = new Color();
            if (newProjectColorDialog.ShowDialog() == DialogResult.OK)
            {
                c = newProjectColorDialog.Color;
            }
            changeColorButton.BackColor = c;
        }

        private static string ToHexValue(Color color)
        {
            return "#" + color.R.ToString("X2") +
                   color.G.ToString("X2") +
                   color.B.ToString("X2");
        }

        private void AddProject_Load(object sender, EventArgs e)
        {
            addProjectButton.BackColor = _panelColor;
        }
    }
}
