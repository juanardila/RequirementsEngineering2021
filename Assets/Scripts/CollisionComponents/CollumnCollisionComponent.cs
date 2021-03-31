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
            UserStoryGameplayComponent userStoryGameplay = other.gameObject.GetComponent<UserStory>()
                                                    .getGameplayComponent();
            UserStoryInteractionComponent userStoryInteraction = other.gameObject.GetComponent<UserStory>()
                                                    .getInteractionComponent();
            if (userStoryGameplay.canBeMovedTo(columnGameplayComponent.getColumnTag()))
            {
                columnRenderComponent.paintToAllowNewStory();
                userStoryInteraction.beingDraggedOver(columnGameplayComponent.getColumnTag());
            }
        }
    }

    public void onCollisionExit(Collision2D other)
    {
        if (other.collider.CompareTag(UserStory.TAG))
        {
            columnRenderComponent.paintToDefault();
            other.gameObject.GetComponent<UserStory>().getInteractionComponent()
                .resetDraggin(columnGameplayComponent.getColumnTag());
        }
    }
    
}
