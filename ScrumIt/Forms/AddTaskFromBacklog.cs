using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ScrumIt.Forms
{
    public partial class AddTaskFromBacklog : MetroForm
    {
        public AddTaskFromBacklog()
        {
            InitializeComponent();
        }

        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");

        private void AddTaskFromBacklog_Load(object sender, System.EventArgs e)
        {
            addTaskButton.BackColor = _panelColor;

            //pobierz dany task z bazki
            var task = new
            {
                taskName = "Nowy Task",
                taskType = "High",
                taskDescription = "Task Description",
                taskPriority = 5,
                estimatedTime = 10,
                users = new[] { "Mindur1", "Mindur2", "Mindur3", "Mindur4" }
            };

            taskNameTextBox.Text = task.taskName;
            taskDescriptionTextBox.Text = task.taskDescription;
            priorityTextBox.Text = task.taskPriority.ToString();
            estimatedTimeTextBox.Text = task.estimatedTime.ToString();


            //pobierz przypisanych uzytkownikow danego zadania

            userListMenuStrip.Items.AddRange(createUsersListMenu(task.users));
        }

        private ToolStripItem[] createUsersListMenu(dynamic userList)
        {
            var toolStripItems = new ToolStripItem[userList.Length];
            for (var i = 0; i < userList.Length; i++)
            {
                var toolStripMenuItemName = userList[i].UserName;
                var toolStripMenuItemText = userList[i].FirstName + " " + userList[i].LastName + " ";
                var toolStripMenuItem = new ToolStripMenuItem
                {
                    Name = toolStripMenuItemName,
                    Text = toolStripMenuItemText,
                    Image = Properties.Resources.image,
                    CheckOnClick = true
                };
                toolStripItems[i] = toolStripMenuItem;
            }

            return toolStripItems;
        }
    }
}
