using System;
using System.Linq;

public class Program
{
    public const int Size = 8;

    public static void Main()
    {
        var matrix = new string[Size][];
        for (int i = 0; i < Size; i++)
        {
            matrix[i] = Console.ReadLine().Split(',').ToArray();
        }

        string move;
        while ((move = Console.ReadLine()) != "END")
        {
            var args = move.ToCharArray();
            var figure = args[0];
            var startRow = int.Parse(args[1].ToString());
            var startCol = int.Parse(args[2].ToString());
            var endRow = int.Parse(args[4].ToString());
            var endCol = int.Parse(args[5].ToString());

            if (IsNotValid(matrix, figure, startRow, startCol))
            {
                Console.WriteLine("There is no such a piece!");
                continue;
            }

            if (PieceMakesInvalidMove(figure, startRow, startCol, endRow, endCol))
            {
                Console.WriteLine("Invalid move!");
                continue;
            }

            if (PieceGetsOutOfTheBoard(endRow, endCol))
            {
                Console.WriteLine("Move go out of board!");
                continue;
            }

            matrix[startRow][startCol] = "x";
            matrix[endRow][endCol] = figure.ToString();
        }
    }

    private static bool IsNotValid(string[][] matrix, char figure, int startRow, int startCol)
    {
        return startRow < 0
            || startRow > Size - 1
            || startCol < 0
            || startCol > Size - 1
            || !matrix[startRow][startCol].Equals(figure.ToString());
    }

    private static bool PieceMakesInvalidMove(char figure, int startRow, int startCol, int endRow, int endCol)
    {
        switch (figure)
        {
            case 'K':
                if ((Math.Abs(startRow - endRow) == 1
                    && Math.Abs(startCol - endCol) == 0)
                    || (Math.Abs(startCol - endCol) == 1
                    && Math.Abs(startRow - endRow) == 0)
                    || (Math.Abs(startRow - endRow) == 1
                        && Math.Abs(startCol - endCol) == 1))
                {
                    return false;
                }

                return true;

            case 'R':
                if (startCol - endCol == 0
                    || startRow - endRow == 0)
                {
                    return false;
                }

                return true;

            case 'B':
                if (Math.Abs(startRow - endRow) == Math.Abs(startCol - endCol))
                {
                    return false;
                }

                return true;

            case 'Q':
                if (startCol - endCol == 0
                    || startRow - endRow == 0
                    || (Math.Abs(startRow - endRow) == Math.Abs(startCol - endCol)))
                {
                    return false;
                }

                return true;

            case 'P':
                if (startRow - endRow == 1 && startCol == endCol)
                {
                    return false;
                }

                return true;
        }

        return true;
    }

    private static bool PieceGetsOutOfTheBoard(int endRow, int endCol)
    {
        if (endRow < 0 || endRow > Size - 1
            || endCol < 0 || endCol > Size - 1)
        {
            return true;
        }

        return false;
    }
}