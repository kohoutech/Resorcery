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

        public SourceFile source;
        public Win32Decoder decoder;
        public Section resources;
        public ResourceParser resParser;

        public Resourcery(ResWindow _rwindow)
        {
            rwindow = _rwindow;

            source = null;
            decoder = null;
            resources = null;
            resParser = null;
        }

        public void loadSourceFile(String filename)
        {
            source = new SourceFile(filename);      //read in file            
        }

        public void close()
        {
            source = null;
            decoder = null;
            resources = null;
            resParser = null;
            treeView.Nodes.Clear();
            dataDisplay.Controls.Clear();
        }

        public void parseSource()
        {
            decoder = new Win32Decoder(source);     //other exe types could have diff decoders at this point
            decoder.parse();                        //parse exe headers + section table
            resources = decoder.resources;          //convenience ref
        }

        public void parseResource()
        {
            resParser = new ResourceParser(source, resources);
            resParser.parse();
        }

//-----------------------------------------------------------------------------

        public void loadTreeNode(List<ResourceNode> nodes, TreeNode parent)
        {
            foreach (ResourceNode node in nodes)
            {
                String name = (node.id == -1) ? node.name : node.id.ToString();
                if (node is ResourceDirectory)
                {
                    TreeNode treeNode = new TreeNode(name);
                    parent.Nodes.Add(treeNode);
                    List<ResourceNode> children = ((ResourceDirectory)node).entries;
                    loadTreeNode(children, treeNode);
                }
                else
                {
                    ResourceData dataNode = (ResourceData)node;
                    ResTreeNode resNode = new ResTreeNode(name, dataNode);
                    parent.Nodes.Add(resNode);
                }
            }
        }

        public void loadTreeView()
        {
            int i = 1;
            foreach (ResourceNode node in ((ResourceDirectory)resParser.rootNode).entries) {
                TreeNode treeNode = new TreeNode(resParser.getNodeType(node.id));
                treeView.Nodes.Add(treeNode);
                loadTreeNode(((ResourceDirectory)node).entries, treeNode);
            }
            treeView.MouseDoubleClick += new MouseEventHandler(treeView_MouseDoubleClick);
        }

        void treeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode node = treeView.SelectedNode;
            if (node is ResTreeNode)
            {
                ResourceData dataNode = ((ResTreeNode)node).dataNode;
                if (dataNode is StringTableEntry)
                {
                    displayStringTable((StringTableEntry)dataNode);
                }
                else if (dataNode is BitmapEntry)
                {
                    displayBitmap((BitmapEntry)dataNode);
                }
                else
                {
                    displayRawData(dataNode);
                }
            }
        }

        TextBox setDisplayToText()
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

        void displayRawData(ResourceData node)
        {
            TextBox dataText = setDisplayToText();
            byte[] data = node.dataBuf;

            StringBuilder info = new StringBuilder();           //the entire text
            StringBuilder ascii = new StringBuilder();          //the ascii chars at the end of each line
            int i = 0;

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

        void displayBitmap(BitmapEntry bitmapEntry)
        {
            dataDisplay.Controls.Clear();
            PictureBox pbox = new PictureBox();
            pbox.Image = bitmapEntry.bitmap;
            pbox.Width = bitmapEntry.bitmap.Width;
            pbox.Height = bitmapEntry.bitmap.Height;
            //pbox.Location = new Point(50, 50);

            dataDisplay.Controls.Add(pbox);
        }

        void displayStringTable(StringTableEntry strtbl) 
        {
            TextBox dataText = setDisplayToText();
            int i = strtbl.bundleNum;
            foreach (String str in strtbl.strings)
            {
                dataText.Text += (i.ToString("X4") + " : " + str);
                dataText.Text += "\r\n";
                i++;
            }
        }
    }

//-----------------------------------------------------------------------------

    public class ResTreeNode : TreeNode
    {
        public ResourceData dataNode;

        public ResTreeNode(String name, ResourceData _node)
            : base(name)
        {
            dataNode = _node;
        }
    }
}
