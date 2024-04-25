//Robert Jefferson Janairo
//Student ID 440059

using System;

class ConnectFour
{
    private const int Rows = 6;
    private const int Columns = 7;
    private char[,] board = new char[Rows, Columns];
    private char currentPlayer = 'X';
    private int row;
    private int column;

    public ConnectFour()
    {
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                board[row, col] = ' ';
            }
        }
    }

    private void PrintBoard()
    {
        Console.WriteLine(" 1 2 3 4 5 6 7");
        for (int row = 0; row < Rows; row++)
        {
            for(int col = 0; col < Columns; col++)
            {
                Console.Write("|" + board[row, col]);
            }
            Console.WriteLine("|");
        }
        Console.WriteLine("-------------------");
    }

    private bool IsColumnFull(int column)
    {
        return board[0, column] != ' ';
    }

    private bool IsBoardFull()
    {
        for (int col = 0; col < Columns; col++)
        {
            if (!IsColumnFull(col))
            {
                return false;
            }
        }
        return true;
    }

    private bool IsWinningMove(int rowm, int col)
    {
        //Checking Horizontal Line
        int count = 1;
        for (int i = col - 1; i >= 0 && board[row, i] == currentPlayer; i--) count++;
        for (int i = col + 1; i < Columns && board[rowm, i] == currentPlayer; i++) count++;
        if (count >= 4) return true;

        //Check Vertical
        count = 1;
        for (int i = row - 1; i >= 0 && board[i, col] == currentPlayer; i--) count++;
        for (int i = row + 1; i < Rows && board[i, col] == currentPlayer; i++) count++;


        // Check diagonal
        count = 1;
        for (int i = row - 1, j = col - 1; i >= 0 && j >= 0 && board[i, j] == currentPlayer; i--, j--) count++;
        for (int i = row + 1, j = col + 1; i < Rows && j < Columns && board[i, j] == currentPlayer; i++, j++) count++;
        if (count >= 4) return true;

        count = 1;
        for (int i = row - 1, j = col + 1; i >= 0 && j < Columns && board[i, j] == currentPlayer; i--, j++) count++;
        for (int i = row + 1, j = col - 1; i < Rows && j >= 0 && board[i, j] == currentPlayer; i++, j--) count++;
        if (count >= 4) return true;

        return false;
    }

    public void Play(int Column)
    {
        if (column < 1 || column > Columns || IsColumnFull(Column - 1))
        {
            Console.WriteLine("Invalide Move. Try Again....");
                return;
        }

        int row = Rows -1;
        while(row >= 0 && board [row, column - 1] ! == ' ')
        {
            row--;
        }

        board[row, column - 1] = ' ';

        if(IsWinningMove(row, column - 1))
        {
            Console.WriteLine($"Player {currentPlayer} wins!");
            PrintBoard();
            return;
        }

        if (IsBoardFull())
        {
            Console.WriteLine("It's a draw, Play Again?");
            PrintBoard();
            return;
        }

        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';

        PrintBoard();
    }

    internal object GetCurrentPlayer()
    {
        throw new NotImplementedException();
    }

    internal bool IsGameOver()
    {
        throw new NotImplementedException();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConnectFour game = new ConnectFour();
        int column;
        do
        {
            Console.WriteLine($"Player {game.GetCurrentPlayer()}'s turn");
            Console.WriteLine("Enter Column Number (1-7): ");
            column = int.Parse(s: Console.ReadLine());
            game.Play(column);
        } while (!game.IsGameOver());
    }
}