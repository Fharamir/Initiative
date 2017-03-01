using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iniziativa
{
    public partial class Main : Form
    {
        const int max = 13;
        const int distance = 55;

        PictureBox Now;
        bool drag;
        Point startPoint;
        Image CloseImg = Properties.Resources.Red_2;
        Person[] P;
        int Total;
        short now;

        public Main()
        {
            InitializeComponent();
            TransparencyKey = Color.DarkGray;
            Total = 0;
            P = new Person[max];
            now = -1;

            Now = new PictureBox();
            Now.Location = new Point(59, 180);
            Now.Size = new Size(68, 0);
            Now.Image = Properties.Resources.Turno;
            Now.BackColor = Color.Transparent;
            this.Controls.Add(Now);

            ToolTip TTP1 = new ToolTip();
            TTP1.InitialDelay = 500;
            TTP1.SetToolTip(Next, "Go to the next guy");

            ToolTip TTP2 = new ToolTip();
            TTP2.InitialDelay = 500;
            TTP2.SetToolTip(Recalc, "Roll every initiative again");

            ToolTip TTP3 = new ToolTip();
            TTP3.InitialDelay = 500;
            TTP3.SetToolTip(button1, "Add a guy to the screen");

            ToolTip TTP4 = new ToolTip();
            TTP4.InitialDelay = 100;
            TTP4.SetToolTip(Chiudi, "Exit");
        }

        private void MMDown(object sender, MouseEventArgs e)
        {
            this.drag = true;
            this.startPoint = new Point(e.X, e.Y);
        }

        private void MMMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.startPoint.X, p2.Y - this.startPoint.Y);
                this.Location = p3;
            }
        }

        private void MMUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        private void CloseHover(object sender, EventArgs e)
        {
            Chiudi.BackgroundImage = CloseImg;
        }

        private void CloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseLeave(object sender, EventArgs e)
        {
            Chiudi.BackgroundImage = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Total < max)
            {
                Boolean no = true;

                while (no)
                {
                    try
                    {
                        string name = Microsoft.VisualBasic.Interaction.InputBox("Who's the next vittim?", "Name:", "");
                        if (name == "") return;
                        string mod_s = Microsoft.VisualBasic.Interaction.InputBox("Initiative modifier", "The value must be between " + short.MinValue + " and " + short.MaxValue, "0");
                        if (mod_s == "") return;

                        short mod = Convert.ToInt16(mod_s);

                        P[Total] = new Person(name, mod);
                        no = false;
                    }
                    catch { no = true; MessageBox.Show("The value is not valid"); }
                }

                foreach (Control C in P[Total].GetControls())
                {
                    this.Controls.Add(C);
                    C.BringToFront();
                }

                if (Total == 0)
                {
                    now = 0;
                    Now.Size = new Size(68, 50);
                    Spostanow();
                }

                P[Total].NewPos(Total);

                Control[] S = P[Total].GetControls();
                
                S[1].Click += Up_Click;
                S[2].Click += Down_Click;
                S[3].Click += Change_Click;
                S[4].Click += Recalc_Click;
                S[5].Click += Skull_Click;

                Total++;

                Reorder();
                Next.Focus();
            }
        }

        private void Reorder()
        {
            for (int y = 0; y < Total - 1; y++)
                for (int x = 0; x < Total - 1 - y; x++)
                {
                    if (P[x].Iniz < P[x + 1].Iniz)
                        ScambiaP(x, x + 1);

                    if (P[x].Iniz == P[x + 1].Iniz)
                        if (P[x].Iniz2 > P[x + 1].Iniz2)
                            ScambiaP(x, x + 1);
                }

            now = 0;
            Spostanow();
            ResetTurni();
        }

        private void Recalc_Click(object sender, EventArgs e)
        {
            int pos = (int)((PictureBox)sender).Tag;
            P[pos].ReIniz();
            Reorder();
        }

        private void Skull_Click(object sender, EventArgs e)
        {
            int pos = (int)((PictureBox)sender).Tag;

            if (pos == now)
            {
                if ((pos + 1) == Total)
                {
                    now = 0;
                    Spostanow();
                }
            }

            if (pos < now)
            {
                now--;
                Spostanow();
            }
            
            while (pos < (Total - 1))
            {
                ScambiaP(pos, pos + 1);
                pos++;
            }

            foreach (Control C in P[pos].GetControls())
                this.Controls.Remove(C);

            Total--;

            if (Total == 0)
            {
                now = -1;
                Now.Size = new Size(68, 0);
                Now.Location = new Point(59, 180);
            }
        }

        private void Change_Click(object sender, EventArgs e)
        {
            int pos = (int)((PictureBox)sender).Tag;
            Boolean no = true;
            short newmod = 0;

            while (no)
            { 
                try
                {
                    string mod_s = Microsoft.VisualBasic.Interaction.InputBox("Initiative modifier", "The value must be between " + short.MinValue + " and " + short.MaxValue, "0");
                    if (mod_s == "") return;
                    newmod = Convert.ToInt16(mod_s);
                    no = false;
                }
                catch { no = true; MessageBox.Show("The value is not valid"); }
            }

            P[pos].NewMod(newmod);
            Reorder();
        }

        private void Down_Click(object sender, EventArgs e)
        {
            int pos = (int)((PictureBox)sender).Tag;

            if (pos < (Total - 1))
            {
                if (now == pos)
                {
                    now++;
                    Spostanow();
                }
                else
                    if (now == (pos + 1))
                    {
                        now--;
                        Spostanow();
                    }
                ScambiaP(pos, pos + 1);
            }
        }

        private void Up_Click(object sender, EventArgs e)
        {
            int pos = (int)((PictureBox)sender).Tag;

            if (pos > 0)
            {
                if (now == pos)
                {
                    now--;
                    Spostanow();
                }
                else
                    if (now == (pos - 1))
                    {
                        now++;
                        Spostanow();
                    }
                ScambiaP(pos, pos - 1);
            }
        }

        private void ScambiaP (int a, int b)
        {
            P[a].NewPos(b);
            P[b].NewPos(a);

            Person persona = P[a];
            P[a] = P[b];
            P[b] = persona;
        }

        private void Spostanow()
        {
            Now.Location = new Point(59, 180 + (now * distance));
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (now >= 0)
            {
                P[now].Advance();
                now++;

                if (now == Total)
                    now = 0;

                Spostanow();
            }
        }

        private void ResetTurni ()
        {
            for (int x = 0; x < Total; x++)
                P[x].CambiaTurno(0);
        }

        private void Recalc_Button(object sender, EventArgs e)
        {
            for (int x = 0; x < Total; x++)
                P[x].ReIniz();
            Reorder();
            Next.Focus();
        }
    }
}
