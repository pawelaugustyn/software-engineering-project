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
            var endSprintDate = endSprintTextBox.Text;
            DateTime endDateFormat;
            DateTime startDateFormat = DateTime.Now;
            var validationFlag = false;
            if (name != "")
            {
                if (!DateTime.TryParse(endSprintDate, out endDateFormat))
                {
                    MessageBox.Show(@"Zły format daty. Wpisz zgodnie ze wzorem rrrr-mm-dd");
                    validationFlag = true;
                }
                else
                {
                    if (endDateFormat <= startDateFormat)
                    {
                        MessageBox.Show(@"Data rozpoczęcia powinna być wcześniejszą datą niż data zakończenia");
                        validationFlag = true;
                    }
                    else
                    if (endDateFormat.Month * 31 + endDateFormat.Day - startDateFormat.Month * 31 - startDateFormat.Day < 3)
                    {
                        MessageBox.Show(@"Sprint musi być dłuższy niż 3 dni");
                        validationFlag = true;
                    }
                    else
                    if (endDateFormat.Month * 31 + endDateFormat.Day - startDateFormat.Month * 31 - startDateFormat.Day > 31)
                    {
                        MessageBox.Show(@"Sprint musi być krótszy niż 30 dni");
                        validationFlag = true;
                    }
                }

                if (!validationFlag)
                {
                    try
                    {
                        ProjectModel.CreateNewProject(new ProjectModel
                        {
                            ProjectName = name,
                            ProjectColor = ToHexValue(color)
                        });
                        var projectId = ProjectModel.GetProjectByName(name).ProjectId;
                        var sprint = new SprintModel(0, projectId, DateTime.Now.ToString(), endSprintDate);
                        SprintModel.CreateNewSprint(sprint);

                        MessageBox.Show("Pomyślnie dodano nowy projekt");
                        this.Close();
                    }
                    catch (ArgumentException err)
                    {
                        MessageBox.Show(err.Message);
                    }
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
