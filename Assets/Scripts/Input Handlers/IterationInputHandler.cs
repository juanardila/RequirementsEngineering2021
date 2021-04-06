public class IterationInputHandler
{
    private Iteration iteration;

    public IterationInputHandler()
    {
        iteration = Iteration.getInstance();
    }

    public void rollDices()
    {
        iteration.getGameplaycomponent().getRound().getTurn().rollDices();
    }

    public void startDayOrAdvancePhase()
    {
        iteration.getGameplaycomponent().getRound().endRound();
    }

    public void nextTurn()
    {
        iteration.getGameplaycomponent()
            .getRound().getTurn().finishTurn();
        
    }
}
