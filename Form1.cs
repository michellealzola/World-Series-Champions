using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace World_Series_Champions
{
    public partial class frmWorldSeriesChampions : Form
    {
        private List<string> teamList = new List<string>();
        public frmWorldSeriesChampions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          int numWins = 0;

            if(lboxTeams.Items.Count > 0)
            {
                if(lboxTeams.SelectedIndex != -1)
                {                    
                    numWins = GetNumWins(lboxTeams.SelectedItem.ToString());
                }
                    
            }

            lblOutNumWins.Text = "This team won " + numWins.ToString() + " time(s).";

        }

        private int GetNumWins(string teamName)
        {
            List<string> winningList = new List<string>();
            try
            {
                StreamReader inputFile = File.OpenText("WorldSeriesWinners.txt");

                List<string> seriesWinners = new List<string>();

                while(!inputFile.EndOfStream)
                {
                    seriesWinners.Add(inputFile.ReadLine());
                }

                inputFile.Close();

                foreach (string winner in seriesWinners)
                {
                    if (String.Compare(winner, teamName) == 0)
                    {
                        winningList.Add(winner);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return winningList.Count;

        }

        private void frmWorldSeriesChampions_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile = File.OpenText("Teams.txt");

                while (!inputFile.EndOfStream)
                {
                    teamList.Add(inputFile.ReadLine());
                }

                inputFile.Close();

                for (int i = 0; i < teamList.Count; i++)
                {
                    lboxTeams.Items.Add(teamList[i]);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblOutNumWins.Text = "";
            lboxTeams.SelectedItem = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
