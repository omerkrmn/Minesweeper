using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Helper
{
    public static class ApplicationConstants
    {
        private static Image mineImage;
        private static Image flagImage;
        private static Image floor;
        private static Image grass;

        public static Ceil[,] ceil {  get; set; }

        public static readonly int BUTTON_WIDTH = 32;
        public static readonly int BUTTON_HEIGTH = 32;

        public static Image MineImage
        {
            get
            {
                if (mineImage is null)
                    mineImage = Image.FromFile("");
                return mineImage;
            }
        }
        public static Image Grass
        {
            get
            {
                if (grass is null)
                {
                    grass = Image.FromFile("assets/grass.png");
                }
                return grass;
            }
        }
        public static Image FlagImage
        {
            get
            {
                if (flagImage is null)
                    flagImage = Image.FromFile("assets/flag.jpg");
                return flagImage;
            }
        }
        public static Image FloorImage
        {
            get
            {
                if (floor is null)
                    floor = Image.FromFile("assets/floor.png");
                return floor;
            }
        }


    }
}
