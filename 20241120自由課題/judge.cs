using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _20241120自由課題
{
    internal class judge : System.Windows.Forms.Label
    {

        public judge(string text, int x, int y, int width, int height)
        {
            Text = text;

            Location = new Point(x, y);

            Size = new Size(width, height);

            AutoSize = false;

            Font = new Font(Font.FontFamily, 30);

        }

        public void NextTurn(int AA)
        {

            if(AA % 2 == 1)
            {
                int b = AA % 6 ;
                if(b == 1)
                {
                    Text = "〇1を置いてください。";
                }
                else if(b == 3)
                {
                    Text = "〇2を置いてください。";
                }
                else
                {
                    Text = "〇3を置いてください。";
                }
                
            }
            else
            {
                int b = AA % 6;
                if (b == 2)
                {
                    Text = "✕1を置いてください。";
                }
                else if(b == 4)
                {
                    Text = "✕2を置いてください。";
                }
                else
                {
                    Text = "✕3を置いてください。";
                }
            }
            
        }
    }
}
