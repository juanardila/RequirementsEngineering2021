using System;
using UnityEditor.XR.LegacyInputHelpers;

public class DiceGameplayComponent
{
    private DiceRenderComponent diceRenderComponent;
    private const int diceFaces = 6;
    private Random randomGenerator;
    private static Random seedGenerator = new Random();
    private static int getSeed()
    {
        return seedGenerator.Next();
    }
    public DiceGameplayComponent(DiceRenderComponent diceRendererComponent)
    {
        randomGenerator = new Random(getSeed());
        this.diceRenderComponent = diceRendererComponent;
    }

    public int rollDice()
    {
        //https://docs.microsoft.com/en-us/dotnet/api/system.random?view=net-5.0
        int rollValue = randomGenerator.Next(1, diceFaces + 1); 
        diceRenderComponent.showRoll(rollValue);
        return rollValue;
    }
}
