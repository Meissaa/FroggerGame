using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FroggerGame
{
    public partial class Form1 : Form
    {
        //time game
        Timer t; 
        Frog frog;
        Car[] cars = new Car[12];
        Log[] logs;
        float[] valueSpeed = new float[6] { 6, -11, 4, 6, -5, 3};  
        //speed cars and logs
        float grid = 70;
        int index = 0;
        string resultTimeGame;
        int catchSmallFrog = 0;
        int life, s, m, h;
        Form2 formWinner;
        Image f = null;
        SoundPlayer audio = new SoundPlayer(Properties.Resources.Frogger_music___Theme_1);
        //children Frogger
        List<SmallFrog> smallFrog = new List<SmallFrog>();
        //life Frogger
        List<SmallFrog> lifeFrogger = new List<SmallFrog>();    



        public Form1()
        {
            InitializeComponent();
            //doubleBuffered Panel 
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            panel1, new object[] { true });
            //time game 
            t = new Timer();
            t.Enabled = true;
            t.Interval = 1000;
            t.Tick += new System.EventHandler(t_Tick);
            //starting position Frogerr
            resetGame(); 
            //life Frogger
            life = frog.Life; 
            //play music 
            audio.Play(); 

            //Row 1
            for (int i = 0; i < 3; i++)
            {
                
                float x = i * 350;
                cars[index] = new Car(x, panel1.Height - grid * 2, 80, 70, 10, Color.Empty, Properties.Resources.truck2);
                index++;
            }

            //Row 2
            for (int i = 0; i < 3; i++)
            {
                float x = i * 250 + 150;
                cars[index] = new Car(x, panel1.Height - grid * 3, 70, 70, -15, Color.Empty, Properties.Resources.carPurple);
                index++;
            }

            //Row 3
            for (int i = 0; i < 6; i++)
            {
                float x = i * 200 + 25;             
                cars[index] = new Car(x, panel1.Height - grid * 4, 70, 70, 8, Color.Empty, Properties.Resources.carblue);
                index++;
            }

            logs = new Log[8]; 

            //Row 5
            index = 0;
            for (int i = 0; i < 3; i++)
            {
                float x = i * 300 + 100;                                
                logs[index] = new Log(x, panel1.Height - grid * 6, grid*2, 50, 10, Color.Brown, Properties.Resources.Log3);
                index++;
            }

            //Row 6
            for (int i = 0; i < 3; i++)
            {
                float x = i * 250 + 30;                                
                logs[index] = new Log(x, panel1.Height - grid * 7, grid, 50, -9, Color.Brown, Properties.Resources.TurtleLeft); 
                index++;
            }
            //Row 7
            for (int i = 0; i < 2; i++)
            {
                float x = i * 400 + 10;                            
                logs[index] = new Log(x, panel1.Height - grid * 8, grid*3, 50, 7, Color.Brown, Properties.Resources.Log4); 
                index++;
            }

            //position children Frogger
            smallFrog.Add(new SmallFrog(0 * 232, panel1.Height - grid * 9, grid, grid * 1, Properties.Resources.SmallFrogBush));
            smallFrog.Add(new SmallFrog(1 * 232, panel1.Height - grid * 9, grid, grid * 1, Properties.Resources.SmallFrogBush2));
            smallFrog.Add(new SmallFrog(2 * 232, panel1.Height - grid * 9, grid, grid * 1, Properties.Resources.SmallFrogBush3));
            smallFrog.Add(new SmallFrog(3 * 232, panel1.Height - grid * 9, grid, grid * 1, Properties.Resources.SmallFrogBush4));
            smallFrog.Add(new SmallFrog(4 * 232, panel1.Height - grid * 9, grid, grid * 1, Properties.Resources.SmallFrogBush5));

            //position life Frogger
            lifeFrogger.Add(new SmallFrog(4 * 230, this.ClientSize.Height - 40, 40, 40 * 9, Properties.Resources.SmallFrog5));
            lifeFrogger.Add(new SmallFrog(3 * 290, this.ClientSize.Height - 40, 40, 40 * 9, Properties.Resources.SmallFrog5));
            lifeFrogger.Add(new SmallFrog(2 * 410, this.ClientSize.Height - 40, 40, 40 * 9, Properties.Resources.SmallFrog5));
        }

        //drawing life Frogger on the main window
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (SmallFrog f in lifeFrogger)
            {
                Graphics graphics = e.Graphics;
                f.Show(graphics);
            }
        }

        //drawing on the panel
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //drawing the ground with grass
            graphics.DrawImage(Properties.Resources.LongBush2, 0, 0, panel1.Width, grid * 1); //góra
            graphics.DrawImage(Properties.Resources.Grass, 0, panel1.Height - grid * 5, panel1.Width, grid); //środek
            graphics.DrawImage(Properties.Resources.Grass, 0, panel1.Height - grid, panel1.Width, grid);

            //drawing a road
            graphics.DrawImage(Properties.Resources.Roadxcf, 0, panel1.Height - grid * 2, panel1.Width, grid);
            graphics.DrawImage(Properties.Resources.Road3, 0, panel1.Height - grid * 3, panel1.Width, grid);
            graphics.DrawImage(Properties.Resources.Road2, 0, panel1.Height - grid * 4, panel1.Width, grid);

            //drawing a river
            graphics.DrawImage(Properties.Resources.Water, 0, panel1.Height - grid * 6, panel1.Width, grid);
            graphics.DrawImage(Properties.Resources.Water, 0, panel1.Height - grid * 7, panel1.Width, grid);
            graphics.DrawImage(Properties.Resources.Water, 0, panel1.Height - grid * 8, panel1.Width, grid);

            //drawing cars
            foreach (Car car in cars)
            {
                car.Show(graphics);
            }

            //drawing logs on the river
            foreach (Log log in logs)
            {
                log.Show(graphics);
            }

            //checks Frogger fell into the river
            if (frog.y < panel1.Height - grid * 5 && frog.y > grid * 0)
            {
                Boolean ok = false;

                foreach (Log log in logs)
                    if (frog.Intersects(log))
                    {
                        ok = true;
                        frog.Attach(log);
                    }

                //if Frogger fell into the river - loses life
                if (!ok)   
                {
                    life--;

                    if (life >= 0) { 
                        lifeFrogger.RemoveAt(life); 
                        gameOver(); 
                    }
                }
            }
            else
            {
                //if Frogger jumps off log  - get back to your speed
                frog.Attach(null); 
            }

            foreach (SmallFrog f in smallFrog)
            {
                f.Show(graphics);
            }

            frog.Update();
            frog.Show(graphics);
        }


        //move Frogger
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                frog.Move(0, -1);
                Refresh();

            }
            if (e.KeyCode == Keys.Down)
            {
                frog.Move(0, 1);
                Refresh();

            }
            if (e.KeyCode == Keys.Right)
            {
               
                frog.Move(1, 0);
                Refresh();
            }
            if (e.KeyCode == Keys.Left)
            {
                
                frog.Move(-1, 0);
                Refresh();
            }

            //quit game
            if (e.KeyCode == Keys.Q)
            {
                this.Close();
            }

        }

        //moving objects (interval = 50)
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Car car in cars)
            {
                car.Update();

                //if the car hits Frogger - lose life
                if (frog.Intersects(car)) 
                {
                    life--;
                    lifeFrogger.RemoveAt(life);
                    gameOver(); 
                }
            }

            Refresh();

            foreach (Log log in logs)
            {
                log.Update();
            }

            //if Frogger catches children - add points
            for (int i = 0; i < smallFrog.Count; i++)
            {
                
                if (frog.Intersects(smallFrog[i]))
                {
                    catchSmallFrog++;  //number catch children
                    smallFrog.RemoveAt(i);
                    changeLevel(catchSmallFrog); //change level game
                    gameWin();
                    
                }

            }
        }

        //countdown of time game
        private void t_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 6)
                {
                    m = 0;
                    h += 1;
                }

                labelTimeGame.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                resultTimeGame = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));

            }));
        }


        //Frogger returns to the starting position
        void resetGame() 
        {
            frog = new Frog(panel1.Width / 2 - grid / 2, panel1.Height - grid, grid);
            //return starting position
            frog.Attach(null);
        }

        //if Frogger loses three life = GameOver
        void gameOver() 
        {
            if (life > 0)
            {
                resetGame();
            }
            //GAMEOVER
            else
            {
                
                labelEndGame.Enabled = true;
                labelEndGame.Text = "GAME OVER";
                timer1.Stop(); //stop the game
                t.Stop();     //stop time
                audio.Stop(); //stop music
            }
        }

        // player wins the game
        void gameWin()
        {
            //if catch five children
            if (catchSmallFrog == 5 ) 
            {
                timer1.Stop();
                t.Stop();   
                //open Form2 save username and time game in the ranking.txt
                formWinner = new Form2(resultTimeGame, HideWin);
                formWinner.StartPosition = FormStartPosition.CenterScreen;
                formWinner.ShowDialog();
            }
            else
            {
                resetGame();    
            }
        }

        //changing the speed of cars and logs when increase the level of the game
        void changeLevel(int catchSmallFrog)
        {
            float vSpeed;
            
            if(catchSmallFrog == 1)
            {

                for (int i = 0; i < cars.Length; i++)
                {
                    if (cars[i].Speed > 0)
                    {
                        vSpeed = 2;
                    }
                    else
                    {
                        vSpeed = -2;
                    }

                    cars[i].Speed = cars[i].Speed + vSpeed;
                }

                for (int i = 0; i < logs.Length; i++)
                {
                    if (logs[i].Speed > 0)
                    {
                        vSpeed = 2;
                    }
                    else
                    {
                        vSpeed = -2;
                    }

                    logs[i].Speed = logs[i].Speed + vSpeed;
                }

            }
            else if (catchSmallFrog == 2)
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    if (cars[i].Speed > 0)
                    {
                        vSpeed = 3;
                    }
                    else
                    {
                        vSpeed = -3;
                    }

                    cars[i].Speed = cars[i].Speed + vSpeed;
                }

                for (int i = 0; i < logs.Length; i++)
                {
                    if (logs[i].Speed > 0)
                    {
                        vSpeed = 3;
                    }
                    else
                    {
                        vSpeed = -3;
                    }

                    logs[i].Speed = logs[i].Speed + vSpeed;
                }
            }
            else if (catchSmallFrog == 3)
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    if (cars[i].Speed > 0)
                    {
                        vSpeed = 3;
                    }
                    else
                    {
                        vSpeed = -3;
                    }

                    cars[i].Speed = cars[i].Speed + vSpeed;
                }

                for (int i = 0; i < logs.Length; i++)
                {
                    if (logs[i].Speed > 0)
                    {
                        vSpeed = 4;
                    }
                    else
                    {
                        vSpeed = -4;
                    }

                    logs[i].Speed = logs[i].Speed + vSpeed;
                }
            }
            else if (catchSmallFrog == 4)
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    if (cars[i].Speed > 0)
                    {
                        vSpeed = 3;
                    }
                    else
                    {
                        vSpeed = -3;
                    }

                    cars[i].Speed = cars[i].Speed + vSpeed;
                }

                for (int i = 0; i < logs.Length; i++)
                {
                    if (logs[i].Speed > 0)
                    {
                        vSpeed = 5;
                    }
                    else
                    {
                        vSpeed = -5;
                    }

                    logs[i].Speed = logs[i].Speed + vSpeed;
                }
            }
        }

        private void HideWin() //hide window Form1
        {
            this.Hide();
        }

        

    }
    
}
