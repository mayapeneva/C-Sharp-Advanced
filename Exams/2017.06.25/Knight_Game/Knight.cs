﻿public class Knight
{
    public Knight(int row, int col)
    {
        this.Row = row;
        this.Col = col;
    }

    public int Row { get; private set; }
    public int Col { get; private set; }

    public int NumberOfKnightsToKill
    { get; set; }
}