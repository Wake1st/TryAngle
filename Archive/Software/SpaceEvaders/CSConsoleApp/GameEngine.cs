using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConsoleApp
{
    public class GameEngine
    {
        public int BoardHeight = 50;
        public int BoardWidth = 200;

        string[,] Board;

        public List<VisualElement> VisualElements { get; set; } = new List<VisualElement>();

        public GameEngine()
        {
            //  Setup initial properties
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(BoardWidth, BoardHeight + 1);
            Console.SetBufferSize(BoardWidth, BoardHeight + 1);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            //  Set clear space for final layer
            //VisualElements.Add(new VisualElement(BoardWidth, BoardHeight, 0, 0, Byte.MaxValue, 160));
        }

        public void LoadVisualElement(string name, string[] visualElement, int left, int top, int layer)
        {
            VisualElements.Add(new VisualElement(name, visualElement, left, top, layer));
        }

        public void Run()
        {
            while (true)
            {
                //  Clear the console
                Console.Clear();

                //  Show the player the game board
                Render();

                //  Take user input
                Console.Write("> ");
                var input = Console.ReadLine().ToLower().Replace('>', ' ').Trim();

                //  First check for quit command
                if (input == "q" || input == "quit") break;

                //  breakdown the input into an array of commands and arguments
                var commands = input.Split(' ');

                //  Check for move command
                if (commands[0] == "move")
                {
                    //  Move the ship based on X and Y coordinates
                    if (commands.Length < 3)
                    {
                        Console.WriteLine("Please ensure your move command includes arguments for X and Y coordindates");
                    }
                    else
                    {
                        var ship = VisualElements.FirstOrDefault(e => e.Name == "ship");
                        ship.Left += int.Parse(commands[1]);
                        ship.Top += int.Parse(commands[2]);
                    }
                }
            }
        }

        void Render()
        {
            //  Create the board
            Board = new string[BoardWidth, BoardHeight];
            
            for (int j = 0; j < BoardHeight; j++)
            {
                for (int i = 0; i < BoardWidth; i++)
                {
                    Board[i, j] =  " ";
                }
            }

            //  Order the elements by layer
            VisualElements = VisualElements.OrderByDescending(v => v.Layer).ToList();

            //  Construct the board
            string b;
            foreach (var e in VisualElements)
            {
                for (int j = 0; j < e.Shape.Count; j++)
                {
                    for (int i = 0; i < e.Shape[j].Length; i++)
                    {
                        b = e.Shape[j][i].ToString();
                        Board[i+e.Left, j+e.Top] = (b == " ") ? Board[i + e.Left, j + e.Top] : b;
                    }
                }
            }

            //  Display the final board
            for (int j = 0; j < BoardHeight; j++)
            {
                for (int i = 0; i < BoardWidth; i++)
                {
                    Console.Write(Board[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
