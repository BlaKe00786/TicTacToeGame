using System;
namespace TicTacToe
{
    class TicTacToeGame
    {
        private const int HEADS = 1;
        public enum GameStatus { WON, FULL_BOARD, CONTINUE};
        static void Main(string[] args)
        {
            do
            {
                char[] board = new char[10];
                board = initialBoard();
                char userLetter = chooseUserLetter();
                char compLetter = CompLetter(userLetter);
                char Player1 = toss(userLetter, compLetter);
                bool gameIsPlaying = true;
                GameStatus gameStatus;
                while (gameIsPlaying)
                {
                    if (Player1.Equals(userLetter))
                    {
                        showBoard(board);
                        int userMove = makeMove(board, userLetter);
                        String wonMessage = "You Won The Game!";
                        gameStatus = getGameStatus(board, userMove, userLetter, wonMessage);
                        Player1 = compLetter;
                    }
                    else
                    {
                        String wonMessage = "The computer has beaten you! You LOSE";
                        int computerMove = getComputerMove(board, compLetter, userLetter);
                        gameStatus = getGameStatus(board, computerMove, compLetter, wonMessage);
                        Player1 = userLetter;
                    }
                    if (gameStatus.Equals(GameStatus.CONTINUE)) continue;
                    gameIsPlaying = false;
                }
            } while (playAgain());
        }
        private static bool playAgain()
        {
            Console.WriteLine("Do you want to play again?(yes/no): ");
            string option = Console.ReadLine().ToLower();
            if (option.Equals("yes")) return true;
            return false;
        }
        private static GameStatus getGameStatus(char[] board, int move, char letter,string wonMessage)
        {
            board[move] = letter;
            if(isWinner(board,letter))
            {
                showBoard(board);
                Console.WriteLine(wonMessage);
                return GameStatus.WON;
            }
            if(isBoardFull(board))
            {
                showBoard(board);
                Console.WriteLine("Game is Tie");
                return GameStatus.FULL_BOARD;
            }
            return GameStatus.CONTINUE;
        }
        private static bool isBoardFull(char[] board)
        {
            for(int index=1;index<board.Length;index++)
            {
                if (board[index].Equals(' ')) return false;
            }
            return true;
        }
        private static int getComputerMove(char[] board, char computerLetter, char userLetter)
        {
            int winningMove = getWinningMove(board, computerLetter);
            if (winningMove != 0) return winningMove;
            int userWinningMove = getWinningMove(board, userLetter);
            if (userWinningMove != 0) return userWinningMove;
            int[] cornorMoves = { 1, 3, 7, 9 };
            int computerMove = getRandomMoveFromList(board, cornorMoves);
            if (computerMove != 0) return computerMove;
            if (board[5].Equals(' ')) return 5;
            int[] sideMoves = { 2, 4, 6, 8 };
            computerMove = getRandomMoveFromList(board, sideMoves);
            if (computerMove != 0) return computerMove;
            return 0;
        }
        private static int getRandomMoveFromList(char[] board, int[] moves)
        {
            for (int index = 0; index < moves.Length; index++)
            {
                if (board[index].Equals(' ')) return moves[index];
            }
            return 0;
        }
        private static int getWinningMove(char[] board,char letter)
        {
            for (int index=1;index<board.Length;index++)
            {
                char[] copyOfBoard = new char[10];
                System.Array.Copy(board, 0, copyOfBoard, 0, board.Length);
                if(copyOfBoard[index].Equals(' '))
                {
                    copyOfBoard[index] = letter;
                    if (isWinner(copyOfBoard, letter))
                        return index;
                }
            }
            return 0;
        }
        private static bool isWinner(char[] board, char ch)
        {
            return ((board[1]==ch && board[2]==ch && board[3]==ch)||
                (board[4] == ch && board[5] == ch && board[6] == ch) ||
                (board[7] == ch && board[8] == ch && board[9] == ch) ||
                (board[1] == ch && board[4] == ch && board[7] == ch) ||
                (board[2] == ch && board[5] == ch && board[8] == ch) ||
                (board[3] == ch && board[6] == ch && board[9] == ch) ||
                (board[1] == ch && board[5] == ch && board[9] == ch) ||
                (board[7] == ch && board[5] == ch && board[3] == ch));
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
        public static int makeMove(char[] board,char Letter)
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
                        return index;
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
