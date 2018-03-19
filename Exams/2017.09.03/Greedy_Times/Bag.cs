using System.Collections.Generic;
using System.Linq;

public class Bag
{
    public Bag()
    {
        this.Gold = new Dictionary<string, long>();
        this.Gem = new Dictionary<string, long>();
        this.Cash = new Dictionary<string, long>();
    }

    public Dictionary<string, long> Gold { get; set; }
    public Dictionary<string, long> Gem { get; set; }
    public Dictionary<string, long> Cash { get; set; }

    public long GetCapacity()
    {
        return this.GetTotalGold() + this.GetTotalGems() + this.GetTotalCash();
    }

    public long GetTotalGold()
    {
        return this.Gold.Sum(g => g.Value);
    }

    public long GetTotalGems()
    {
        return this.Gem.Sum(g => g.Value);
    }

    public long GetTotalCash()
    {
        return this.Cash.Sum(c => c.Value);
    }
}