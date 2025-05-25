using System;
using System.Configuration;
using System.Data;
using System.Linq;
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
            { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
            { 2, 4, 6, 1, 7, 3, 9, 8, 5 },
            { 3, 5, 1, 9, 2, 8, 7, 4, 6 },
            { 1, 2, 8, 5, 3, 7, 6, 9, 4 },
            { 6, 3, 4, 8, 9, 2, 1, 5, 7 },
            { 7, 9, 5, 4, 6, 1, 8, 3, 2 },
            { 5, 1, 9, 2, 8, 6, 4, 7, 3 },
            { 4, 7, 2, 3, 1, 9, 5, 6, 8 },
            { 8, 6, 3, 7, 4, 5, 2, 1, 9 }
        };

        public void SetValue(int row, int col, int value)
        {
            board[row, col] = value;
        }

        public int GetValue(int row, int col)
        {
            return board[row, col];
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
                    Console.Write(value == 0 ? ". " : value + " ");
                }
               Console.WriteLine();
            }
        }

    public class Program
        {
            public static void Main(string[] args)
            {
                Sudoku sudoku = new Sudoku();
                bool valid = sudoku.IsValid();


                Console.WriteLine(valid);
                sudoku.PrintBoard();
            }
        }
    }
    }
             
           

            
                
            
    
