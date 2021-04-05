using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class handles the rendering properties of a card object
 */
public class CardRenderComponent
{
    protected SpriteRenderer spriteRenderer;

    
    private const int baseLayer = 2;
    private const int raisedLayer = 3;

    public CardRenderComponent()
    {}
    
    public CardRenderComponent(SpriteRenderer spriteRenderer)
    {
        this.spriteRenderer = spriteRenderer;
        putDownCard();
    }

    public void raiseCard()
    {
        spriteRenderer.sortingOrder = raisedLayer;
    }

    public void putDownCard()
    {
        spriteRenderer.sortingOrder = baseLayer;
    }

    public void setSpriteRenderer(SpriteRenderer spriteRenderer)
    {
        this.spriteRenderer = spriteRenderer;
    }
}
