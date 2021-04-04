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
}
