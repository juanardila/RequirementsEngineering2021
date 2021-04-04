using System;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite roll1;
    public Sprite roll2;
    public Sprite roll3;
    public Sprite roll4;
    public Sprite roll5;
    public Sprite roll6;
    public SpriteRenderer firstDiceSpriteRenderer;
    public SpriteRenderer secondDiceSpriteRenderer;
    
    private DiceGameplayComponent firstDiceGameplayComponent;
    private DiceRenderComponent firstDiceRenderComponent;
    private DiceGameplayComponent secondDiceGameplayComponent;
    private DiceRenderComponent secondDiceRenderComponent;

    private static Dice _instance;
    public static Dice getInstance()
    {
        return _instance;
    }

    
    //Singleton pattern
    //https://gamedev.stackexchange.com/questions/116009/in-unity-how-do-i-correctly-implement-the-singleton-pattern
    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Sprite[] rollSprites = {roll1, roll2, roll3, roll4, roll5, roll6};
            firstDiceRenderComponent = new DiceRenderComponent(firstDiceSpriteRenderer, rollSprites);
            secondDiceRenderComponent = new DiceRenderComponent(secondDiceSpriteRenderer, rollSprites);
            firstDiceGameplayComponent = new DiceGameplayComponent(firstDiceRenderComponent);
            secondDiceGameplayComponent = new DiceGameplayComponent(secondDiceRenderComponent);
            _instance = this;
        }
    }

    public DiceGameplayComponent getFirstDiceGameplayComponent()
    {
        return this.firstDiceGameplayComponent;
    }
    
    public DiceGameplayComponent getSecondDiceGameplayComponent()
    {
        return secondDiceGameplayComponent;
    }
    
    public DiceGameplayComponent getFirstDiceRenderComponent()
    {
        return firstDiceGameplayComponent;
    }
    
    
    
}
