public class CommandRemoveProgress : Command
{
    public override int execute()
    {
        
        UserStoryGameplayComponent userStoryGameplayComponent = Iteration.getInstance().
            getGameplaycomponent().getRound().getTurn()
            .getSelectedStory();
        int diceResult = Iteration.getInstance().getGameplaycomponent().getRound().getTurn().getDiceResult();
        userStoryGameplayComponent
            .setPoints(userStoryGameplayComponent.originalPoints + diceResult);
        
        return 0;
    }
}
