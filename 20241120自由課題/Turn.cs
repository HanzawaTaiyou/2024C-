using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
using System.Windows.Forms;
using System.Reflection.Emit;

namespace _20241120自由課題
{
    internal class Turn : System.Windows.Forms.Label
    {


        string BB;

        public Turn(string text, int x, int y, int width, int height)
        {
            Text = text;

            Location = new Point(x, y);

            Size = new Size(width, height);

            Font = new Font(Font.FontFamily, 28);
        }

        public  void NextTurn(int AA)
        {
            BB = AA.ToString();
            Text = $"現在のターン数：{BB}ターン";
        }

    }
}
