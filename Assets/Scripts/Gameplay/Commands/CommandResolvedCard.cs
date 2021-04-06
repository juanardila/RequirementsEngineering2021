public class CommandResolvedCard : Command
{
    public override int execute()
    {
        UserStoryGameplayComponent userStoryGameplayComponent = Iteration.getInstance()
            .getGameplaycomponent().getRound().getTurn()
            .getSelectedStory();
        while (userStoryGameplayComponent.haveProblems())
        {
            Board.getInstance().deleteInstantiatedCard(userStoryGameplayComponent.deleteProblem());
        }
        userStoryGameplayComponent.setPoints(0);
        return 0;
    }
}
