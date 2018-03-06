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
        int gameWidth, gameHeight;
        TextBox h = new TextBox();
        TextBox w = new TextBox();

        public Form1()
        {
            InitializeComponent();
            InitializeDynamicCompontent();
        }
        private void InitializeDynamicCompontent()
        {
            ///esto es de mientras
            w.Location = new Point(this.Width / 3, 100);
            h.Location = new Point(2 * this.Width / 3, 100);

        }
        
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptions();
<<<<<<< HEAD
            
=======
            //Form1 NewForm = new Form1();

            //NewForm.Show();
            //this.Dispose(false);
            //GridManager grid = new GridManager();
            //grid.gridGenerator(gameWidth, gameHeight, this);
            MessageBox.Show("GO!");

>>>>>>> e66d1b526680641f4d27bde2158a82e8ad4ec8be
        }
        private void ShowOptions()
        {
            using (Options gameSize = new Options())
            {
<<<<<<< HEAD
                if (gameSize.ShowDialog() == DialogResult.OK)
                {
=======
                
                if (gameSize.ShowDialog() == DialogResult.OK)
                {
                    
>>>>>>> e66d1b526680641f4d27bde2158a82e8ad4ec8be
                    gameWidth = gameSize.sWidth;
                    gameHeight = gameSize.sHeight;
                    h.Text = gameHeight.ToString();
                    w.Text = gameWidth.ToString();
<<<<<<< HEAD
                    MessageBox.Show("GO!");
=======
                    gameSize.gridGenerator(gameWidth, gameHeight, this);
>>>>>>> e66d1b526680641f4d27bde2158a82e8ad4ec8be
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

<<<<<<< HEAD
=======
        private void buscaminasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

>>>>>>> e66d1b526680641f4d27bde2158a82e8ad4ec8be
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("En serio quieres salir?", "Salir", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
            
        }
    }
}
