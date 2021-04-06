using System.Collections.Generic;
using System.Data;

public class ChanceDeck
{
    private Dictionary<int, ChanceCard> chanceCards;
    private List<int> stackOfCards;

    public ChanceDeck()
    {
        chanceCards = new Dictionary<int, ChanceCard>();
        stackOfCards = new List<int>();
    }

    public void addCard(int cardId, ChanceCard card)
    {
        stackOfCards.Add(cardId);
        chanceCards.Add(cardId, card);
    }

    public int drawFromDeck()
    {
        int drawnCard = stackOfCards[0];
        stackOfCards.RemoveAt(0);
        return drawnCard;
    }

    public List<int> getStackOfCards()
    {
        return stackOfCards;
    }

    public ChanceCard getChanceCard(int cardId)
    {
        return chanceCards[cardId];
    }

}
