using System;
namespace TicTacToe
{
    class TicTacToeGame
    {
        private const int HEADS = 1;
        private const int TAILS = 0;
        static void Main(string[] args)
        {
            char[] board = new char[10];
            board = initialBoard();
            char userLetter = chooseUserLetter();
            char compLetter=CompLetter(userLetter);
            char Player1=toss(userLetter, compLetter);
            board = makeMove(board,Player1);
            showBoard(board);
        }
        public static char toss(char userLetter,char compLetter)
        {
            Random random = new Random();
            int toss = random.Next(0, 2);
            if(toss == HEADS)
            {
                Console.WriteLine("Heads. User goes first.");
                return userLetter;
            }
            else
            {
                Console.WriteLine("Tails. Computer goes first.");
                return compLetter;
            }
        }
        public static char[] makeMove(char[] board,char Letter)
        {
            while(true)
            {
                Console.WriteLine("Enter Your Move (1-9): ");
                int index = Convert.ToInt32(Console.ReadLine());
                if (index < 1 || index > 9)
                {
                    Console.WriteLine("Enter Valid input");
                }
                else
                {
                    if(board[index].Equals(' '))
                    {
                        board[index] = Letter;
                        return board;
                    }
                    else
                    {
                        Console.WriteLine("Index not free");
                    }
                }
            }
        }
        public static char CompLetter(char userLetter)
        {
            if (userLetter.Equals('X'))
            {
                return 'O';
            }
            else
            {
                return 'X';
            }
        }
        public static void showBoard(char[] board)
        {
            Console.WriteLine(board[1]+" | "+ board[2]+" | "+ board[3]);
            Console.WriteLine("-----------");
            Console.WriteLine(board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine("-----------");
            Console.WriteLine(board[7] + " | " + board[8] + " | " + board[9]);
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
            char userLetter;
            while(true)
            {
                Console.WriteLine("Choose your Letter (X or O) : ");
                userLetter = Console.ReadLine()[0];
                userLetter = char.ToUpper(userLetter);
                if (userLetter.Equals('X') || userLetter.Equals('O'))
                {
                    return userLetter;
                }
                else
                {
                    Console.WriteLine("Enter Valid Input");
                }
            }
        }
    }
}
