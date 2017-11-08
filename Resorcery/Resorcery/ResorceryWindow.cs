using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Resorcery
{
    public partial class ResorceryWindow : Form
    {
        public ResorceryWindow()
        {
            InitializeComponent();
        }

//-----------------------------------------------------------------------------

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitFileMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

//-----------------------------------------------------------------------------

        private void expandTreeResourceMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void collapseTreeResourceMenuItem_Click(object sender, EventArgs e)
        {

        }

//-----------------------------------------------------------------------------

        private void aboutHelpMenuItem_Click(object sender, EventArgs e)
        {
            String msg = "Resorcery\nversion 1.0.0\n" + "\xA9 Origami Software 1998-2017\n" + "http://origami.kohoutech.com";
            MessageBox.Show(msg, "About");

        }
    }
}
