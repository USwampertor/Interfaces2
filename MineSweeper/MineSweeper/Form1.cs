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
        public Label timeLabel, mineLabel;

        public Form1()
        {
            InitializeComponent();
            InitializeDynamicCompontent();
        }
        private void InitializeDynamicCompontent()
        {
            ///esto es de mientras
            time = new Timer();
            timeLabel = new Label();
            mineLabel = new Label();
            time.Interval = 100;
            timeinterval = new TimeSpan();
            timeLabel.Width = TextRenderer.MeasureText("00:00",timeLabel.Font).Width;
            mineLabel.Width = TextRenderer.MeasureText("0000",mineLabel.Font).Width;

            mineLabel.BackColor = Color.Black;
            mineLabel.ForeColor = Color.GreenYellow;
            timeLabel.BackColor = Color.Black;
            timeLabel.ForeColor = Color.GreenYellow;
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            mineLabel.TextAlign = ContentAlignment.MiddleCenter;

            timeLabel.Location = new Point
                ((this.Width - timeLabel.Size.Width - 20), (menuStrip1.Height + 1));
            mineLabel.Location = new Point
                (5, (menuStrip1.Height + 1));

            time.Tick += new EventHandler(time_Tick);
            this.FormClosing += new FormClosingEventHandler(Closing);
            this.SizeChanged += new EventHandler(WindowResize);


            Controls.Add(mineLabel);
            Controls.Add(timeLabel);
        }
        private void WindowResize(object sender, EventArgs e)
        {
            timeLabel.Location = new Point
                ((this.Width - timeLabel.Size.Width - 20), (menuStrip1.Height + 1));
            mineLabel.Location = new Point
                (5, (menuStrip1.Height + 1));
        }
        void time_Tick(object sender, EventArgs e)
        {
            timeinterval = timeinterval.Add(TimeSpan.FromMilliseconds(100));
            timeLabel.Text = (timeinterval.Minutes+":"+timeinterval.Seconds);
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
                if (gameSize.ShowDialog() == DialogResult.OK)
                {
                    gameWidth = gameSize.sWidth;
                    gameHeight = gameSize.sHeight;
                    totalMines = gameSize.sMines;
                    mineLabel.Text = totalMines.ToString();
                    time.Start();
                   
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("There's no help here Boi", "Ayuda",MessageBoxButtons.OK);
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
