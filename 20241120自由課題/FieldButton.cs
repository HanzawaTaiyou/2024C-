using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace _20241120自由課題
{
    class FieldButton : Button
    {
        Form1 _form1;

        int A;
        int clear;
        int judge;
        public int ID;

        public FieldButton(Form1 form1,int x, int y,int width,int height,int i)
        {
            _form1 = form1;

            Click += OnClick;

            Location = new Point(x, y);

            Size = new Size(width, height);

            Font = new Font(Font.FontFamily, 60);

            ID = i;
        }

        public void OnClick(object sender,EventArgs e)
        {

            clear = _form1.judge();
            if (Text != "〇" && Text != "✕" && clear == 0)
            {
                A = _form1.Counta();

                if (A % 2 == 0)
                {
                    judge =_form1.checker(A,ID);
                }
                else
                {
                    judge = _form1.checker(A, ID);
                }

                if (judge == 1 || judge == 2)
                {
                    _form1.Win(judge,A);
                }

            }
           
        }

        

    }
}
