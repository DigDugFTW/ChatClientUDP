using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClientUDP
{
    public partial class Form1 : Form
    {
        ConnectionMenu connectionMenu = new ConnectionMenu();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSend_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectionMenu.ShowDialog();
        }

        private void connectionDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Opens settings menu (data capping / throttling / notifications / encryption (maybe server side though) / appearance (Theme..)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void preferencedToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
