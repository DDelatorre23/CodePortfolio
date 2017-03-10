using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BJHand : Hand
{
    private bool isBlackJack = false;
    public BJHand() : base() { }

    public BJHand(Deck d, int numCards) : base(d, numCards)
    {
    }

    public int Score
    {
        get
        {
            int score = 0;
            foreach (Card c in cards)
            {
                if (c.IsFaceCard())
                    score += 10;
                else
                    score += c.Value;
            }
            if (HasAce && score <= 11)
                score += 10;

            return score;
        }
    }

    public bool HasAce
    {
        get
        {
            foreach (Card c in cards)
            {
                if (c.IsAce())
                    return true;
            }
            return false;
        }
    }

    public bool IsBusted
    {
        get
        {
            if (Score > 21)
                return true;
            else
                return false;
        }
    }

    public bool IsBlackJack
    {
        get { return isBlackJack; }
        set
        {
            if(Score == 21)
            {
                isBlackJack = true;
            }
            else
            {
                isBlackJack = false;
            }
        }

    }
}

