using System;

namespace TicTacToe
{
    class TicTacToeGame
    {
        static void Main(string[] args)
        {
            char[] board = new char[10];
            board = initialBoard();
            char userLetter = chooseUserLetter();
            char compLetter;
            if(userLetter.Equals('X'))
            {
                compLetter = 'O';
            }
            else
            {
                compLetter = 'X';
            }
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
        public static char chooseUserLetter()
        {
            string userLetter;
            while(true)
            {
                Console.WriteLine("Choose your Letter (X or O) : ");
                userLetter = Console.ReadLine();
                if (userLetter[0].Equals('X') || userLetter[0].Equals('O'))
                {
                    return userLetter[0];
                }
                else
                {
                    Console.WriteLine("Enter Valid Input");
                }
            }
        }
    }
}
