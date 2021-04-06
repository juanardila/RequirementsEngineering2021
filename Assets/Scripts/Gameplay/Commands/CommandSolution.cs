using UnityEngine;

public class CommandSolution : Command
{
    public override int execute()
    {
        int cardId = Iteration.getInstance().getGameplaycomponent().getRound().getTurn().getDrawnCardId();
        ChanceCard chanceCard = Board.getInstance().chanceDeck.getChanceCard(cardId);
        GameObject solution = Board.getInstance().showCard(chanceCard);

        solution.AddComponent<Solution>();
        solution.transform.localPosition = Board.getInstance().solutionDeck.transform.localPosition;
        return 0;
    }
}
