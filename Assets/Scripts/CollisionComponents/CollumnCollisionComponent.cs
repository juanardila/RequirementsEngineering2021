using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class CollumnCollisionComponent
{
    private ColumnRenderComponent columnRenderComponent;
    private ColumnGameplayComponent columnGameplayComponent;


    public CollumnCollisionComponent(ColumnRenderComponent columnRenderComponent,
        ColumnGameplayComponent columnGameplayComponent)
    {
        this.columnRenderComponent = columnRenderComponent;
        this.columnGameplayComponent = columnGameplayComponent;
    }


    public void onCollisionEnter(Collision2D other)
    {
        if (other.collider.CompareTag(UserStory.TAG))
        {
            UserStoryGameplay userStoryGameplay = other.gameObject.GetComponent<UserStory>()
                                                    .getGameplayComponent();
            if (userStoryGameplay.canBeMovedTo(columnGameplayComponent.getColumnTag()))
            {
                columnRenderComponent.paintToAllowNewStory();
            }
        }
    }

    public void onCollisionExit(Collision2D other)
    {
        if (other.collider.CompareTag(UserStory.TAG))
        {
            columnRenderComponent.paintToDefault();
        }
    }
    
}
