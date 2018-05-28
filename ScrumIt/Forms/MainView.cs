using System;
using System.Windows.Forms;
using ScrumIt.Models;
using MetroFramework.Forms;
using MetroFramework.Controls;
using ScrumIt.DataAccess;
using System.Collections.Generic;

namespace ScrumIt.Forms
{
    public partial class MainView : MetroForm
    {
        private string _userRole;
        ToolTip toolTip1 = new ToolTip();
        MetroButton newProject = new MetroButton();

        public MainView()
        {
            _userRole = AppStateProvider.Instance.CurrentUser.Role.ToString();
            InitializeComponent();
        }


        private void MainView_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("uzytkownik zalogowany jako " + AppStateProvider.Instance.CurrentUser.Role);
            Draw_Projects_Table();
            //rozwijalna lista
            propertiesComboBox.Items.Add("Wybierz opcję...");
            if (_userRole == "ScrumMaster")
            {
                propertiesComboBox.Items.Add("Dane użytkownika");
                propertiesComboBox.Items.Add("Stwórz konto");
                propertiesComboBox.Items.Add("Wyloguj");
            }
            else if (_userRole == "Developer")
            {
                propertiesComboBox.Items.Add("Dane użytkownika");
                propertiesComboBox.Items.Add("Wyloguj");
            }
            else
            {
                propertiesComboBox.Items.Add("Zaloguj się");
            }
            propertiesComboBox.SelectedIndex = 0;
        }

        private void Draw_Projects_Table()
        {
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Location = new System.Drawing.Point(50, 150);
            panel.Name = "ProjectsTable";
            panel.Size = new System.Drawing.Size(400, 400);
            panel.AutoScroll = true;
            panel.MaximumSize = new System.Drawing.Size(400,400);

            // ilosc kolumn i wierszy na poczatku - reszta dodana dynamicznie
            panel.ColumnCount = 1;
            panel.RowCount = 0;

            //kolumny
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            // wiersze - dynamicznie
            #region newProjectButton
            panel.RowCount = panel.RowCount + 1;
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            MetroButton newProject = new MetroButton();
            newProject.Click += delegate {
                var add = new AddProject();
                add.FormClosing += delegate
                {
                    Controls.Remove(panel);
                    propertiesComboBox.Items.Clear();
                    MainView_Load(null, EventArgs.Empty);
                };
                add.ShowDialog();


            };
            newProject.Text = "Stwórz nowy projekt";
            newProject.Name = "newProjectButton";
            newProject.Theme = MetroFramework.MetroThemeStyle.Dark;
            newProject.Size = new System.Drawing.Size(200, 40);
            if (_userRole != "ScrumMaster")
            {
                toolTip1.SetToolTip(newProject, "Tylko Scrum Master może tworzyć projekty");
            }
            else
            {
                newProject.Click += delegate
                {
                    var add = new AddProject();
                    add.ShowDialog();

                };
            }
            panel.Controls.Add(newProject, 0, panel.RowCount - 1);
            #endregion
            #region projectsButtons
            //pozostale wiersze
            //pobranie projektow danego uzytkownika i wpisanie ich numerow ID oraz nazw do słownika projects
            List<ProjectModel> projectsList;
            if (_userRole == "Guest")
            {
                projectsList = ProjectAccess.GetAllProjects();
            }
            else
            {
                projectsList = ProjectAccess.GetProjectsByUserId(AppStateProvider.Instance.CurrentUser.UserId);
            }
            var projects = new Dictionary<int, string>();
            for (int i = 0; i < projectsList.Count; i++)
                projects.Add(projectsList[i].ProjectId, projectsList[i].ProjectName);

            foreach (KeyValuePair<int, string> dict in projects)
            {
                panel.RowCount = panel.RowCount + 1;
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                //panel.Controls.Add(new Label() { Text = projectsNames[i],/* TextAlign = ContentAlignment.MiddleCenter*/ }, 0, panel.RowCount - 1);

                MetroButton b = new MetroButton();
                b.Click += delegate
                {
                    var sprint = new CurrentSprint(dict.Key);
                    sprint.Show();
                    this.Hide();
                    //MessageBox.Show("Buttonclick");
                };
                b.Text = dict.Value;
                b.Name = dict.Value + "Button";
                b.BackColor = System.Drawing.Color.GhostWhite;
                b.Size = new System.Drawing.Size(200, 40);
                panel.Controls.Add(b, 0, panel.RowCount - 1);

            }
            #endregion

            Controls.Add(panel);
        }
        // zamykamy aplikacje jesli uzytkownik klika na przycisk "zamknij" (czerwony x :))
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //MessageBox.Show("Zamknięcie aplikacji");
                UserModel.Logout();
                Application.Exit();
            }
        }

        private void propertiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_userRole == "ScrumMaster")
            {
                if (propertiesComboBox.SelectedIndex == 1)
                {
                    var userPanel = new UserPanel();
                    userPanel.Show();
                }
                //opcja wyloguj
                if (propertiesComboBox.SelectedIndex == 2)
                {
                    var reg = new Register();
                    reg.Show();
                }
                
                if (propertiesComboBox.SelectedIndex == 3)
                {
                    MessageBox.Show("wylogowano");
                    UserModel.Logout();
                    this.Hide();
                    var l = new Login();
                    l.Show();
                }
            }
            else if (_userRole == "Developer")
            {
                //opcja dane uzytkownika
                if (propertiesComboBox.SelectedIndex == 1)
                {
                    UserPanel userPanel = new UserPanel();
                    userPanel.Show();
                }
                //opcja wyloguj
                if (propertiesComboBox.SelectedIndex == 2)
                {
                    MessageBox.Show("wylogowano");
                    UserModel.Logout();
                    this.Hide();
                    var l = new Login();
                    l.Show();
                }
            }
            else
            {
                if (propertiesComboBox.SelectedIndex == 1)
                {
                    this.Hide();
                    var l = new Login();
                    l.Show();
                }
            }
        }

    }
}
