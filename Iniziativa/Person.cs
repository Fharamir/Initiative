using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Iniziativa
{
    class Person
    {
        const int distance = 55;

        PictureBox Main;
        PictureBox Up;
        PictureBox Down;
        PictureBox Change;
        PictureBox Recalc;
        PictureBox Skull;
        Label Nome;
        Label Ini;
        Label Turno;
        string Name;
        short Modifier;
        public short Iniz;
        public short Iniz2;
        public Boolean Status;
        short nturno;
        int position;
        Random R = new Random();

        public Person (string n, short mod)
        {
            Name = n;
            Modifier = mod;
            Status = true;
            nturno = 0;
            position = 0;
            Iniz2 = 100;

            Newgraphic();
            ReIniz();
        }

        public void Newgraphic()
        {
            ToolTip TUp = new ToolTip();
            ToolTip TDo = new ToolTip();
            ToolTip TCh = new ToolTip();
            ToolTip TRe = new ToolTip();
            ToolTip TSk = new ToolTip();

            TUp.InitialDelay = 500;
            TDo.InitialDelay = 500;
            TCh.InitialDelay = 500;
            TRe.InitialDelay = 500;
            TSk.InitialDelay = 500;

            Main = new PictureBox();
            Main.Size = new Size(344, 50);
            Main.BackColor = Color.Transparent;
            Main.Location = new Point(133, 180 + (position * distance));
            Main.BackgroundImage = Properties.Resources.Back;

            Up = new PictureBox();
            Up.Size = new Size(50, 25);
            Up.BackColor = Color.Transparent;
            Up.Location = new Point(477, 180 + (position * distance));
            Up.BackgroundImage = Properties.Resources.Up;
            Up.Tag = position;
            
            Down = new PictureBox();
            Down.Size = new Size(50, 25);
            Down.BackColor = Color.Transparent;
            Down.Location = new Point(477, 205 + (position * distance));
            Down.BackgroundImage = Properties.Resources.Down;
            Down.Tag = position;

            Change = new PictureBox();
            Change.Size = new Size(50, 50);
            Change.BackColor = Color.Transparent;
            Change.Location = new Point(527, 180 + (position * distance));
            Change.BackgroundImage = Properties.Resources.Change;
            Change.Tag = position;

            Recalc = new PictureBox();
            Recalc.Size = new Size(50, 50);
            Recalc.BackColor = Color.Transparent;
            Recalc.Location = new Point(577, 180 + (position * distance));
            Recalc.BackgroundImage = Properties.Resources.Recalc;
            Recalc.Tag = position;

            Skull = new PictureBox();
            Skull.Size = new Size(50, 50);
            Skull.BackColor = Color.Transparent;
            Skull.Location = new Point(627, 180 + (position * distance));
            Skull.BackgroundImage = Properties.Resources.skull;
            Skull.Tag = position;

            Nome = new Label();
            Nome.AutoSize = true;
            Nome.BackColor = Color.FromArgb(208, 208, 208);
            Nome.Font = new Font("Papyrus", 18, FontStyle.Regular);
            Nome.Text = Name;
            Nome.Location = new Point(142, 185 + (position * distance));

            Ini = new Label();
            Ini.AutoSize = true;
            Ini.TextAlign = ContentAlignment.MiddleRight;
            Ini.Text = Iniz.ToString();
            Ini.BackColor = Color.FromArgb(208, 208, 208);
            Ini.Font = new Font("Papyrus", 18, FontStyle.Regular);
            Ini.Location = new Point(471 - Ini.Width, 185 + (position * distance));

            Turno = new Label();
            Turno.AutoSize = true;
            Turno.BackColor = Color.Transparent;
            Turno.Font = new Font("Papyrus", 18, FontStyle.Regular);
            Turno.Text = nturno.ToString();
            Turno.Location = new Point(691, 185 + (position * distance));

            TUp.SetToolTip(Up, "Switch this guy with the one above");
            TDo.SetToolTip(Down, "Switch this guy with the one below");
            TCh.SetToolTip(Change, "Set a new initiative modifier");
            TRe.SetToolTip(Recalc, "Roll a new d20 for initiative result");
            TSk.SetToolTip(Skull, "Throw out this loser!");
        }

        public void NewMod (short mod)
        {
            Iniz -= Modifier;
            Modifier = mod;
            Iniz += Modifier;
            Iniz2 = 100;

            Ini.Text = Iniz.ToString();
            Ini.Location = new Point(471 - Ini.Width, 185 + (position * distance));
        }

        public void ReIniz()
        {
            Iniz = (short)(R.Next(1, 21) + Modifier);
            Ini.Text = Iniz.ToString();
            Iniz2 = 100;
            Ini.Location = new Point(471 - Ini.Width, 185 + (position * distance));
        }

        public void NewPos(int pos)
        {
            position = pos;
            Main.Location = new Point(133, 180 + (position * distance));
            Up.Location = new Point(477, 180 + (position * distance));
            Down.Location = new Point(477, 205 + (position * distance));
            Change.Location = new Point(527, 180 + (position * distance));
            Recalc.Location = new Point(577, 180 + (position * distance));
            Skull.Location = new Point(627, 180 + (position * distance));
            Nome.Location = new Point(142, 185 + (position * distance));
            Ini.Location = new Point(471 - Ini.Width, 185 + (position * distance));
            Turno.Location = new Point(691, 185 + (position * distance));

            Skull.Tag = position;
            Recalc.Tag = position;
            Change.Tag = position;
            Down.Tag = position;
            Up.Tag = position;
        }

        internal Control[] GetControls()
        {
            Control[] Arr = new Control[9];
            Arr[0] = Main;
            Arr[1] = Up;
            Arr[2] = Down;
            Arr[3] = Change;
            Arr[4] = Recalc;
            Arr[5] = Skull;
            Arr[6] = Nome;
            Arr[7] = Ini;
            Arr[8] = Turno;

            return Arr;
        }

        public void CambiaTurno(short T)
        {
            if (T == (short.MaxValue - 1))
                T = 0;

            nturno = T;
            Turno.Text = T.ToString();
        }

        public void Advance()
        {
            CambiaTurno((short)(nturno + 1));
        }
    }
}
