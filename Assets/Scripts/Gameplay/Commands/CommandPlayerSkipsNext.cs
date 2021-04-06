
public class CommandPlayerSkipsNext : Command
{
    public override int execute()
    {
        Round.nextRoundFlags.skipsTurn.Add(Iteration
            .getInstance().getGameplaycomponent().getRound()
            .getTurn().currentPlayer());
        return 0;
    }
}