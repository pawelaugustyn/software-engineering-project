using System;
using System.Windows.Forms;
using ScrumIt.Models;
using MetroFramework.Forms;
using MetroFramework.Controls;
using ScrumIt.DataAccess;


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
            // jesli pierwszy raz otwieramy aplikacje wchodzi if - przechodzimy do formularza logowania
            //if (AppStateProvider.Instance.CurrentUser == null)
            //{
            //    var login = new Login();
            //    this.Hide();
            //    login.ShowDialog();
            //}


            MessageBox.Show("uzytkownik zalogowany jako " + AppStateProvider.Instance.CurrentUser.Role);
            Draw_Projects_Table();
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
            //panel.BackColor = System.Drawing.Color.Beige;

            //pobranie projektow danego uzytkownika i wpisanie ich nazw do tablicy projectsNames
            var projectsList = ProjectAccess.GetProjectsByUserId(AppStateProvider.Instance.CurrentUser.UserId);
            string[] projectsNames = new string[projectsList.Count];
            for (int i = 0; i < projectsList.Count; i++)
                projectsNames[i] = projectsList[i].ProjectName;

            var howManyRows = projectsNames.Length;

            // ilosc kolumn i wierszy na poczatku - reszta dodana dynamicznie
            panel.ColumnCount = 1;
            panel.RowCount = 0;

            //kolumny
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            //panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            // wiersze - dynamicznie
            //wiersz naglowkowy
            //panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            //panel.Controls.Add(new Label() { Text = "Nazwa projektu", /*TextAlign = ContentAlignment.MiddleCenter*/ }, 0, 0);
            //panel.Controls.Add(new Label() { Text = "Button", /*TextAlign = ContentAlignment.MiddleCenter*/ }, 1, 0);
            //pozostale wiersze
            for (var i = 0; i < howManyRows; i++)
            {
                panel.RowCount = panel.RowCount + 1;
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                //panel.Controls.Add(new Label() { Text = projectsNames[i],/* TextAlign = ContentAlignment.MiddleCenter*/ }, 0, panel.RowCount - 1);

                MetroButton b = new MetroButton();
                b.Click += delegate { MessageBox.Show("Buttonclick"); };
                b.Text = projectsNames[i];
                b.Name = projectsNames[i] + "Button";
                b.BackColor = System.Drawing.Color.GhostWhite;
                b.Size = new System.Drawing.Size(200,40);
                panel.Controls.Add(b, 0, panel.RowCount - 1);

            }

            Controls.Add(panel);
        }
        // zamykamy aplikacje jesli uzytkownik klika na przycisk "zamknij" (czerwony x :))
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                MessageBox.Show("Zamknięcie aplikacji");
                Application.Exit();
            }
        }

        private void propertiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (propertiesComboBox.SelectedIndex == 1)
                MessageBox.Show("formularz z danymi uzytkownika");
            if (propertiesComboBox.SelectedIndex == 2)
                MessageBox.Show("formularz do wylogowania");
        }
    }
}
