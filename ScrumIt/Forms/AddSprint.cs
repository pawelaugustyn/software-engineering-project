using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class AddSprint : MetroForm
    {

        private int _projectId;
        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");

        public AddSprint(int projectId)
        {
            _projectId = projectId;
            InitializeComponent();
        }

        private void AddSprint_Load(object sender, System.EventArgs e)
        {
            addSprintButton.BackColor = _panelColor;
        }

        private void addSprintButton_Click(object sender, System.EventArgs e)
        {
            var startDate = startSprintDatePicker.Value;
            var endDate = endSprintDatePicker.Value;
            var validationFlag = false;

            if (endDate <= startDate)
            {
                MessageBox.Show(@"Data rozpoczęcia powinna być wcześniejszą datą niż data zakończenia");
                validationFlag = true;
            }
            else
            if (endDate.Year * 365 + endDate.Month * 31 + endDate.Day - startDate.Year * 365 - startDate.Month * 31 - startDate.Day < 3)
            {
                MessageBox.Show(@"Sprint musi być dłuższy niż 3 dni");
                validationFlag = true;
            }
            else
            if (endDate.Year * 365 + endDate.Month * 31 + endDate.Day - startDate.Year * 365 - startDate.Month * 31 - startDate.Day >= 31)
            {
                MessageBox.Show(@"Sprint nie może być dłuższy niż 31 dni");
                validationFlag = true;
            }

            if (!validationFlag)
            {
                try
                {
                    var sprint = new SprintModel(0, _projectId, startDate.ToString(), endDate.ToString());
                    SprintModel.CreateNewSprint(sprint);
                    MessageBox.Show("Pomyślnie dodano sprint");
                    Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }
    }
}
