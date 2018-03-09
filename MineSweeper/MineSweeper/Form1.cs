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
    public partial class Form1 : Form
    {
        private Timer time;
        private TimeSpan timeinterval;
        int gameWidth, gameHeight, totalMines;
        public Label timeLabel;

        public Form1()
        {
            InitializeComponent();
            InitializeDynamicCompontent();
            
        }
        private void InitializeDynamicCompontent()
        {
            ///esto es de mientras
            time = new Timer();
            Face = new Button();
            timeLabel = new Label();

            Face.Enabled = false;
            Face.Size = new Size(41, 39);
            Face.BackgroundImage = Image.FromFile(@"Happy.png");
            Face.BackgroundImageLayout = ImageLayout.Stretch;
            Face.Location = new Point((Width / 2) - (Face.Width / 2), (menuStrip1.Height));
            Face.AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowOnly;
           

            time.Interval = 100;
            timeinterval = new TimeSpan();
            string a = "0000";
            timeLabel.BackColor = Color.Black;
            timeLabel.ForeColor = Color.GreenYellow;
            timeLabel.Width = TextRenderer.MeasureText(a,timeLabel.Font).Width;
            //timeLabel.Anchor = (AnchorStyles.Right);
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            timeLabel.Location = new Point((Width) - (timeLabel.Width / 2), (menuStrip1.Height));



            time.Tick += new EventHandler(time_Tick);
            this.FormClosing += new FormClosingEventHandler(Closing);

            //Controls.Add(timeLabel);
            //Controls.Add(Face);
        }

        void time_Tick(object sender, EventArgs e)
        {
            timeinterval = timeinterval.Add(TimeSpan.FromMilliseconds(100));
            timeLabel.Text = (timeinterval.Minutes + ":" + timeinterval.Seconds);
        }

        new public void Closing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Estas seguro de que quieres salir?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }



        }
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptions();

        }
        private void ShowOptions()
        {
            using (Options gameSize = new Options())
            {
                int buttonsToButton;

                if (gameSize.ShowDialog() == DialogResult.OK)
                {
                    gameWidth = gameSize.sWidth;
                    gameHeight = gameSize.sHeight;
                    buttonsToButton = gameWidth * gameHeight;
                    totalMines = gameSize.sMines;
                    time.Start();
                    GridManager grid = new GridManager(gameWidth, gameHeight, this, totalMines, Face);
                    AutoSize = true;
                    AutoSizeMode = AutoSizeMode.GrowAndShrink;

                    Face.AutoSize = true;
                    AutoSizeMode = AutoSizeMode.GrowOnly;
                    Face.Location = new Point((Width/2) - (Face.Width/2), (menuStrip1.Height));
                   
                    
                    timeLabel.Location = new Point((Width) - (timeLabel.Width), (menuStrip1.Height));

                    Controls.Add(timeLabel);
                    Controls.Add(Face);

                    //grid.mineGenerator(this, buttonsToButton);
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("There's no help here Boi", "Ayuda", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void créditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                ("Proyecto IDV Interfaces \n Segundo parcial\n \n \n -Alberto Villano \n -Marco Millan \n -Ivan Preciado"),
                "Ayuda", MessageBoxButtons.OK);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}