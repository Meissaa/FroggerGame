using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerGame
{
    class Log : Car
    {
        float speedLog;
        Color c;
        Image imageLog;
        

        public float SpeedLog { get => speedLog; set => speedLog = value; }
        public Image ImageLog { get => imageLog; set => imageLog = value; }


        public Log(float x, float y, float w, float h, float s, Color c, Image imageLog)
         : base(x, y, w, h, s, c, imageLog)
        {

        SpeedLog = s;
        ImageLog = imageLog;

        }
}
}
