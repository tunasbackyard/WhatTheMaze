using System;
using System.IO;
using System.Threading;

namespace WhatTheMaze
{
    static class Grid
    {
        public static int[,] matrix = new int[30, 30];
        public static List<Block> entrypoints = new List<Block>();
        public static List<Block> exitpoints = new List<Block>();
        public static void print()
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {

                    if (matrix[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("# ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (matrix[i, j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("+ ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        if (matrix[i, j] != 0 && matrix[i, j] != 1)
                            Console.Write("0 ");
                        else
                            Console.Write($"{matrix[i, j]} ");
                    }

                }
                Console.Write("\n");
            }
            Thread.Sleep(50);
        }
        public static void initializeTheMaze()
        {
            getEntryPoints();
            getExitPoints();
        }
        private static void getEntryPoints()
        {
            for (int i = 0; i < 30; i++)
            {
                if (matrix[i, 0] == 0)
                {
                    Block entrypoint = new Block(i, 0);
                    entrypoints.Add(entrypoint);
                }

            }
        }
        private static void getExitPoints()
        {
            for (int i = 0; i < 30; i++)
            {
                if (matrix[i, 29] == 0)
                {
                    Block exitpoint = new Block(i, 29);
                    exitpoints.Add(exitpoint);
                }

            }
        }
    }
}
