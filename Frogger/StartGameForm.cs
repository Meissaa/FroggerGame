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

namespace FroggerGame
{
    public partial class StartGameForm : Form
    {
        List<string> showranking = new List<string>();
        Form3Ranking printranking;

        

        public StartGameForm()
        {
            InitializeComponent();
          
        }

        //add a method to let the delegate not be empty
        void h()
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            //restart game
            Application.Exit();
            System.Diagnostics.Process.Start(Application.ExecutablePath);
        }

        private void buttonRanking_Click(object sender, EventArgs e)
        {  
           ShowRanking();
           printranking = new Form3Ranking(showranking, "", h);
           printranking.StartPosition = FormStartPosition.CenterScreen;
           printranking.Show();
            
        }

        void ShowRanking()
        {
            string line;
            FileStream fileStream = File.Open("RankingGame.txt",
                    FileMode.Open, FileAccess.Read);
            StreamReader file =
                new StreamReader(fileStream);
            while ((line = file.ReadLine()) != null)
            {
                showranking.Add(line);

            }

            file.Close();

        }



    }
}
