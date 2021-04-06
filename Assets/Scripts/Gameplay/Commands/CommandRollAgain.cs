public class CommandRollAgain : Command
{
    public override int execute()
    {
        Iteration.getInstance().getGameplaycomponent().getRound()
            .getTurn().addToDiceResult(Dice.getInstance().getFirstDiceGameplayComponent().rollDice() 
                                       + Dice.getInstance().getFirstDiceGameplayComponent().rollDice() );
        return 0;
    }
}
