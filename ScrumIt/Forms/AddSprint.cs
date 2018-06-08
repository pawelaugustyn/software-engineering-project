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
            var startDate = startSprintDateTextBox.Text;
            var endDate = endSprintDateTextBox.Text;
            DateTime startDateFormat;
            DateTime endDateFormat;
            var validationFlag = false;
            if (startDate != "rrrr-mm-dd" && endDate != "rrrr-mm-dd" && DateTime.TryParse(startDate, out startDateFormat) && DateTime.TryParse(endDate, out endDateFormat))
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
                    MessageBox.Show(@"Sprint nie może być dłuższy niż 31 dni");
                    validationFlag = true;
                }
                else
                {
                    var endOfLastSprint = SprintModel.GetEndOfLastSprint(_projectId) ?? DateTime.Now.AddDays(-1);
                    if (startDateFormat <= endOfLastSprint)
                    {
                        MessageBox.Show(@"Data sprintu koliduje z innym sprintem");
                        validationFlag = true;
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Zły format daty! Wpisz zgodnie z formatem rrrr-mm-dd");
                validationFlag = true;
            }

            if (!validationFlag)
            {
                try
                {
                    var sprint = new SprintModel(0, _projectId, startDate, endDate);
                    SprintModel.CreateNewSprint(sprint);
                    Close();
                    var manageProj = new ManageProject(_projectId);
                    manageProj.Show();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }
    }
}
