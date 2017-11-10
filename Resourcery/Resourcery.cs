﻿/* ----------------------------------------------------------------------------
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

using Origami.Win32;

namespace Resourcery
{
    public class Resourcery
    {
        public ResWindow rwindow;
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

    }
}
