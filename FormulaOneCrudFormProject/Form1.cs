using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FormulaOneDll;

namespace FormulaOneCrudFormProject
{
    public partial class FormMain : Form
    {
        DbTools db;
        BindingList<Team> teams;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            db = new DbTools();
            teams = new BindingList<Team>(db.LoadTeams());
            listBoxTeam.DataSource = teams;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Team t = new Team(999, "test", "team di test", new Country("IT", "Italy"), "Ferrari", "Belly", "Chassis Test", null, null);
            teams.Add(t);
        }

        private void listBoxTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            string teamName = this.listBoxTeam.SelectedItem.ToString();
            Team team = teams.ToList().Find(t => t.Name == teamName);
            //MessageBox.Show();
        }
    }
}
