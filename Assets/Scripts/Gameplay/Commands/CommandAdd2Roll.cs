public class CommandAdd2Roll : Command
{
    public override int execute()
    {
        iterationGameplay.setRollValue(iterationGameplay.getRollValue() + 2);
        return 0;
    }
}
