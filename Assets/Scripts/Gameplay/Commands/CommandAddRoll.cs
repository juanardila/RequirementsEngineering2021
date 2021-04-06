public class CommandAddRoll : Command
{
    private int addValue;

    public CommandAddRoll(int addValue)
    {
        this.addValue = addValue;
    }
    public override int execute()
    {
        iterationGameplay.getRound().getTurn().addToDiceResult(addValue);
        return 0;
    }
}
