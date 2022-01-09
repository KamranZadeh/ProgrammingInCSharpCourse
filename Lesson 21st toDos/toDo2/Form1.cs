using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toDo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCatch_MouseEnter(object sender, EventArgs e)
        {
            Random rnd = new();
            buttonCatch.Location = new Point(rnd.Next(0, maxWidth), rnd.Next(0, maxHeight));
        }

        public int maxWidth = 700;
        public int maxHeight = 400;

        private void Form1_Resize(object sender, EventArgs e)
        {
            maxWidth = this.Size.Width - 50;
            maxHeight = this.Size.Height - 50;
        }

        private void buttonCatch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Congratsss! You nailed it! :)");
        }
    }
}
