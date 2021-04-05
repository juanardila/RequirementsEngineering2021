public class IterationInputHandler
{
    private Iteration iteraton;

    public IterationInputHandler()
    {
        iteraton = Iteration.getInstance();
    }

    public void rollDices()
    {
        iteraton.getGameplaycomponent().rollDices();
    }

    public void startDayOrAdvancePhase()
    {
        iteraton.getGameplaycomponent().advanceDay();
    }

    public void nextTurn()
    {
        Iteration.getInstance().getGameplaycomponent().nextPlayerWorks();
        
    }
}
