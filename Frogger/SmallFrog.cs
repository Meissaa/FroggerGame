using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggerGame
{
    class SmallFrog : Rectangle
    {
        Color c;
        Image imageFrogger;

        public SmallFrog(float x, float y, float w, float h, Image imageFrogger)

        : base(x, y, w, h)
        {
            this.imageFrogger = imageFrogger;
        }

        public Color C { get => c; set => c = value; }
        public Image ImageFrogger { get => imageFrogger; set => imageFrogger = value; }

        public void Show(Graphics graphics)
        {
            graphics.DrawImage(imageFrogger, x, y, w, w);
        }


    }
}
