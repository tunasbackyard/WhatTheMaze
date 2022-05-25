using System;
using System.IO;

namespace WhatTheMaze
{
    class Program
    {
        public static string greeting = @"
    $$\      $$\ $$\                  $$\  $$$$$$$$\ $$\                 $$\      $$\                               
    $$ | $\  $$ |$$ |                 $$ | \__$$  __|$$ |                $$$\    $$$ |                              
    $$ |$$$\ $$ |$$$$$$$\   $$$$$$\ $$$$$$\   $$ |   $$$$$$$\   $$$$$$\  $$$$\  $$$$ | $$$$$$\  $$$$$$$$\  $$$$$$\  
    $$ $$ $$\$$ |$$  __$$\  \____$$\\_$$  _|  $$ |   $$  __$$\ $$  __$$\ $$\$$\$$ $$ | \____$$\ \____$$  |$$  __$$\ 
    $$$$  _$$$$ |$$ |  $$ | $$$$$$$ | $$ |    $$ |   $$ |  $$ |$$$$$$$$ |$$ \$$$  $$ | $$$$$$$ |  $$$$ _/ $$$$$$$$ |
    $$$  / \$$$ |$$ |  $$ |$$  __$$ | $$ |$$\ $$ |   $$ |  $$ |$$   ____|$$ |\$  /$$ |$$  __$$ | $$  _/   $$   ____|
    $$  /   \$$ |$$ |  $$ |\$$$$$$$ | \$$$$  |$$ |   $$ |  $$ |\$$$$$$$\ $$ | \_/ $$ |\$$$$$$$ |$$$$$$$$\ \$$$$$$$\ 
    \__/     \__|\__|  \__| \_______|  \____/ \__|   \__|  \__| \_______|\__|     \__| \_______|\________| \_______|
                       
            ";
        public static string userInput;
        static void Main()
        {
            printMainPage();
            while (true)
            {
                try
                {
                    string path = getFilePath();
                    Console.WriteLine(path);
                    Grid.matrix = createMatrix(filterInput(path));
                    Grid.initializeTheMaze();
                    solveForEachEntrypoint();
                    Grid.print();
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(1000);
                }
                printMainPage();
            }
        }
        public static string getUserInput()
        {
            Console.Write("$: ");
            return Console.ReadLine();
        }
        public static string getFilePath()
        {
            Console.WriteLine(@"[*] Give a file path 'C:\example\maze.txt'");
            return getUserInput();
        }
        public static List<int> filterInput(string filepath)
        {
            List<int> clearedInputs = new List<int>();
            List<string> lines = File.ReadAllLines(filepath).ToList();
            foreach (string line in lines)
            {
                string[] separator = { "{", "}", "," };
                string[] parts = line.Split(separator, StringSplitOptions.None);

                foreach (string part in parts)
                {
                    int value;
                    if (int.TryParse(part, out value))
                        clearedInputs.Add(value);
                }
            }
            return clearedInputs;
        }
        public static int[,] createMatrix(List<int> list)
        {
            int[,] matrix = new int[30, 30];
            for (int i = 0; i < 30; i++)
                for (int j = 0; j < 30; j++)
                    matrix[i, j] = list[i * 30 + j];
            return matrix;
        }
        public static void printMainPage()
        {
            Console.Clear();
            Console.WriteLine(greeting);
        }
        public static void solveForEachEntrypoint()
        {
            foreach (var entry in Grid.entrypoints)
            {
                if (MazeSolver.solve(entry, 3))
                {
                    MazeSolver.setCorrectPath();
                    return;
                }
            }
        }
    }
}