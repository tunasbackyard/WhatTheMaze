using System;
using System.IO;

namespace WhatTheMaze
{
    static class MazeSolver
    {
        private static List<Block> visited = new List<Block>();
        private static List<Block> pathToExit = new List<Block>();
        public static bool solve(Block current, int printType)
        {
            if (isExit(current))
            {
                pathToExit.Add(current);
                return true;
            }
            getSurroundings(current);
            Grid.matrix[current.row, current.col] = 2;
            Grid.print();
            Console.Clear();
            foreach (var item in current.surroundings)
            {
                if (isValidBlock(item))
                {
                    visited.Add(current);
                    bool isFound = solve(item, printType);

                    if (isFound)
                    {
                        pathToExit.Add(current);
                        Grid.matrix[current.row, current.col] = 3;
                        return true;
                    }
                }
            }
            return false;
        }
        public static void setCorrectPath()
        {
            foreach (var item in pathToExit)
                Grid.matrix[item.row, item.col] = 3;
        }
        private static bool isValidBlock(Block block)
        {
            return getBlockType(block) == 0 && !isVisited(block);
        }
        private static void getSurroundings(Block current)
        {
            if (!(current.row - 1 < 0))
            {
                Block up = new Block(current.row - 1, current.col);
                current.surroundings.Add(up);
            }
            if (!(current.col - 1 < 0))
            {
                Block left = new Block(current.row, current.col - 1);
                current.surroundings.Add(left);
            }
            if (!(current.row + 1 >= 30))
            {
                Block down = new Block(current.row + 1, current.col);
                current.surroundings.Add(down);
            }
            if (!(current.col + 1 >= 30))
            {
                Block right = new Block(current.row, current.col + 1);
                current.surroundings.Add(right);
            }
        }
        private static int getBlockType(Block block)
        {
            return Grid.matrix[block.row, block.col];
        }
        private static bool isVisited(Block block)
        {
            foreach (var item in visited)
                if (item.row == block.row && item.col == block.col)
                    return true;
            return false;
        }
        private static bool isExit(Block block)
        {
            foreach (var exit in Grid.exitpoints)
                if (block.row == exit.row && block.col == exit.col)
                    return true;
            return false;
        }
    }
}
