﻿/*
 *  Copyright (C) 2013 Pavel Charvat
 * 
 *  This file is part of IEDExplorer.
 *
 *  IEDExplorer is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  IEDExplorer is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with IEDExplorer.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEDExplorer
{
    public class NodeVL : NodeBase
    {
        public NodeVL(string Name)
            : base(Name)
        {
            Defined = false;
            Activated = false;
            Deletable = false;
        }

        public bool Deletable { get; set; }

        public bool Activated { get; set; }

        public bool Defined { get; set; }

        public EventHandler OnDefinedSuccess;
        public EventHandler OnDeleteSuccess;

        public NodeData urcb { get; set; }
    }
}
