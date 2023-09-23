namespace Tic_tac_toe
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static int rows = 3;
        static int cols = 3;
        static char currentPlayer = 'X';

        public static void Main()
        {
            Console.WriteLine("Welcome to my Tic-Tac-Toe Game");

            InitializeBoard(rows, cols, board);
            PlayGame();
        }

        static void InitializeBoard(int rows, int cols, char[,] board)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                board[row, col] = ' ';
                }
            }
        }

        static void DrawingBoard(int rows, int cols, char[,] board)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.ForegroundColor = (board[row, col] == 'X') ?    ConsoleColor.Blue : ConsoleColor.Red;

                    Console.Write($" {board[row, col]} ");

                    if (col < 2)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();

                if (row < 2)
                {
                    Console.WriteLine("-----------");
                }
            }
            Console.ResetColor();
        }

        static bool IsBoardFull(int rows, int cols, char[,] board)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (board[row, col] == ' ')
                    {
                        return false; // This means their is still a space in board
                    }
                }
            }

            return true; //the board is full
        }

        static void PlayGame()
        {
            DrawingBoard(rows , cols, board);

            if (!MakeMove())
            {
                return; //Game over
            }

            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';

            PlayGame();
        }

        static bool MakeMove()
        {
            Console.WriteLine($"Player {currentPlayer} choose row and column (0-2): ");

            Console.Write("The row: ");
            string input = Console.ReadLine();
            Console.Write("The col: ");
            string input2 = Console.ReadLine();

            if (IsMoveValid(input, input2, board))
            {
                int row = int.Parse(input);
                int col = int.Parse(input2);

                board[row, col] = currentPlayer;

                if (CheckForWin(board))
                {
                    DrawingBoard(rows, cols, board);
                    Console.WriteLine($"Player {currentPlayer} wins !");
                    return false;
                }
                else if (IsBoardFull(rows, cols, board))
                {
                    DrawingBoard(rows, cols, board);
                    Console.WriteLine("Game is draw !");
                    return false;
                }

            }
            else
            {
                Console.WriteLine("Invalid move! Other player turn.");
            }

            return true;
        }

        static bool IsMoveValid(string input, string input2, char[,] board)
        {
            return int.TryParse(input.ToString(), out int row) && int.TryParse(input2.ToString(), out int col) && row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ';
        }

        static bool CheckForWin(char[,] board)
        {
            string topRow = board[0, 0].ToString() + board[0, 1] + board[0, 2].ToString();
            string midRow = board[1, 0].ToString() + board[1, 1] + board[1, 2].ToString();
            string botRow = board[2, 0].ToString() + board[2, 1] + board[2, 2].ToString();
            string firstCol = board[0, 0].ToString() + board[1, 0].ToString() + board[2, 0].ToString();
            string secondCol = board[0, 1].ToString() + board[1, 1].ToString() + board[2, 1].ToString();
            string thirdCol = board[0, 2].ToString() + board[1, 2].ToString() + board[2, 2].ToString();
            string diagonal = board[0, 0].ToString() + board[1, 1].ToString() + board[2, 2].ToString();
            string otherDiagonal = board[0, 2].ToString() + board[1, 1].ToString() + board[2, 0].ToString();

            string playerTriple = currentPlayer.ToString() + currentPlayer.ToString() + currentPlayer.ToString();

            if (topRow.Equals(playerTriple)
                || midRow.Equals(playerTriple)
                || botRow.Equals(playerTriple)
                || firstCol.Equals(playerTriple)
                || secondCol.Equals(playerTriple)
                || thirdCol.Equals(playerTriple)
                || diagonal.Equals(playerTriple)
                || otherDiagonal.Equals(playerTriple))
            {
                return true;
            }

            return false;
        }
    }
}
