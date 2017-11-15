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
    public partial class DebugMenu : Form
    {
        public DebugMenu()
        {
            InitializeComponent();
        }

        public void UpdateDebugText(string text)
        {
            textBoxDebug.AppendText($"{text}\n");
        }

        private void buttonClearTextArea_Click(object sender, EventArgs e)
        {
            textBoxDebug.Text = "";
        }
    }
}
