using System;
using System.Windows.Forms;
using ScrumIt.Models;
using MetroFramework.Forms;

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
            if (AppStateProvider.Instance.CurrentUser == null)
            {
                var login = new Login();
                this.Hide();
                login.ShowDialog();
            }
            //else
            //{
                MessageBox.Show("uzytkownik zalogowany");
                Draw_Projects_Table();
            //}
        }

        private void Draw_Projects_Table()
        {
            tableLayoutPanel1.Visible = false;
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Location = new System.Drawing.Point(50, 150);
            panel.Name = "ProjectsTable";
            panel.Size = new System.Drawing.Size(500, 500);
            //panel.BackColor = System.Drawing.Color.Beige;

            //później- pobrać nazwy z bazy
            string[] tab = { "nazwa", "nazwa2", "nazwa3", "nazwa4" };
            var howManyRows = tab.Length;

            // ilosc kolumn i pierwszy wiersz - reszta dodana dynamicznie
            panel.ColumnCount = 2;
            panel.RowCount = 1;

            //kolumny
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            // wiersze - dynamicznie
            //wiersz naglowkowy
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            panel.Controls.Add(new Label() { Text = "Nazwa projektu", /*TextAlign = ContentAlignment.MiddleCenter*/ }, 0, 0);
            panel.Controls.Add(new Label() { Text = "Button", /*TextAlign = ContentAlignment.MiddleCenter*/ }, 1, 0);
            //pozostale wiersze
            for (var i = 0; i < howManyRows; i++)
            {
                panel.RowCount = panel.RowCount + 1;
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                panel.Controls.Add(new Label() { Text = tab[i],/* TextAlign = ContentAlignment.MiddleCenter*/ }, 0, panel.RowCount - 1);

                Button b = new Button();
                b.Click += delegate { MessageBox.Show("Buttonclick"); };
                b.Text = "button" + (i + 1);
                b.Name = "button" + (i + 1);
                b.BackColor = System.Drawing.Color.GhostWhite;
                panel.Controls.Add(b, 1, panel.RowCount - 1);

            }

            Controls.Add(panel);
        }
        
    }
}
