using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace _20241120自由課題
{
    public partial class Form1 : Form
    {
        Turn _turn;
        judge _judge;

        string j;

        int X;
        int winOK = 0;
        int Count = 1;
        int[] winchecker = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };


        Queue<int> a = new Queue<int>();

        private List<FieldButton> buttons = new List<FieldButton>();


        public Form1()
        {
            InitializeComponent();

            int a = 0;

            

            for(int i = 0; i < 9; i++)
            {
                j = i.ToString();
                FieldButton fieldbutton = new FieldButton(this, a % 3 * 200 + 50,(a / 3) * 200 + 50 ,200,200,i);
                buttons.Add(fieldbutton);
                Controls.Add(fieldbutton);
                a++;

            }

            Rule rule = new Rule(1050, 50, 200, 100);
            Controls.Add(rule);

            _turn = new Turn("現在のターン数：1ターン", 780, 245 ,600 ,100);
            Controls.Add(_turn);

            _judge = new judge("〇1を置いてください。", 800, 450, 600, 100);
            Controls.Add(_judge);
        }


        public int Counta()
        {
            Count++;
            _turn.NextTurn(Count);
            _judge.NextTurn(Count);
            return Count;
        }

        public int checker(int marubatu,int ID)
        {
            if (marubatu % 2 == 0)
            {
                //キューに押されたボタンのIDを入れる
                a.Enqueue(ID);
                //〇の場合、〇を表示してボタンを赤色にする
                buttons[ID].Text = "〇";
                buttons[ID].BackColor = Color.OrangeRed;
                winchecker[ID] = 1;
            }
            else
            {
                //キューに押されたボタンのIDを入れる
                a.Enqueue(ID);
                //✕の場合、✕を表示してボタンを青色にする
                buttons[ID].Text = "✕";
                buttons[ID].BackColor = Color.CornflowerBlue;
                winchecker[ID] = 2;
            }

            X = -1;

            if(a.Count == 7)
            {
                X = a.Dequeue();
                buttons[X].Text = "";
                buttons[X].BackColor = Color.White;
                winchecker[X] = 0;
            }

            if (//〇横揃い
               (winchecker[0] == 1 && winchecker[1] == 1 && winchecker[2] == 1) ||
               (winchecker[3] == 1 && winchecker[4] == 1 && winchecker[5] == 1) ||
               (winchecker[6] == 1 && winchecker[7] == 1 && winchecker[8] == 1) ||
               //〇縦揃い
               (winchecker[0] == 1 && winchecker[3] == 1 && winchecker[6] == 1) ||
               (winchecker[1] == 1 && winchecker[4] == 1 && winchecker[7] == 1) ||
               (winchecker[2] == 1 && winchecker[5] == 1 && winchecker[8] == 1) ||
               //〇斜め揃い
               (winchecker[0] == 1 && winchecker[4] == 1 && winchecker[8] == 1) ||
               (winchecker[2] == 1 && winchecker[4] == 1 && winchecker[6] == 1)
               )
            {
                winOK = 1;
            }

            if (//✕横揃い
               (winchecker[0] == 2 && winchecker[1] == 2 && winchecker[2] == 2) ||
               (winchecker[3] == 2 && winchecker[4] == 2 && winchecker[5] == 2) ||
               (winchecker[6] == 2 && winchecker[7] == 2 && winchecker[8] == 2) ||
               //✕縦揃い
               (winchecker[0] == 2 && winchecker[3] == 2 && winchecker[6] == 2) ||
               (winchecker[1] == 2 && winchecker[4] == 2 && winchecker[7] == 2) ||
               (winchecker[2] == 2 && winchecker[5] == 2 && winchecker[8] == 2) ||
               //✕斜め揃い
               (winchecker[0] == 2 && winchecker[4] == 2 && winchecker[8] == 2) ||
               (winchecker[2] == 2 && winchecker[4] == 2 && winchecker[6] == 2)
               )
            {
                winOK = 2;
            }

            return winOK;

        }

        public void Win(int judge,int turn)
        {
            if (judge == 1)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (winchecker[i] == 1)
                    {
                        buttons[i].BackColor = Color.Gold;
                    }
                }
                _judge.Text = "   〇の勝ちです！";
                MessageBox.Show($"  〇の勝ち！   総ターン数：{turn}ターン","結果発表");
                Close();
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    if (winchecker[i] == 2)
                    {
                        buttons[i].BackColor = Color.Gold;
                    }
                }
                _judge.Text = "   ✕の勝ちです！";
                MessageBox.Show($"  ✕の勝ち！   総ターン数：{turn}ターン", "結果発表");
                Close();
            }

        }

        public int judge()
        {
            return winOK;
        }

    }
}
