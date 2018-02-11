using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FroggerGame
{
    class Frog : Rectangle
    {
        float grid = 70;
        int life = 3;
    
        
        Log attached = null;

        public int Life { get => life; set => life = value; }

        public Frog(float x, float y, float w)

        : base(x, y, w, w)
        {
         
        }

        public void Attach(Log log)
        {
            attached = log;
        }

        //if the Frogger jumped on the log(attached to the log) - speed Frogger = speed log
        public void Update()
        {
            if(attached != null)
            {
                this.x += attached.Speed;
            }

            //Frogger can not go outside the window - it must slip down 
            this.x = ValBetween(x, 0, 996 - w); 
        }

        public static float ValBetween(float value, float minimum, float maximum) 
        {
            return (Math.Min(maximum, Math.Max(minimum, value)));
        }

        public void Show(Graphics graphics)
       {
            
            Image imageFrog = Properties.Resources.Frogger; 
            graphics.DrawImage(imageFrog, x, y, w, w);

        }

        //move Frogger
        //directions moving Frogger x - left,right; y- top,bottom increase or decrease by 70
        public void Move(float xdir, float ydir) 
        {
            x += xdir * grid;
            y += ydir * grid;

            if (y <= 0)
            {
                y = 0;
            }
            if (x <= 0)
            {
                x = 0;
            }
            if (y >= 630) //panel.Height = 630
            {
                y = 630-grid;

            }
            if (x >= 996) //panel.Width = 996
            {
                x = 996 - grid; 

            }
        }
    }
}
