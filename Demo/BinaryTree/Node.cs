﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class Node
    {
        public int Value;
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int v)
        {
            Value = v;
        }
    }


}
