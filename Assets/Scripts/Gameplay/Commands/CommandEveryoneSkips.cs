
public class CommandEveryoneSkips : Command
{
    public override int execute()
    {
        Round.nextRoundFlags.everyOneSkipsTurn = true;
        return 0;
    }
}
