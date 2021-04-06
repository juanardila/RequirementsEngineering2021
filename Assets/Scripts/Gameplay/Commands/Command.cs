

using System;

public abstract class Command
{
    protected Board board;
    protected IterationGameplayComponent iterationGameplay;
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
            case ChanceCardGameplayComponent.EventCode.PROBLEM:
                return new CommandProblem();
            default:
                //throw new Exception("Invalid Event Code");
                return new CommandAdd2Roll();
        }
    }
    public abstract int execute();
}
