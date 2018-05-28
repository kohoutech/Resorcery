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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Origami.Win32;

namespace Resourcery
{
    public class Resourcery
    {
        public ResWindow rwindow;
        public TreeView treeView;
        public Panel dataDisplay;
        public PictureBox pbox;                //for displaying images   

        public Win32Exe exeFile;
        public ResourceTable resources;        

        public Resourcery(ResWindow _rwindow)
        {
            rwindow = _rwindow;
            exeFile = null;
            resources = null;
            pbox = null;
        }

//- loading resource data -----------------------------------------------------

        public void openFile(String filename)
        {
            exeFile = new Win32Exe();
            exeFile.readFile(filename);
            resources = exeFile.resourceTable;
        }

        internal void parseData()
        {
            resources.parseData();   
        }

        public void closeFile()
        {
            exeFile = null;
            resources = null;
            treeView.Nodes.Clear();
            dataDisplay.Controls.Clear();
        }

//- loading resources -------------------------------------------------

        public void loadTreeNode(ResourceData item, TreeNode parent)
        {
            String name = (item.name != null) ? item.name : item.id.ToString();
            TreeNode nameNode = new TreeNode(name);
            parent.Nodes.Add(nameNode);
            List<uint> langs = item.getLanguageList();
            foreach (uint lang in langs)
            {
                ResTreeNode langnode = new ResTreeNode(lang.ToString(), item, lang);
                nameNode.Nodes.Add(langnode);
            }
        }

        public void loadTreeView()
        {
            TreeNode treeNode;
            if (resources.cursors.Count > 0)
            {
                treeNode = new TreeNode("Cursor");
                treeView.Nodes.Add(treeNode);
                foreach (ResCursor cur in resources.cursors)
                {
                    loadTreeNode(cur, treeNode);
                }
            }
            if (resources.bitmaps.Count > 0)
            {
                treeNode = new TreeNode("Bitmap");
                treeView.Nodes.Add(treeNode);
                foreach (ResBitmap bmp in resources.bitmaps)
                {
                    loadTreeNode(bmp, treeNode);
                }
            }
            if (resources.icons.Count > 0)
            {
                treeNode = new TreeNode("Icon");
                treeView.Nodes.Add(treeNode);
                foreach (ResIcon ico in resources.icons)
                {
                    loadTreeNode(ico, treeNode);
                }
            }
            if (resources.menus.Count > 0)
            {
                treeNode = new TreeNode("Menu");
                treeView.Nodes.Add(treeNode);
                foreach (ResMenu menu in resources.menus)
                {
                    loadTreeNode(menu, treeNode);
                }
            }
            if (resources.dialogs.Count > 0)
            {
                treeNode = new TreeNode("Dialog");
                treeView.Nodes.Add(treeNode);
                foreach (ResDialog dlg in resources.dialogs)
                {
                    loadTreeNode(dlg, treeNode);
                }
            }
            if (resources.stringtable.Count > 0)
            {
                treeNode = new TreeNode("String Table");
                treeView.Nodes.Add(treeNode);
                foreach (ResStringTable stbl in resources.stringtable)
                {
                    loadTreeNode(stbl, treeNode);
                }
            }
            if (resources.fontDirectories.Count > 0)
            {
                treeNode = new TreeNode("Font Directory");
                treeView.Nodes.Add(treeNode);
                foreach (ResFontDir fdir in resources.fontDirectories)
                {
                    loadTreeNode(fdir, treeNode);
                }
            }
            if (resources.fonts.Count > 0)
            {
                treeNode = new TreeNode("Font");
                treeView.Nodes.Add(treeNode);
                foreach (ResFont fnt in resources.fonts)
                {
                    loadTreeNode(fnt, treeNode);
                }
            }
            if (resources.accelerators.Count > 0)
            {
                treeNode = new TreeNode("Accelerator");
                treeView.Nodes.Add(treeNode);
                foreach (ResAccelerator acc in resources.accelerators)
                {
                    loadTreeNode(acc, treeNode);
                }
            }
            if (resources.cursorGroups.Count > 0)
            {
                treeNode = new TreeNode("Cursor Group");
                treeView.Nodes.Add(treeNode);
                foreach (ResCursorGroup cgrp in resources.cursorGroups)
                {
                    loadTreeNode(cgrp, treeNode);
                }
            }
            if (resources.iconGroups.Count > 0)
            {
                treeNode = new TreeNode("Icon Group");
                treeView.Nodes.Add(treeNode);
                foreach (ResIconGroup igrp in resources.iconGroups)
                {
                    loadTreeNode(igrp, treeNode);
                }
            }
            if (resources.versions.Count > 0)
            {
                treeNode = new TreeNode("Version");
                treeView.Nodes.Add(treeNode);
                foreach (ResVersion ver in resources.versions)
                {
                    loadTreeNode(ver, treeNode);
                }
            }
            if (resources.userData.Count > 0)
            {
                treeNode = new TreeNode("User Data");
                treeView.Nodes.Add(treeNode);
                foreach (ResUserData udata in resources.userData)
                {
                    loadTreeNode(udata, treeNode);
                }
            }
            treeView.MouseDoubleClick += new MouseEventHandler(treeView_MouseDoubleClick);
        }

//- handling events -----------------------------------------------------------

