using Minesweeper.Helper;
using Minesweeper.Helper.Enums;
using Minesweeper.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace Minesweeper.Models
{
    public class Board
    {
        private Difficults difficult;
        public Ceil[,] Ceils;
        private int mineCunt;
        private Random rnd;
        private ControlCollection controls;
        private int lengthrow;
        private int lengthcolumn;

        private int currentMineCount;
        public Board(Difficults difficult, ControlCollection controls)
        {
            this.controls = controls;
            this.difficult = difficult;
            Ceils =  new Ceil[(int)difficult, (int)difficult];
            mineCunt = difficult.GetMineCount();
            currentMineCount = mineCunt;
            lengthrow = (int)difficult;
            lengthcolumn = (int)difficult;
            rnd = new Random();

            AddCeilOnBoard();
            Ceil.ceils = Ceils;
            AddMineOnBoard();
            AddMineCount();
            DrawCeils();
        }
        private void AddMineCount()
        {
            int width = Ceils.GetLength(0);
            int height = Ceils.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (Ceils[x, y].isMine)
                        continue;
                    int mineCount = 0;
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (dx == 0 && dy == 0)
                                continue;
                            int newX = x + dx;
                            int newY = y + dy;
                            if (CheckBounds(newX, newY))
                            {
                                if (Ceils[newX, newY].isMine)
                                {
                                    mineCount++;
                                }
                            }
                        }
                    }
                    Ceils[x, y].sizeOfAroundMine = mineCount;
                }
            }
        }



        private bool CheckBounds(int row, int col)
        {
            return row >= 0 && row < lengthrow && col >= 0 && col < lengthcolumn;
        }

        private void DrawCeils()
        {
            for (int i = 0; i < Ceils.GetLength(0); i++)
            {
                for (int j = 0; j < Ceils.GetLength(1); j++)
                {
                    controls.Add(Ceils[i, j].btn);
                }
            }
        }


        private void AddCeilOnBoard()
        {
            for (int i = 0; i < Ceils.GetLength(0); i++)
            {
                for (int j = 0; j < Ceils.GetLength(1); j++)
                {
                    Ceils[i, j] = new Ceil(j * ApplicationConstants.BUTTON_WIDTH, i * ApplicationConstants.BUTTON_HEIGTH);
                }
            }
        }
       
        private void AddMineOnBoard()
        {
            for (int i = 0; i < mineCunt; i++)
            {
                var x = rnd.Next((int)difficult);
                var y = rnd.Next((int)difficult);
                while (Ceils[x, y].isMine)
                {
                    x = rnd.Next((int)difficult);
                    y = rnd.Next((int)difficult);
                }
                Ceils[x, y].isMine = true;
                Ceils[x, y].btn.BackColor = Color.Black;
            }
        }
    }
}
