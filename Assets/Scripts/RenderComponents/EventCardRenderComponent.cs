
using System;
using TMPro;
using UnityEngine;

public class ChanceCardRenderComponent : CardRenderComponent
{
    public static Sprite happySprite;
    public static Sprite neutralSprite;
    public static Sprite badSprite;
    public static Sprite problemSprite;
    public static Sprite solutionSprite;
    
    private ChanceCardGameplayComponent cardGameplayComponent;
    private Sprite cardSprite;
    enum Faces
    {
        HAPPY = 1,
        NEUTRAL,
        SAD
    }

    public enum CardType
    {
        PROBLEM,
        EVENT,
        SOLUTION
    }

    public ChanceCardRenderComponent(CardType cardType,int faceId, 
        ChanceCardGameplayComponent cardGameplayComponent) : base()
    {
        this.cardGameplayComponent = cardGameplayComponent; 
        switch ((Faces) faceId)
        {
            case Faces.HAPPY:
                this.cardSprite = happySprite;
                break;
            case Faces.NEUTRAL:
                this.cardSprite = neutralSprite;
                break;
            case Faces.SAD:
                this.cardSprite = badSprite;
                break;
            default:
                throw new Exception("Invalid Sprite Code For Event Card");
        }
    }

    public ChanceCardRenderComponent(CardType cardType,
        ChanceCardGameplayComponent cardGameplayComponent)
    {
        this.cardGameplayComponent = cardGameplayComponent;
        switch (cardType)
        {
            case CardType.PROBLEM:
                this.cardSprite = problemSprite;
                break;
            case CardType.SOLUTION:
                this.cardSprite = solutionSprite;
                break;
            default:
                throw new Exception("Invalid Card Type");
        }
    }
    

    public void draw(SpriteRenderer spriteRenderer, TextMeshProUGUI titleMesh, TextMeshProUGUI descriptionMesh)
    {
        setSpriteRenderer(spriteRenderer);
        titleMesh.text = cardGameplayComponent.getTitle();
        descriptionMesh.text = cardGameplayComponent.getDescription();
        this.spriteRenderer.sprite = this.cardSprite;
    }
}
