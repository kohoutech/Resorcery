/* ----------------------------------------------------------------------------
Resourcery : an executable file resource editor 
Copyright (C) 1998-2017  George E Greaney

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

//-----------------------------------------------------------------------------

        public void openFile(String filename)
        {
            resorceryStatusLabel.Text = "Loading...";
            closeFile();
            res.loadSourceFile(filename);
            res.parseSource();
            res.parseResource();
            res.loadTreeView();

            Text = "Resourcery [" + filename + "]";
            resorceryStatusLabel.Text = "";
        }

        public void closeFile()
        {
            res.close();
        }

        private void showOpenFileDialog()
        {
            String filename = "";
            if (currentPath != null)
            {
                resorceryOpenFileDialog.InitialDirectory = currentPath;
            }
            else
            {
                resorceryOpenFileDialog.InitialDirectory = Application.StartupPath;
            }
            resorceryOpenFileDialog.FileName = "";
            resorceryOpenFileDialog.DefaultExt = "*.exe";
            resorceryOpenFileDialog.Filter = "Executable files|*.exe|DLL files|*.dll|All files|*.*";
            resorceryOpenFileDialog.ShowDialog();
            filename = resorceryOpenFileDialog.FileName;
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

//-----------------------------------------------------------------------------

        private void expandTreeResourceMenuItem_Click(object sender, EventArgs e)
        {
            resTreeView.ExpandAll();
        }

        private void collapseTreeResourceMenuItem_Click(object sender, EventArgs e)
        {
            resTreeView.CollapseAll();
        }

//-----------------------------------------------------------------------------

        private void aboutHelpMenuItem_Click(object sender, EventArgs e)
        {
            String msg = "Resourcery\nversion 1.0.1\n" + "\xA9 Origami Software 1998-2017\n" + "http://origami.kohoutech.com";
            MessageBox.Show(msg, "About");

        }
    }
}
