using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        Life game;
        int rows, cols;

        public static int saveBufferWidth;
        public static int saveBufferHeight;
        public static int saveWindowHeight;
        public static int saveWindowWidth;
        public static bool saveCursorVisible;

        ConsoleKeyInfo cki;

        Cell[,] startingBoard;

        public Program(string[] args)
        {
            if (args.Length == 0)
            {
                Random rand = new Random();
                rows = 40;
                cols = 40;

                startingBoard = new Cell[rows, cols];

                for(int i = 0; i < rows; i++)
                {
                    for(int j = 0; j < cols; j++)
                    {
                        if(rand.Next(0, 2) == 0)
                        {
                            startingBoard[i, j] = new Cell(true, i, j);
                        }
                        else
                        {
                            startingBoard[i, j] = new Cell(false, i, j);
                        }
                        
                    }
                }

                game = new Life(rows, cols, startingBoard);
            }
            setupConsole();
            //while (true) ;
            run();
            resetConsole();
        }

        public void setupConsole()
        {
            saveBufferWidth = Console.BufferWidth;
            saveBufferHeight = Console.BufferHeight;
            saveWindowHeight = Console.WindowHeight;
            saveWindowWidth = Console.WindowWidth;
            saveCursorVisible = Console.CursorVisible;

            Console.Clear();
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(cols*2, rows);
            Console.SetWindowSize(cols*2, rows);
            Console.CursorVisible = false;
        }
        public void resetConsole()
        {
            Console.Clear();
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(saveBufferWidth, saveBufferHeight);
            Console.SetWindowSize(saveWindowWidth, saveWindowHeight);
            Console.CursorVisible = saveCursorVisible;
        }

        public void run()
        {
            while (true)
            {
                for(int i = 0; i < rows; i++)
                {
                    StringBuilder dispString = new StringBuilder();
                    for(int j = 0; j < cols; j++)
                    {
                        dispString.Append(game.board[i, j].ToString());
                        dispString.Append(" ");
                    }
                    Console.SetCursorPosition(0, i);
                    Console.Write(dispString.ToString());
                }

                cki = Console.ReadKey(true);
                while (cki.Key != ConsoleKey.Spacebar) ;
                game.updateBoard();
            }
        }

        static void Main(string[] args)
        {
            new Program(args);
        }
    }
}
