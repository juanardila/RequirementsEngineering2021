

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
    
    public enum EventCode
    {
        ROLL_AGAIN = 1,
        ADD_2_ROLL,
        RESOLVED_CARD,
        REMOVE_ONEPROBLEM,
        ADD_4_ROLL,
        ADD_3_ROLL,
        PLAYER_SKIPS_NEXT,
        REMOVE_PROGRESS_CARD,
        EVERYONE_SKIPS_NEXT,
        ADD_4_ESTIMATION,
        ADD_6_ESTIMATION,
        SUBSTRACT_1,
        DRAW_AGAIN,
        //Command for solution and error
        SOLUTION = 998,
        PROBLEM
    };

    public static Command CommandFactory(int eventCode)
    {
        return CommandFactory((EventCode) eventCode);
    }
    
    public static Command CommandFactory(EventCode eventCode)
    {
        switch (eventCode)
        {
            case EventCode.REMOVE_ONEPROBLEM:
                return new CommandRemoveOneProblem();
            case EventCode.ROLL_AGAIN:
                return new CommandRollAgain();
            case EventCode.ADD_2_ROLL:
                return new CommandAddRoll(2);
            case EventCode.RESOLVED_CARD:
                return new CommandResolvedCard();
            case EventCode.PROBLEM:
                return new CommandProblem();
            case EventCode.SOLUTION:
                return new CommandSolution();
            case EventCode.ADD_4_ROLL:
                return new CommandAddRoll(4);
            case EventCode.ADD_3_ROLL:
                return new CommandAddRoll(3);
            case EventCode.PLAYER_SKIPS_NEXT:
                return new CommandPlayerSkipsNext();
            case EventCode.REMOVE_PROGRESS_CARD:
                return new CommandRemoveProgress();
            case EventCode.EVERYONE_SKIPS_NEXT:
                return new CommandEveryoneSkips();
            case EventCode.ADD_4_ESTIMATION:
                return new CommandAddRoll(-4);
            case EventCode.ADD_6_ESTIMATION:
                return new CommandAddRoll(-6);
            default:
                return new EmptyCommand();
        }
    }
    public abstract int execute();
}
