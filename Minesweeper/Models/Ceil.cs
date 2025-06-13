using Minesweeper.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Models
{
    public class Ceil
    {
        public int x { get; set; }
        public int y { get; set; }



        public int sizeOfAroundMine;
        public bool isMine;
        private bool isFlag;
        public bool isOpen;
        private bool textVisible;

        public static Ceil[,] ceils;


        public Button btn;
        public Ceil(int x, int y)
        {
            this.x = x;
            this.y = y;
            isMine = false;
            isFlag = false;
            isOpen = false;
            btn = new Button();
            InitButton();

        }

        private void InitButton()
        {
            btn.SetBounds(x, y, ApplicationConstants.BUTTON_WIDTH, ApplicationConstants.BUTTON_HEIGTH);
            btn.Location = new Point(x, y);
            btn.MouseDown += CeilOnBoard_MouseClick;
            btn.Image = ApplicationConstants.Grass;
            btn.TabStop = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
        }
        private void CeilOnBoard_MouseClick(object? sender, MouseEventArgs e)
        {

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (isMine)
                        MessageBox.Show("Game Over");
                    Reveal(y / ApplicationConstants.BUTTON_WIDTH, x / ApplicationConstants.BUTTON_HEIGTH);
                    break;
                case MouseButtons.Right:
                    DropFlag();
                    break;
            }
        }
        private void Reveal(int x, int y)
        {
            int width = ceils.GetLength(0);
            int height = ceils.GetLength(1);
            if (x < 0 || x >= width || y < 0 || y >= height)
                return;
            Ceil ceil = ceils[x, y];
            if (ceil.isOpen || ceil.isMine) return;
            ceil.Open();
            if (ceil.sizeOfAroundMine == 0)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx == 0 && dy == 0) continue;
                        Reveal(dx + x, dy + y);
                    }
                }
            }

        }
        private void DropFlag()
        {
            if (!isOpen)
            {
                if (!isFlag)
                {
                    btn.Image = ApplicationConstants.FlagImage;
                    btn.BackColor = Color.Green;
                    isFlag = true;
                }
                else
                {
                    btn.Image = ApplicationConstants.Grass;
                    btn.BackColor = Color.Blue;
                    isFlag = false;
                }
            }
        }
        public void Open()
        {
            btn.Image = ApplicationConstants.FloorImage;
            textVisible = true;
            SetTextVisible();
            isOpen = true;
        }

        private void SetTextVisible()
        {
            if (!isMine)
                _ = textVisible ? btn.Text = sizeOfAroundMine.ToString() : btn.Text = string.Empty;
            else _ = btn.Text = string.Empty;
        }
    }
}
