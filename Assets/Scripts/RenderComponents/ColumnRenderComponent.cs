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
        userStoryTransform.localPosition = new Vector3(columnPosition.x, columnPosition.y  + columnCollider.bounds.size.y / 2 - storiesInColumn * 6f, userStoryTransform.localPosition.z);
        
    }  
    
    public void positionNewStory(Transform userStoryTransform, List<GameObject> problems, int storiesInColumn)
    {
        userStoryTransform.localPosition = new Vector3(columnPosition.x, columnPosition.y + (columnCollider.bounds.size.y / 2) - ((storiesInColumn - 1) * 16f), userStoryTransform.localPosition.z);
        foreach (GameObject problem in problems)
        {
            problem.transform.localPosition = new Vector3(columnPosition.x + 6, columnPosition.y + 6 + (columnCollider.bounds.size.y / 2) - ((storiesInColumn - 1) * 16f), userStoryTransform.localPosition.z );
        }
        
    }

    public void shiftStoriesUp(int deletedId, LinkedList<StoryNode> userStoriesList)
    {
        
    }
}
