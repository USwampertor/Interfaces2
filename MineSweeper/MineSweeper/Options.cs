using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Options : Form
    {
        public int sWidth, sHeight, sMines;

        int minheight = 10, minwidth = 10, maxheight = 50, maxwidth = 50;
        TextBox tWidth = new TextBox();
        TextBox tHeight = new TextBox();
        TextBox tMines = new TextBox();
        int minmines, maxmines;
        public Options()
        {

            InitializeComponent();
            InitializeDynamicComponent();
        }

        public void InitializeDynamicComponent()
        {
            this.Height = 200;
            this.Width = 250;
            this.MaximumSize = new Size(200, 250);
            this.MinimumSize = new Size(200, 250);


            Button
                wUp = new Button(),
                hUp = new Button(),
                mUp = new Button(),
                wDown = new Button(),
                hDown = new Button(),
                mDown = new Button(),
                EButton = new Button(),
                startButton = new Button();
            Label
                lWidth = new Label(),
                lHeight = new Label(),
                lMines = new Label(),
                title = new Label();

            startButton.DialogResult = DialogResult.OK;
            startButton.Tag = DialogResult.OK;
            startButton.Text = DialogResult.OK.ToString();
            EButton.Text = DialogResult.OK.ToString();

            title.Text = "Selecciona el tamaño del juego";
            title.Width = TextRenderer.MeasureText(title.Text, title.Font).Width;
            wDown.Text = "<";
            wDown.Width = TextRenderer.MeasureText(wDown.Text, wDown.Font).Width * 2;
            hDown.Text = "<";
            hDown.Width = TextRenderer.MeasureText(hDown.Text, hDown.Font).Width * 2;
            mDown.Text = "<";
            mDown.Width = TextRenderer.MeasureText(mDown.Text, mDown.Font).Width * 2;
            wUp.Text = ">";
            wUp.Width = TextRenderer.MeasureText(wUp.Text, wUp.Font).Width * 2;
            hUp.Text = ">";
            hUp.Width = TextRenderer.MeasureText(hUp.Text, hUp.Font).Width * 2;
            mUp.Text = ">";
            mUp.Width = TextRenderer.MeasureText(mUp.Text, mUp.Font).Width * 2;
            lWidth.Text = "Ancho";
            lWidth.Size = TextRenderer.MeasureText(lWidth.Text, lWidth.Font);
            lMines.Text = "Minas";
            lMines.Size = TextRenderer.MeasureText(lWidth.Text, lWidth.Font);
            lHeight.Text = "Alto";
            lHeight.Size = TextRenderer.MeasureText(lWidth.Text, lWidth.Font);
            tWidth.Text = minwidth.ToString();
            tWidth.Width = 30;
            tHeight.Text = minheight.ToString();
            tHeight.Width = 30;
            minmines = (int.Parse(tWidth.Text) * int.Parse(tHeight.Text) / 10);
            maxmines = (int.Parse(tWidth.Text) * int.Parse(tHeight.Text) / 2);
            tMines.Text = minmines.ToString();
            tMines.Width = 30;

            tWidth.Height = wDown.Size.Height;
            tHeight.Height = wDown.Size.Height;
            tMines.Height = wDown.Size.Height;

            title.Location = new Point
                (((this.Width / 2) - (title.Width / 2)), 10);

            lWidth.Location = new Point
               (((this.Width / 5) - (lWidth.Size.Width / 2)), ((this.Height / 3) - (lWidth.Height / 2)));
            wDown.Location = new Point
                (((lWidth.Location.X) + (lWidth.Size.Width) + 1), (lWidth.Location.Y - (wDown.Size.Height / 4)));
            tWidth.Location = new Point
                (((wDown.Location.X) + (wDown.Size.Width) + 1), (lWidth.Location.Y - (tWidth.Size.Height / 5)));
            wUp.Location = new Point
                (((tWidth.Location.X) + (tWidth.Size.Width) + 1), (lWidth.Location.Y - (wUp.Size.Height / 4)));
            lHeight.Location = new Point
                (((this.Width / 5) - (lHeight.Size.Width / 2)), ((tWidth.Location.Y) + (tWidth.Size.Height) + 5));
            hDown.Location = new Point
                (((lHeight.Location.X) + (lHeight.Size.Width) + 1), (lHeight.Location.Y - (hDown.Size.Height / 4)));
            tHeight.Location = new Point
                (((hDown.Location.X) + (hDown.Size.Width) + 1), (lHeight.Location.Y - (tHeight.Size.Height / 5)));
            hUp.Location = new Point
                (((tHeight.Location.X) + (tHeight.Size.Width) + 1), (lHeight.Location.Y - (hUp.Size.Height / 4)));
            lMines.Location = new Point
                (((this.Width / 5) - (lHeight.Size.Width / 2)), ((tHeight.Location.Y) + (tHeight.Size.Height) + 5));
            mDown.Location = new Point
                (((lMines.Location.X) + (lHeight.Size.Width) + 1), (lMines.Location.Y - (mDown.Size.Height / 4)));
            tMines.Location = new Point
                (((mDown.Location.X) + (mDown.Size.Width) + 1), (lMines.Location.Y - (tMines.Size.Height / 5)));
            mUp.Location = new Point
                (((tMines.Location.X) + (tMines.Size.Width) + 1), (lMines.Location.Y - (mUp.Size.Height / 4)));

            EButton.Location = new Point
                (((this.Width / 2) - (EButton.Width / 2)), ((2 * this.Height / 3) - (EButton.Height / 2)));


            
            EButton.Click += new EventHandler(EButton_Click);
            startButton.Click += new EventHandler(OptionsButton_Click);
            wUp.Click += new EventHandler(wUp_Click);
            hUp.Click += new EventHandler(hUp_Click);
            mUp.Click += new EventHandler(mUp_Click);
            wDown.Click += new EventHandler(wDown_Click);
            hDown.Click += new EventHandler(hDown_Click);
            mDown.Click += new EventHandler(mDown_Click);

            Controls.Add(title);
            Controls.Add(lWidth);
            Controls.Add(lHeight);
            Controls.Add(lMines);
            Controls.Add(EButton);
            Controls.Add(tWidth);
            Controls.Add(tHeight);
            Controls.Add(tMines);
            Controls.Add(wUp);
            Controls.Add(hUp);
            Controls.Add(mUp);
            Controls.Add(wDown);
            Controls.Add(hDown);
            Controls.Add(mDown);
        }
        private void SetMinMines()
        {
            tMines.Text = (int.Parse(tWidth.Text) * int.Parse(tHeight.Text) / 10).ToString();
        }
        private void Mines()
        {

            maxmines = (int.Parse(tWidth.Text) * int.Parse(tHeight.Text) / 2);
            minmines = (int.Parse(tWidth.Text) * int.Parse(tHeight.Text) / 10);
        }
        private void mUp_Click(object sender, EventArgs e)
        {
            Mines();
            int up = minmines;
            if (tMines.TextLength != 0)
            {
                up = int.Parse(tMines.Text);
                up++;

                if (up >= maxmines)
                {
                    up = maxmines;
                }
                if (up <= minmines)
                {
                    up = minmines;
                }

            }
            tMines.Text = up.ToString();

        }
        private void wUp_Click(object sender, EventArgs e)
        {
            int up = minwidth;
            if (tWidth.TextLength != 0)
            {
                up = int.Parse(tWidth.Text);
                up++;
                if (up >= maxwidth)
                {
                    up = maxwidth;
                }
                if (up <= minwidth)
                {
                    up = minwidth;
                }

            }
            tWidth.Text = up.ToString();
            SetMinMines();
        }
        private void hUp_Click(object sender, EventArgs e)
        {
            int up = minheight;
            if (tHeight.TextLength != 0)
            {
                up = int.Parse(tHeight.Text);
                up++;
                if (up >= maxheight)
                {
                    up = maxheight;
                }
                if (up <= minheight)
                {
                    up = minheight;
                }

            }
            tHeight.Text = up.ToString();
            SetMinMines();
        }
        private void wDown_Click(object sender, EventArgs e)
        {
            int down = minwidth;
            if (tWidth.TextLength != 0)
            {
                down = int.Parse(tWidth.Text);
                down--;
                if (down >= maxwidth)
                {
                    down = maxwidth;
                }
                if (down <= minwidth)
                {
                    down = minwidth;
                }

            }
            tWidth.Text = down.ToString();
            SetMinMines();
        }
        private void hDown_Click(object sender, EventArgs e)
        {
            int down = minheight;
            if (tHeight.TextLength != 0)
            {
                down = int.Parse(tHeight.Text);
                down--;
                if (down >= maxheight)
                {
                    down = maxheight;
                }
                if (down <= minheight)
                {
                    down = minheight;
                }

            }

            tHeight.Text = down.ToString();
            SetMinMines();
        }
        private void mDown_Click(object sender, EventArgs e)
        {
            Mines();
            int down = minmines;
            if (tMines.TextLength != 0)
            {
                down = int.Parse(tMines.Text);
                down--;
                if (down >= maxmines)
                {
                    down = maxmines;
                }
                if (down <= minmines)
                {
                    down = minmines;
                }

            }
            tMines.Text = down.ToString();
        }
        private void Options_Load(object sender, EventArgs e)
        {

        }

        public void EButton_Click(object sender, EventArgs e)
        {
            Mines();
            if (
                tHeight.TextLength == 0 ||
                tWidth.TextLength == 0 ||
                tMines.TextLength == 0 ||
                int.Parse(tHeight.Text) < minheight ||
                int.Parse(tWidth.Text) < minwidth ||
                int.Parse(tMines.Text) < minmines||
                int.Parse(tMines.Text) > maxmines)
                

            {
                MessageBox.Show("Los valores no pueden ser menores a 10 o ser nulos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sMines = int.Parse(tMines.Text);
                sHeight = int.Parse(tHeight.Text);
                sWidth = int.Parse(tWidth.Text);
                OptionsButton_Click(sender, e);
            }

        }
        public void OptionsButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }
    }
}