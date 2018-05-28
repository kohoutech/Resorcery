/* ----------------------------------------------------------------------------
Resourcery : an executable file resource editor 
Copyright (C) 1998-2018  George E Greaney

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
----------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Resourcery
{
    public partial class ResWindow : Form
    {
        public Resourcery res;
        String currentPath;

        public ResWindow()
        {
            res = new Resourcery(this);

            InitializeComponent();
            res.treeView = resTreeView;
            res.dataDisplay = resDataDisplay;
            
            currentPath = null;
        }

        private void resDataDisplay_Resize(object sender, EventArgs e)
        {
            if (res.pbox != null)       //keep any images being displayed centered in the data window
            {
                int x = (resDataDisplay.Width - res.pbox.Width) / 2;
                int y = (resDataDisplay.Height - res.pbox.Height) / 2;
                x = (x > 0) ? x : 0;
                y = (y > 0) ? y : 0;
                res.pbox.Location = new Point(x, y);
            }
        }

//- file menu -----------------------------------------------------------------

        public void openFile(String filename)
        {
            resorceryStatusLabel.Text = "Loading...";
            closeFile();
            res.openFile(filename);
            res.parseData();
            res.loadTreeView();

            this.Text = "Resourcery [" + filename + "]";
            resorceryStatusLabel.Text = "";
        }

        public void closeFile()
        {
            res.closeFile();
        }

        private void showOpenFileDialog()
        {
            String filename = "";
            //if (currentPath != null)
            //{
            //    resorceryOpenFileDialog.InitialDirectory = currentPath;
            //}
            //else
            //{
            //    resorceryOpenFileDialog.InitialDirectory = Application.StartupPath;
            //}
            //resorceryOpenFileDialog.FileName = "";
            //resorceryOpenFileDialog.DefaultExt = "*.exe";
            //resorceryOpenFileDialog.Filter = "Executable files|*.exe|DLL files|*.dll|All files|*.*";
            //resorceryOpenFileDialog.ShowDialog();
            //filename = resorceryOpenFileDialog.FileName;
            filename = "test.exe";
            if (filename.Length != 0)
            {
                currentPath = Path.GetDirectoryName(filename);
                openFile(filename);
            }
        }

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            showOpenFileDialog();
        }

        private void closeFileMenuItem_Click(object sender, EventArgs e)
        {
            closeFile();
        }

        private void exitFileMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

//- resource menu -------------------------------------------------------------

        private void expandTreeResourceMenuItem_Click(object sender, EventArgs e)
        {
            resTreeView.ExpandAll();
        }

        private void collapseTreeResourceMenuItem_Click(object sender, EventArgs e)
        {
            resTreeView.CollapseAll();
        }

//- help menu -----------------------------------------------------------------

        private void aboutHelpMenuItem_Click(object sender, EventArgs e)
        {
            String msg = "Resourcery\nversion 1.1.0\n" + "\xA9 Origami Software 1998-2018\n" + "http://origami.kohoutech.com";
            MessageBox.Show(msg, "About");

        }
    }
}

//Console.WriteLine("there's no sun in the shadow of the wizard");