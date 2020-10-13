using System;

namespace TicTacToe
{
    class TicTacToeGame
    {
        static void Main(string[] args)
        {
            char[] board = new char[10];
            board = initialBoard();
        }
        public static char[] initialBoard()
        {
            char[] board = new char[10];
            for (int index = 1; index < board.Length; index++)
            {
                board[index] = ' ';
            }
            return board;
        }
    }
}
