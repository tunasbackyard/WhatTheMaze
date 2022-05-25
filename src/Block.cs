using System;
using System.IO;

namespace WhatTheMaze
{
    class Block
    {
        public Block(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
        public int row;
        public int col;
        public List<Block> surroundings = new();
    }
}
