
using UnityEngine;

public class CommandProblem : Command
{
    public override int execute()
    {
        int cardId = Iteration.getInstance().getGameplaycomponent().getRound().getTurn().getDrawnCardId();
        ChanceCard chanceCard = Board.getInstance().chanceDeck.getChanceCard(cardId);
        GameObject problem = Board.getInstance().showCard(chanceCard);

        UserStoryGameplayComponent userStoryGameplayComponent = Iteration.getInstance()
            .getGameplaycomponent().getRound().getTurn().getSelectedStory();

        problem.transform.localPosition = userStoryGameplayComponent.getTransform().localPosition 
                                          + new Vector3(6,6);

        userStoryGameplayComponent.addProblem(problem);
        return 0;
    }
}
