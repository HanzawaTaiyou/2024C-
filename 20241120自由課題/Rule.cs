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
    class Rule : Button
    {
        Form1 _form1;

        public Rule(int x, int y, int width, int height)
        {

            Click += OnClick;

            Location = new Point(x, y);

            Size = new Size(width, height);

            Text = "説明書";

            Font = new Font(Font.FontFamily, 30);

        }

        public void OnClick(object sender,EventArgs e)
        {
            MessageBox.Show
                ("【〇✕ゲーム】\n\n自身の記号(〇または✕)を縦、横、斜めのいずれかに３つ並べると勝利になります。" +
                "\n〇のプレイヤーが先行で、1つずつ交互に駒を置きます。" +
                "\n駒は1つの記号につき３つあり、駒３つが全て置かれている場合は、\n 一番長く置かれている駒を移動させます。" +
                "\n駒は、白い何も置かれていないマスにのみ置くことが出来ます。" +
                "\n\nどの駒がいつ置かれたのか、どこに置けば勝利につながるかをよく見極めて、勝利を目指しましょう！" +
                "\n\n操作方法：駒を置く(左クリック)","説明書");
        }
    }
}
