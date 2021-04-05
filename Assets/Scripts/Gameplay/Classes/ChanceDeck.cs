using System.Collections.Generic;
using System.Data;

public class ChanceDeck
{
    private Dictionary<int, ChanceCard> chanceCards;
    private Queue<int> stackOfCards;

    public ChanceDeck()
    {
        chanceCards = new Dictionary<int, ChanceCard>();
        stackOfCards = new Queue<int>();
    }

    public void addCard(int cardId, ChanceCard card)
    {
        stackOfCards.Enqueue(cardId);
        chanceCards.Add(cardId, card);
    }

    public int drawCard()
    {
        int drawnCard = stackOfCards.Dequeue();
        Board.getInstance().showCard(chanceCards[drawnCard]);
        int result = chanceCards[drawnCard].chanceCardGameplayComponent.followInstructions();
        return (drawnCard == 0)? drawnCard : result;
    }

}
