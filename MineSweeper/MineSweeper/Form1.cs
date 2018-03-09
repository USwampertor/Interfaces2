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
        GridManager grid;
        Database data;
        public bool gameStarted;
        List<TimeSpan> highscoreList;
        public Form1()
        {
            InitializeComponent();
            InitializeDynamicCompontent();
            gameStarted = false;
        }
        private void InitializeDynamicCompontent()
        {
            ///esto es de mientras

            Face = new Button();
            highscoreList = new List<TimeSpan>();

            Face.Enabled = false;
            Face.Size = new Size(41, 39);
            Face.BackgroundImage = Image.FromFile(@"Happy.png");
            Face.BackgroundImageLayout = ImageLayout.Stretch;
            Face.Location = new Point(((Width / 2) - (2*Face.Width/3)), (menuStrip1.Height));
            Face.AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowOnly;

            data = new Database();
            data.InputHandler();
            highscoreList = data.GetHighscores();

            time = new Timer();
            timeLabel = new Label();
            mineLabel = new Label();
            time.Interval = 100;
            timeinterval = new TimeSpan();
            timeLabel.Width = TextRenderer.MeasureText("00:00", timeLabel.Font).Width;
            mineLabel.Width = TextRenderer.MeasureText("0000", mineLabel.Font).Width;

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


            Controls.Add(Face);
        }

        void time_Tick(object sender, EventArgs e)
        {
            timeinterval = timeinterval.Add(TimeSpan.FromMilliseconds(100));
            timeLabel.Text = (timeinterval.Minutes + ":" + timeinterval.Seconds);
        }
        private void ResizeonNewGame(int width)
        {
            Cell a = new Cell();
            this.Width = (TextRenderer.MeasureText("  ", a.Font).Width) * gameWidth;
        }
        private void WindowResize(object sender, EventArgs e)
        {
            timeLabel.Location = new Point
                ((this.Width - timeLabel.Size.Width - 20), (menuStrip1.Height + 1));
            mineLabel.Location = new Point
                (5, (menuStrip1.Height + 1));
            Face.Location = new Point(((Width / 2) - (2 * Face.Width / 3)), (menuStrip1.Height));
            mineLabel.Text = totalMines.ToString();
        }
        

        new public void Closing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Estas seguro de que quieres salir?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                data.OutputHandler(highscoreList,timeinterval);
                e.Cancel = true;
            }

        }
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptions();

        }
        public void StopTime()
        {
            time.Stop();

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
                    timeinterval = new TimeSpan();
                    time.Start();
                   
                    if (!gameStarted)
                    {
                        grid = new GridManager(gameWidth, gameHeight, this, totalMines, Face);
                        gameStarted = true;
                    }
                    else
                    {
                        grid.clearBoard();
                        grid = new GridManager(gameWidth, gameHeight, this, totalMines, Face);
                    }
                    AutoSize = true;
                    Face.AutoSize = true;
                    AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    Face.Location = new Point((Width/2) - (Face.Size.Width/2), (menuStrip1.Height));
                    mineLabel.Text = totalMines.ToString();
                    timeLabel.Text="00:00";
                    


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

        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                (" 1.-"+highscoreList[0]+"\n 2.-" + highscoreList[1] + "\n 3.-" + highscoreList[2] + "\n 4.-"
                + highscoreList[3] + "\n 2.-" + highscoreList[4])
                , "Ayuda", MessageBoxButtons.OK);
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