public class CommandAdd2Roll : Command
{
    public override int execute()
    {
        iterationGameplay.getRound().getTurn().addToDiceResult(2);
        return 0;
    }
}
