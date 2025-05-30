using Minesweeper.Helper.Enums;
using Minesweeper.Models;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private Board board;
        private Control.ControlCollection controlCollection;
        public Form1()
        {
            InitializeComponent();
            controlCollection = Controls;
            board = new Board(Difficults.Hard,controlCollection);
            MinimumSize = new Size(board.Ceils.GetLength(0) * 60, board.Ceils.GetLength(0) * 60);
        }
    }
}
