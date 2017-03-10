using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player : BJHand
{
	protected bool stand = false;

	public void Hit(Card c)
	{
		AddCard(c);
	}
    public bool IsStand
    {
        get { return stand; }
        set { stand = value; }
    }
	public void Stand()
	{
		stand = true;
	}

	public bool CanHit()
	{
		return (!IsBusted && !stand);
	}

	public virtual void Reset()
	{
		cards = new List<Card>();
		stand = false;
	}
}
