using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ScrumIt.Forms
{
    public partial class AddTaskFromBacklog : MetroForm
    {
        private int _taskId;
        public AddTaskFromBacklog(int taskId)
        {
            _taskId = taskId;
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
                users = new[]
                {
                    new
                    {
                        UserName ="BM",
                        FirstName = "Bartosz",
                        LastName = "Nowak"
                    },
                    new
                    {
                        UserName ="BM",
                        FirstName = "Bartosz",
                        LastName = "Nowak"
                    }
                }
            };

            taskNameTextBox.Text = task.taskName;
            taskDescriptionTextBox.Text = task.taskDescription;
            priorityTextBox.Text = task.taskPriority.ToString();
            estimatedTimeTextBox.Text = task.estimatedTime.ToString();

            taskNameTextBox.BackColor = Color.White;
            taskDescriptionTextBox.BackColor = Color.White;
            priorityTextBox.BackColor = Color.White;
            estimatedTimeTextBox.BackColor = Color.White;

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
                    Image = Properties.Resources.image
                };
                toolStripItems[i] = toolStripMenuItem;
            }

            return toolStripItems;
        }

        private void showUsersButton_Click(object sender, System.EventArgs e)
        {
            userListMenuStrip.Show(showUsersButton, new Point(0, showUsersButton.Height));
        }

        private void addTaskButton_Click(object sender, System.EventArgs e)
        {
            //dodaj task do bazki
            this.Close();
        }
    }
}
