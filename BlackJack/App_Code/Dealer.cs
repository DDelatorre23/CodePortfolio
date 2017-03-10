using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dealer : Player
{
	private Deck deck;

	public Dealer() : base()
	{
		deck = new Deck();
		deck.Shuffle();
	}
	
	public override void Reset()
	{
		base.Reset();
        stand = false;
		deck = new Deck();
		deck.Shuffle();
	}

	public Card Deal()
	{
		return deck.Deal();
	}

	public void Play()
	{
		while (Score < 17)
		{
			Hit(Deal());
  		}
        stand = true;
    }

	public bool IsWinner(Player p)
	{
        if (p.IsBusted)
            return true;
        else if (IsBusted)
            return false;
        else if (p.IsBlackJack)
            return false;
        else if (p.Score < Score)
            return true;
        else
            return false;
	}
}
