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
        public MainView()
        {
            InitializeComponent();
          
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("uzytkownik zalogowany jako " + AppStateProvider.Instance.CurrentUser.Role);
            Draw_Projects_Table();
            //rozwijalna lista
            propertiesComboBox.Items.Add("Wybierz opcję...");
            propertiesComboBox.Items.Add("Dane użytkownika");
            propertiesComboBox.Items.Add("Wyloguj");
            propertiesComboBox.SelectedIndex = 0;

        }

        private void Draw_Projects_Table()
        {
            tableLayoutPanel1.Visible = false;
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Location = new System.Drawing.Point(50, 150);
            panel.Name = "ProjectsTable";
            panel.Size = new System.Drawing.Size(500, 500);

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
                add.ShowDialog();


            };
            newProject.Text = "Stwórz nowy projekt";
            newProject.Name = "newProjectButton";
            newProject.BackColor = System.Drawing.Color.Red;
            newProject.Size = new System.Drawing.Size(200, 40);
            panel.Controls.Add(newProject, 0, panel.RowCount - 1);
            #endregion
            #region projectsButtons
            //pozostale wiersze
            //pobranie projektow danego uzytkownika i wpisanie ich numerow ID oraz nazw do słownika projects
            var projectsList = ProjectAccess.GetProjectsByUserId(AppStateProvider.Instance.CurrentUser.UserId);
            var projects = new Dictionary<int, string>();
            for (int i = 0; i < projectsList.Count; i++)
                projects.Add(projectsList[i].ProjectId, projectsList[i].ProjectName);

            foreach (KeyValuePair<int, string> dict in projects)
            {
                panel.RowCount = panel.RowCount + 1;
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                //panel.Controls.Add(new Label() { Text = projectsNames[i],/* TextAlign = ContentAlignment.MiddleCenter*/ }, 0, panel.RowCount - 1);

                MetroButton b = new MetroButton();
                b.Click += delegate {
                    var sprint = new CurrentSprint(dict.Key);
                    sprint.Show();
                    this.Hide();
                    //MessageBox.Show("Buttonclick");
                };
                b.Text = dict.Value;
                b.Name = dict.Value + "Button";
                b.BackColor = System.Drawing.Color.GhostWhite;
                b.Size = new System.Drawing.Size(200,40);
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
            //opcja dane uzytkownika
            if (propertiesComboBox.SelectedIndex == 1)
                //otworz formularz z danymi uzytkownika - metoda
                MessageBox.Show("formularz z danymi uzytkownika");
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
    }
}
