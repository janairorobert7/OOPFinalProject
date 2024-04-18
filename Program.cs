//Robert Jefferson Janairo
//Student ID 440059

using System;

class ConnectFour
{
    private const int Rows = 6;
    private const int Columns = 7;
    private char[,] board = new char[Rows, Columns];
    private char currentPlayer = 'X';

    public ConnectFour()
    {
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int row = 0; row < Rows; i++)
        {
            for(int col= 0; col < Columns; j++)
            {
                board[row, col] = ' ';
            }
        }
    }

    private void PrintBoard(char[] board)
    {

    }
}