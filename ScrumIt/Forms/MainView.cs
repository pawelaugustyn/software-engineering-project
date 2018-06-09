using System;
using System.Windows.Forms;
using ScrumIt.Models;
using MetroFramework.Forms;
using MetroFramework.Controls;
using ScrumIt.DataAccess;
using System.Collections.Generic;
using System.Drawing;

namespace ScrumIt.Forms
{
    public partial class MainView : MetroForm
    {
        private string _userRole;

        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");
        public MainView()
        {
            try
            {
                _userRole = AppStateProvider.Instance.CurrentUser.Role.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

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
                propertiesComboBox.Items.Add("Usuń użytkowika");
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
            panel.Location = new Point(50, 150);
            panel.Name = "ProjectsTable";
            panel.Size = new System.Drawing.Size(450, 400);
            panel.AutoScroll = true;
            panel.MaximumSize = new Size(450, 400);

            // ilosc kolumn i wierszy na poczatku - reszta dodana dynamicznie
            panel.ColumnCount = 1;
            panel.RowCount = 0;

            //kolumny
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            // wiersze - dynamicznie
            #region newProjectButton
            panel.RowCount = panel.RowCount + 1;
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            Button newProject = new Button();
            newProject.FlatStyle = FlatStyle.Flat;
            newProject.Font =new Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            newProject.Text = "Stwórz nowy projekt";
            newProject.Name = "newProjectButton";
            newProject.Size = new System.Drawing.Size(400, 40);
            newProject.FlatAppearance.BorderColor = Color.White;
            newProject.FlatAppearance.BorderSize = 0;
            if (_userRole == "ScrumMaster")
            {
                newProject.BackColor = Color.LimeGreen;
                newProject.ForeColor = Color.White;
                newProject.Click += delegate
                {
                    var add = new AddProject();
                    add.FormClosing += delegate
                    {
                        Controls.Remove(panel);
                        propertiesComboBox.Items.Clear();
                        MainView_Load(null, EventArgs.Empty);
                    };
                    add.ShowDialog();

                };
            }
            else
            {
                newProject.BackColor = ColorTranslator.FromHtml("#eeeeee");
                newProject.ForeColor = Color.DarkGray;
                var toolTip = new ToolTip();
                toolTip.SetToolTip(newProject, "Tylko Scrum Master może dodawać projekty");
            }
            panel.Controls.Add(newProject, 0, panel.RowCount - 1);
            #endregion
            #region projectsButtons
            //pozostale wiersze
            //pobranie projektow danego uzytkownika i wpisanie ich numerow ID oraz nazw do słownika projects
            try
            {
                List<ProjectModel> projectsList;
                List<ProjectModel> myprojectsList = new List<ProjectModel>();
                if (_userRole == "Guest")
                {
                    projectsList = ProjectAccess.GetAllProjects();
                }
                else if(_userRole == "Developer")
                {
                    projectsList = ProjectAccess.GetProjectsByUserId(AppStateProvider.Instance.CurrentUser.UserId);
                }
                else
                {
                    projectsList = ProjectAccess.GetAllProjects();
                    myprojectsList = ProjectAccess.GetProjectsByUserId(AppStateProvider.Instance.CurrentUser.UserId);
                }

                var projects = new Dictionary<int, string>();

                for (int i = 0; i < projectsList.Count; i++)
                    projects.Add(projectsList[i].ProjectId, projectsList[i].ProjectName);

                foreach (KeyValuePair<int, string> dict in projects)
                {
                    panel.RowCount = panel.RowCount + 1;
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                    //panel.Controls.Add(new Label() { Text = projectsNames[i],/* TextAlign = ContentAlignment.MiddleCenter*/ }, 0, panel.RowCount - 1);

                    var b = new Button();
                    b.FlatStyle = FlatStyle.Flat;
                    b.Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point,
                        ((byte) (238)));

                    if (_userRole == "ScrumMaster")
                    {
                        foreach (var proj in myprojectsList)
                        {
                            if (proj.ProjectId == dict.Key)
                            {
                                b.BackColor = _panelColor;
                                break;
                            }
                            else
                            {
                                b.BackColor = ColorTranslator.FromHtml("#eeeeee");

                            }
                        }

                    }
                    b.ForeColor = Color.White;
                    b.FlatAppearance.BorderColor = Color.White;
                    b.FlatAppearance.BorderSize = 0;
                    b.Click += delegate
                    {
                        var sprint = new CurrentSprint(dict.Key);
                        sprint.Show();
                        this.Hide();
                        //MessageBox.Show("Buttonclick");
                    };
                    b.Text = dict.Value;
                    b.Name = dict.Value + "Button";
                    b.Size = new System.Drawing.Size(400, 40);
                    panel.Controls.Add(b, 0, panel.RowCount - 1);

                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
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
                if (propertiesComboBox.SelectedIndex == 2)
                {
                    var deleteUser = new DeleteUser();
                    deleteUser.Show();
                }
                if (propertiesComboBox.SelectedIndex == 4)
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
