using UnityEngine;
using UnityEngine.Assertions;

public class DiceRenderComponent
{
    private Sprite[] rollSprites;
    private SpriteRenderer diceSpriteRenderer;

    public DiceRenderComponent( SpriteRenderer diceSpriteRenderer, Sprite[] rollSprites)
    {
        Assert.AreEqual(rollSprites.Length, 6);
        this.diceSpriteRenderer = diceSpriteRenderer;
        this.rollSprites = rollSprites;
    }

    public void showRoll(int rollValue )
    {
        diceSpriteRenderer.sprite = rollSprites[rollValue];
    }
}
