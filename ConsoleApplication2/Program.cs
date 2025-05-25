using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Policy;

namespace ConsoleApplication2
{
    public class Sudoku
    {
        private int[,] board =
        {
            { 9, 8, 7, 6, 5, 4, 3, 2, 0 },
            { 2, 4, 6, 1, 7, 3, 9, 8, 5 },
            { 3, 5, 1, 9, 2, 8, 7, 4, 6 },
            { 1, 2, 8, 5, 3, 7, 6, 9, 4 },
            { 6, 3, 4, 8, 9, 2, 1, 5, 7 },
            { 7, 9, 5, 4, 6, 1, 8, 3, 2 },
            { 5, 1, 9, 2, 8, 6, 4, 7, 3 },
            { 4, 7, 2, 3, 1, 9, 5, 6, 8 },
            { 8, 6, 3, 7, 4, 5, 2, 1, 9 }
        };

        int mouseX = 0;
        int mouseY = 0;

        public void SetPosition(int x, int y)
        {
            if (x >= 0 && x <= 8)
            {
                this.mouseX = x;
            }

            if (y >= 0 && y <= 8)
            {
                this.mouseY = y;
            }
        }

        public int GetX()
        {
            return this.mouseX;
        }
        public int GetY()
        {
            return this.mouseY;
        }
        


        public bool IsValid()
        {
            for (int num = 1; num <= 9; num++)
            {
                for (int i = 0; i < 9; i++)

                {
                    int count = 0;
                    int count2 = 0;

                    for (int j = 0; j < 9; j++)
                    {
                        if (this.board[i, j] == num)
                        {
                            count++;

                        }

                        if (this.board[j, i] == num)
                        {
                            count2++;
                        }
                    }

                    if (count != 1 || count2 != 1)

                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void PrintBoard()
        {
            for (int row = 0; row < 9; ++row)
            {
                if (row % 3 == 0 && row != 0)
                    Console.WriteLine("------+-------+------");

                for (int col = 0; col < 9; ++col)
                {
                    if (col % 3 == 0 && col != 0)
                        Console.Write("| ");

                    int value = board[row, col];
                    if (this.mouseX == col && this.mouseY == row)
                    {
                        Console.Write(value == 0 ? "\u2b1c\ufe0f<" : value + "<");
                    }
                    else { Console.Write(value == 0 ? "\u2b1c\ufe0f " : value + " ");}
                }

                Console.WriteLine();
            }
        }

        public void SetValue(int z)
        {
            this.board[this.mouseY, this.mouseX] = z;
        }
    }
    
    
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Sudoku sudoku = new Sudoku();
            while (sudoku.IsValid() != true)
            {
                
                sudoku.PrintBoard();
                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        sudoku.SetPosition(sudoku.GetX(), sudoku.GetY()-1);
                        break;
                    case ConsoleKey.DownArrow:
                        sudoku.SetPosition(sudoku.GetX(), sudoku.GetY()+1);
                        break;
                    case ConsoleKey.LeftArrow:
                        sudoku.SetPosition(sudoku.GetX()-1, sudoku.GetY());
                        break;
                    case ConsoleKey.RightArrow:
                       sudoku.SetPosition(sudoku.GetX()+1, sudoku.GetY());
                        break;
                    
                    case ConsoleKey.D0:
                        sudoku.SetValue(0);
                        break;
                    case ConsoleKey.D1:
                        sudoku.SetValue(1);
                        break;
                    case ConsoleKey.D2:
                        sudoku.SetValue(2);
                        break;
                    case ConsoleKey.D3:
                        sudoku.SetValue(3);
                        break;
                    case ConsoleKey.D4:
                        sudoku.SetValue(4);
                        break;
                    case ConsoleKey.D5:
                        sudoku.SetValue(5);
                        break;
                    case ConsoleKey.D6:
                        sudoku.SetValue(6);
                        break;
                    case ConsoleKey.D7:
                        sudoku.SetValue(7);
                        break;
                    case ConsoleKey.D8:
                        sudoku.SetValue(8);
                        break;
                    case ConsoleKey.D9:
                        sudoku.SetValue(9);
                        break;
                }
                Console.Clear();
                

            }
            Console.WriteLine("ты победил");
        }
    }
}

