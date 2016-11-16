using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDosAnimaisWF
{
    public partial class Form1 : Form
    {
        BinaryTree bt;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string rootQuestion = "O animal que você pensou vive na água?";

            bt = new BinaryTree(rootQuestion, "Tubarão", "Macaco");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startNewGame();
        }

        private void startNewGame()
        {            
            bt.query();
        }
    }
}
