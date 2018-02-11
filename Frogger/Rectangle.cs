using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerGame
{
    class Rectangle
    {
        public float x;
        public float y;
        public float w;
        public float h;

        public Rectangle(float x, float y, float w, float h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        //check if the rectangles intersect - if true - rectangles do not intersect
        public Boolean Intersects(Rectangle other)       
        {                                         

            float left = x;
            float right = x + w;  
            float bottom = y;
            float top = y + h;

            float oleft = other.x;
            float oright = other.x + other.w;
            float obottom = other.y;
            float otop = other.y + other.h;

            if (oleft < right && left < oright && obottom < top)
                return bottom < otop;
            else
                return false;

        }
    }


    
}
