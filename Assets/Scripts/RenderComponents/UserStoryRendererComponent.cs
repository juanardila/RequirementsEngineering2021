using TMPro;
using UnityEngine;

public class UserStoryRendererComponent : CardRenderComponent
{
    private Sprite userStorySprite;
    private Sprite workInStorySprite;
    private Sprite workingInStorySprite;
    private Sprite workingDisabledSprite;
    private SpriteRenderer spriteRenderer;
    private TextMeshProUGUI pointsMesh;
    
    public UserStoryRendererComponent(SpriteRenderer spriteRenderer,
        TextMeshProUGUI pointsMesh, Sprite workInStorySprite,
        Sprite workingInStorySprite, Sprite workingDisabledSprite ) : base(spriteRenderer)
    {
        this.spriteRenderer = spriteRenderer;
        this.userStorySprite = spriteRenderer.sprite;
        this.pointsMesh = pointsMesh;
        this.workInStorySprite = workInStorySprite;
        this.workingInStorySprite = workingInStorySprite;
        this.workingDisabledSprite = workingDisabledSprite;
    }

    public void setPointsText(int points)
    {
        pointsMesh.text = points.ToString();
    }

    public void showWorkInStory()
    {
        spriteRenderer.sprite = workInStorySprite;
    }

    public void showWorkingInStory()
    {
        spriteRenderer.sprite = workingInStorySprite;
    }

    public void showDefault()
    {
        spriteRenderer.sprite = userStorySprite;
    }
    
    
    
    
}
