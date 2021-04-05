

using System;

public abstract class Command
{
    protected Board board;
    protected IterationGameplay iterationGameplay;
    protected Command()
    {
        board = Board.getInstance();
        iterationGameplay = Iteration.getInstance().getGameplaycomponent();
    }

    public static Command CommandFactory(int eventCode)
    {
        switch ((ChanceCardGameplayComponent.EventCode)eventCode)
        {
            case ChanceCardGameplayComponent.EventCode.ADD_2_ROLL:
                return new CommandAdd2Roll();
            default:
                //throw new Exception("Invalid Event Code");
                return new CommandAdd2Roll();
        }
    }
    public abstract int execute();
}