        private void treeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode node = treeView.SelectedNode;
            if (node is ResTreeNode)
            {
                ResTreeNode resNode = (ResTreeNode)node;
                ResourceData dataNode = resNode.dataNode;
                ResourceItem itemNode = dataNode.getItem(resNode.lang);
                pbox = null;
                if (dataNode is ResStringTable)
                {
                    displayStringTable(itemNode);
                }
                else if (dataNode is ResBitmap) 
                {
                    displayBitmap(itemNode);
                }
                else if (dataNode is ResAccelerator)
                {
                    displayAccelerator(itemNode);
                }
                else
                {
                displayRawData(itemNode);
                }
            }
        }

//- displaying data -----------------------------------------------------------

        private TextBox setDisplayToText()
        {
            dataDisplay.Controls.Clear();

            TextBox dataText = new TextBox();
            dataText.Dock = DockStyle.Fill;
            dataText.Font = new Font("Courier New", 10.0f);
            dataText.BackColor = Color.PowderBlue;
            dataText.Multiline = true;
            dataText.WordWrap = false;
            dataText.ScrollBars = ScrollBars.Both;
            dataText.ShortcutsEnabled = true;
            dataDisplay.Controls.Add(dataText);
            return dataText;
        }

        private void displayRawData(ResourceItem node)
        {
            TextBox dataText = setDisplayToText();
            byte[] data = node.dataBuf;

            StringBuilder info = new StringBuilder();           //the entire text
            StringBuilder ascii = new StringBuilder();          //the ascii chars at the end of each line
            int i = 0;

            //the same code we use for displaying raw data in all these DecoderRing apps!
            for (; i < data.Length; )
            {
                if (i % 16 == 0)
                {
                    info.Append(i.ToString("X8") + ": ");         //address at start of each line
                }
                byte b = data[i];
                info.Append(b.ToString("X2"));
                info.Append(" ");
                ascii.Append((b >= 0x20 && b <= 0x7E) ? ((char)b).ToString() : ".");
                i++;
                if (i % 16 == 0)
                {
                    info.AppendLine(ascii.ToString());              //add ascii chars to end of line
                    ascii.Clear();
                }
            }
            if (i % 16 != 0)
            {
                int remainder = (i % 16);
                for (; remainder < 16; remainder++)
                {
                    info.Append("   ");

                }
                info.AppendLine(ascii.ToString());
            }
            dataText.Text = info.ToString();
        }

        void displayBitmap(ResourceItem item)
        {
            dataDisplay.Controls.Clear();
            pbox = new PictureBox();
            Bitmap bmp = (Bitmap)item.item;
            pbox.Image = bmp;
            pbox.Width = bmp.Width;
            pbox.Height = bmp.Height;
            int x = (dataDisplay.Width - pbox.Width) / 2;
            int y = (dataDisplay.Height - pbox.Height) / 2;
            x = (x > 0) ? x : 0;
            y = (y > 0) ? y : 0;
            pbox.Location = new Point(x, y);

            dataDisplay.Controls.Add(pbox);
        }

        void displayStringTable(ResourceItem item) 
        {
            TextBox dataText = setDisplayToText();
            ResStringTable parent = (ResStringTable)item.parent;
            int i = parent.bundleNum;
            List<String> strtbl = (List<String>)item.item;
            foreach (String str in strtbl)
            {
                dataText.Text += (i.ToString("X4") + " : " + str);
                dataText.Text += "\r\n";
                i++;
            }
        }

        void displayAccelerator(ResourceItem item)
        {
            TextBox dataText = setDisplayToText();
            List<String> strtbl = (List<String>)item.item;
            foreach (String str in strtbl)
            {
                dataText.Text += str;
                dataText.Text += "\r\n";
            }
        }

    }

//-----------------------------------------------------------------------------

    //the leaf nodes of the resource directory tree on the left side
    public class ResTreeNode : TreeNode
    {
        public uint lang;
        public ResourceData dataNode;

        public ResTreeNode(String name, ResourceData _node, uint _lang)
            : base(name)
        {
            lang = _lang;
            dataNode = _node;
        }
    }
}

//Console.WriteLine("there's no sun in the shadow of the wizard");