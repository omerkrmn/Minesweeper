using Minesweeper.Helper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Helper.Extensions
{
    public static class AppExtensions
    {
        public static int GetMineCount(this Difficults difficults)
        {
            var area = (int)difficults * (int)difficults;
            return (area / 4);
        }
    }
}
