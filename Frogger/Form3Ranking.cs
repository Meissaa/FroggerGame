using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FroggerGame
{
    public partial class Form3Ranking : Form
    {

        List<string> rankingUnsorted = new List<string>();
        Dictionary<string, string> sortRanking = new Dictionary<string, string>();
        string userGame;
        int number = 0;
        public delegate void Hid();
        public Hidewin hid;

        public Form3Ranking(List<string> rankingUnsorted, string userGame, Hidewin hid)
        {
            InitializeComponent();
            pictureBoxRanking.Image = Properties.Resources.FroggerLogo;
            this.rankingUnsorted = rankingUnsorted;
            this.userGame = userGame;
            this.hid = hid;
            AddToDictionary();
        }

        void AddToDictionary()
        {
            //save data from the List to the dictionary
            for (int i = 0, j = 1; i < rankingUnsorted.Count;)
                {
                    sortRanking.Add(rankingUnsorted[i], rankingUnsorted[j]);

                    i = i + 2;
                    j = j + 2;
                }


            //Sort the data in the dictionary ascending
            var items = from pair in sortRanking
                        orderby pair.Value ascending 
                        select pair;

            listBoxRanking.Items.Clear();
            foreach (KeyValuePair<string, string> pair in items)
            {
                number++;
                listBoxRanking.Items.AddRange(new object[] { number + ". " + pair.Key + " " +  pair.Value });
               
            }
 
            HighlightUser();

        }

        //Find a player and highlight it
        void HighlightUser()
        {
            if (userGame != null) {
                int index = 0;
                for (int i = 0; i < listBoxRanking.Items.Count; ++i)
                {
                    string lbString = listBoxRanking.Items[i].ToString();
                    if (lbString.Contains(userGame))
                        index = i;
                }
                listBoxRanking.SetSelected(index, true);
            }
        }

      
        private void buttonOK_Click(object sender, EventArgs e)
        {

            StartGameForm f = new StartGameForm();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show(); //show the application's start window
            this.Close(); //close the window displaying the ranking
            hid(); //hide the main window transferred from Form2
        }
    }
}
