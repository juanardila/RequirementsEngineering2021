using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnRenderComponent
{
    private static Color defaultColor = Color.white;
    private static Color allowNewStory = Color.green;
    private SpriteRenderer spriteRenderer;
    private Vector3 columnPosition;
    private BoxCollider2D columnCollider;

    public ColumnRenderComponent(SpriteRenderer spriteRenderer, Vector3 columnPosition, BoxCollider2D columnCollider)
    {
        this.spriteRenderer = spriteRenderer;
        spriteRenderer.color = defaultColor;
        this.columnPosition = columnPosition;
        this.columnCollider = columnCollider;
    }

    public void paintToAllowNewStory()
    {
        spriteRenderer.color = allowNewStory;
    }

    public void paintToDefault()
    {
        spriteRenderer.color = defaultColor;
    }

    public void positionNewStory(Transform userStoryTransform, int storiesInColumn)
    {
        userStoryTransform.localPosition = new Vector3(columnPosition.x, columnPosition.y, userStoryTransform.localPosition.z);
    }

    public void shiftStoriesUp(int deletedId, LinkedList<StoryNode> userStoriesList)
    {
        
    }
}
