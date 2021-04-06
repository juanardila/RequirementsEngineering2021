
public class CommandRemoveOneProblem : Command
{
    public override int execute()
    {
        Iteration.getInstance().getGameplaycomponent().getRound()
            .getTurn().getSelectedStory().deleteProblem();
        return 0;
    }
}
