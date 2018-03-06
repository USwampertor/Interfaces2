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
        public int sWidth, sHeight;
        
        TextBox tWidth = new TextBox();
        TextBox tHeight = new TextBox();
        public Options()
        {

            InitializeComponent();
            InitializeDynamicComponent();
        }

        public void InitializeDynamicComponent()
        {
            this.Height = 200;
            this.Width = 200;
<<<<<<< HEAD
            this.MaximumSize = new Size(200, 200);
            this.MinimumSize = new Size(150, 150);
=======
>>>>>>> e66d1b526680641f4d27bde2158a82e8ad4ec8be
            Button 
                wUp = new Button(),
                hUp = new Button(),
                wDown = new Button(),
                hDown = new Button(),
                EButton = new Button(),
                startButton = new Button();
            Label
                lWidth = new Label(),
                lHeight = new Label(),
                title = new Label();
            startButton.DialogResult = DialogResult.OK;
            startButton.Tag = DialogResult.OK;
            startButton.Text = DialogResult.OK.ToString();
            EButton.Text = DialogResult.OK.ToString();
            title.Text = "Selecciona el tamaño del juego";
            title.Width = TextRenderer.MeasureText(title.Text, title.Font).Width;
            wDown.Text = "<";
            wDown.Width = TextRenderer.MeasureText(wDown.Text, wDown.Font).Width*2;
            wUp.Text = ">";
            wUp.Width = TextRenderer.MeasureText(wUp.Text, wUp.Font).Width*2;
            hUp.Text = ">";
            hUp.Width = TextRenderer.MeasureText(hUp.Text, hUp.Font).Width * 2;
            hDown.Text = "<";
            hDown.Width = TextRenderer.MeasureText(hDown.Text, hDown.Font).Width * 2;
            lWidth.Text = "Ancho";
            lWidth.Size = TextRenderer.MeasureText(lWidth.Text, lWidth.Font);
            lHeight.Text = "Alto";
            lHeight.Size = TextRenderer.MeasureText(lWidth.Text, lWidth.Font);
            tWidth.Text = "5";
            tWidth.Width = 30;
            tHeight.Text = "5";
            tHeight.Width = 30;
            tWidth.Height = wDown.Size.Height;
            tHeight.Height = wDown.Size.Height;
            title.Location = new Point
                (((this.Width/2)-(title.Width/2)),10);
            lWidth.Location = new Point
               (((this.Width / 5) - (lWidth.Size.Width / 2)), ((this.Height / 3) - (lWidth.Height / 2)));
            wDown.Location = new Point
                (((lWidth.Location.X) +(lWidth.Size.Width)+1), (lWidth.Location.Y));
            tWidth.Location = new Point
                (((wDown.Location.X) + (wDown.Size.Width) + 1), (lWidth.Location.Y+1));
            wUp.Location = new Point
                (((tWidth.Location.X) + (tWidth.Size.Width) + 1), (lWidth.Location.Y));
            lHeight.Location = new Point
                (((this.Width / 5) - (lHeight.Size.Width / 2)), ((tWidth.Location.Y) + (tWidth.Size.Height) + 5));
            hDown.Location = new Point
                (((lHeight.Location.X) + (lHeight.Size.Width) + 1), (lHeight.Location.Y));
            tHeight.Location = new Point
                (((hDown.Location.X) + (hDown.Size.Width) + 1), (lHeight.Location.Y + 1));
            hUp.Location = new Point
                (((tHeight.Location.X) + (tHeight.Size.Width) + 1), (tHeight.Location.Y));
            EButton.Location = new Point
                (((this.Width / 2) - (EButton.Width / 2)), ((2*this.Height / 3) - (EButton.Height / 2)));
            this.SizeChanged += new EventHandler(WindowResize);
            EButton.Click+= new EventHandler(EButton_Click);
            startButton.Click += new EventHandler(OptionsButton_Click);
            wUp.Click += new EventHandler(wUp_Click);
            hUp.Click += new EventHandler(hUp_Click);
            wDown.Click += new EventHandler(wDown_Click);
            hDown.Click += new EventHandler(hDown_Click);
            Controls.Add(title);
            Controls.Add(lWidth);
            Controls.Add(lHeight);
            Controls.Add(EButton);
            Controls.Add(tWidth);
            Controls.Add(tHeight);
            Controls.Add(hUp);
            Controls.Add(hDown);
            Controls.Add(wDown);
            Controls.Add(wUp);

        }
        private void WindowResize(object sender, EventArgs e)
        {
<<<<<<< HEAD
            //MessageBox.Show("Dont touch that!","HEY!",MessageBoxButtons.OK, MessageBoxIcon.Error);
=======
            MessageBox.Show("Dont touch that!","HEY!",MessageBoxButtons.OK, MessageBoxIcon.Error);
>>>>>>> e66d1b526680641f4d27bde2158a82e8ad4ec8be
        }
        private void wUp_Click(object sender, EventArgs e)
        {
            int up = 5;
            if (tWidth.TextLength!=0)
            {
                up = int.Parse(tWidth.Text);
                if (up >= 100)
                {
                    up = 100;
                }
                if (up<=5)
                {
                    up = 5;
                }
                    
            }
            up++;
            tWidth.Text = up.ToString();


        }
        private void hUp_Click(object sender, EventArgs e)
        {
            int up = 5;
            if (tHeight.TextLength != 0)
            {
                up = int.Parse(tHeight.Text);
                up++;
                if (up >= 100)
                {
                    up = 100;
                }
                if (up <= 5)
                {
                    up = 5;
                }
                
            }
            tHeight.Text = up.ToString();
        }
        private void wDown_Click(object sender, EventArgs e)
        {
            int down = 5;
            if (tWidth.TextLength != 0)
            {
                down = int.Parse(tWidth.Text);
                down--;
                if (down >= 100)
                {
                    down = 100;
                }
                if (down <= 5)
                {
                    down = 5;
                }

            }

            tWidth.Text = down.ToString();
        }
        private void hDown_Click(object sender, EventArgs e)
        {
            int down = 5;
            if (tHeight.TextLength != 0)
            {
                down = int.Parse(tHeight.Text);
                down--;
                if (down >= 100)
                {
                    down = 100;
                }
                if (down <= 5)
                {
                    down = 5;
                }

            }

            tHeight.Text = down.ToString();
        }
        private void Options_Load(object sender, EventArgs e)
        {

        }
        public void EButton_Click(object sender, EventArgs e)
        {
            if (
                tHeight.TextLength == 0 || 
                tWidth.TextLength == 0 || 
                int.Parse(tHeight.Text) < 5||
                int.Parse(tWidth.Text) < 5)
            {
<<<<<<< HEAD
                MessageBox.Show("Los valores no pueden ser menores a 5 o ser nulos", "Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Error);
=======
                MessageBox.Show("Los valores no pueden ser menores a 5 o ser nulos", "Advertencia");
>>>>>>> e66d1b526680641f4d27bde2158a82e8ad4ec8be
            }
            else
            {
               
                sHeight = int.Parse(tHeight.Text);
                sWidth = int.Parse(tWidth.Text);
                OptionsButton_Click(sender, e);
            }
        }
        public void OptionsButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            
        }
<<<<<<< HEAD
=======

        public void gridGenerator(int xg, int yg, Form form)
        {
            int gameWidth, gameHeight;
            int ButtonWidth = 40;
            int ButtonHeight = 40;
            int Distance = 20;
            int start_x = 20;
            int start_y = 20;

            for (int x = 0; x < xg; x++)
            {                                   //Estos 2 fors controlan el tamaño del grid
                for (int y = 0; y < yg; y++)
                {
                    Button tmpButton = new Button();
                    tmpButton.Top = start_x + (x * ButtonHeight + Distance);
                    tmpButton.Left = start_y + (y * ButtonWidth + Distance);
                    tmpButton.Width = ButtonWidth;
                    tmpButton.Height = ButtonHeight;
                    tmpButton.Text = "?";
                    // Possible add Buttonclick event etc..
                    form.Controls.Add(tmpButton);
                }

            }
        }

>>>>>>> e66d1b526680641f4d27bde2158a82e8ad4ec8be
    }
}
