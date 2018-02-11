using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerGame
{
    class Car : Rectangle
    {

        float speed;
        float grid = 70;
        Image imageCar;
        Color c;

        public float Speed { get => speed; set => speed = value; }
        public Color C { get => c; set => c = value; }

        public Car(float x, float y, float w, float h, float s, Color c, Image imageCar)

        : base(x, y, w, h)
        {
            Speed = s;
            C = c;
            this.imageCar = imageCar;
        }

       
        public void Update()
        {
            //car moves
            x = x + Speed;

            //cars appear when outside the window
            if (Speed > 0 && x > 996 + grid)         
            {
                x = -w-grid;  
            }
            else if (Speed < 0 && x < -w-grid )
            {
                x = 996 + grid;
            }
            
        }

        public void Show(Graphics graphics)
        {
          
            graphics.DrawImage(imageCar, x, y, w, h); 
        }
    }
}
