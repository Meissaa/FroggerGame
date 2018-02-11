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
    public delegate void Hidewin();
    public partial class Form2 : Form
    {
        string resultTime;
        string userName;
        int counter = 0;
        int counter2;
        //window with ranking
        Form3Ranking windowTabRanking;
        //window startgame
        StartGameForm windowStartGame; 
        bool exist = false;
        List<string> ranking = new List<string>();

       
        public Hidewin hideWin;


        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string resultTime, Hidewin hideWin)
        {
            InitializeComponent();
            pictureBoxTextFrogger.Image = Properties.Resources.FroggerText2;
            this.resultTime = resultTime;
            this.hideWin = hideWin;
        }


        //save userName
        private void buttonOk_Click_1(object sender, EventArgs e)
        {
            userName = textBoxUsername.Text;
            CheckExistUser(userName);
            WriteResultsExistUser();

            if (exist != true)
            {
                SaveResult(resultTime, userName);
                
            }

            ShowRanking();
            windowTabRanking = new Form3Ranking(ranking, userName, hideWin);
            windowTabRanking.StartPosition = FormStartPosition.CenterScreen;
            windowTabRanking.ShowDialog();
            Close();

        }

        //check user exists in the database
        //if exists write tle line number
        void CheckExistUser(string userName)
        {
            string line;
            FileStream fileStream = File.Open("RankingGame.txt",
                    FileMode.Open, FileAccess.Read);
            StreamReader file =
                new StreamReader(fileStream);
            while ((line = file.ReadLine()) != null)
            {
                counter++;

                if (line.Equals(userName))
                {
                    exist = true;
                    counter2 = counter; //The number of the line under which the user is located
                    break;

                }
               
            }

            counter = 0; //reset the number of lines
            file.Close(); 
            file.Dispose();

        }

        //overwrite the result of an existing user
        void WriteResultsExistUser()
        {
            counter2++; 
            string[] arrLine = File.ReadAllLines("RankingGame.txt");
            arrLine[counter2 - 1] = resultTime;
            File.WriteAllLines("RankingGame.txt", arrLine);


        }

        //Save the game results and display the ranking
        void SaveResult(string resultTime, string userName)
        {
            
                try
                {

                    FileStream fileStream = File.Open("RankingGame.txt",
                        FileMode.Append, FileAccess.Write);

                    StreamWriter fileWriter = new StreamWriter(fileStream);

                    fileWriter.WriteLine(userName);
                    fileWriter.WriteLine(resultTime);
                    fileWriter.Flush();
                    fileWriter.Close();
                }
                catch (IOException ioe)
                {
                    Console.WriteLine(ioe);
                }
               
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
                    ranking.Add(line);

                }

                file.Close();

            }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            
            windowStartGame = new StartGameForm(); 
            windowStartGame.StartPosition = FormStartPosition.CenterScreen;
            windowStartGame.Show();
            this.Close();
            //Hide the Form1 window
            hideWin(); 
           
        }

       
        
    }
}
