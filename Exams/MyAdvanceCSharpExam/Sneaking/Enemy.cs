public class Enemy
{
    public Enemy(char type, int row, int col)
    {
        this.Type = type;
        this.Row = row;
        this.Col = col;
        this.CanMove = true;
    }

    public char Type { get; set; }
    public int Row { get; set; }
    public int Col { get; set; }
    public bool CanMove { get; set; }
}