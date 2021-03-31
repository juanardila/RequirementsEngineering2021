using UnityEngine;
using UnityEngine.Lumin;


/**
 * this class handles the user story logic related to input
 */
public class UserStoryInputHandler
{
    private Transform transform;
    private DraggableInputHandler draggableInputHandler;
    private CardRenderComponent cardRenderComponent;
    private UserStoryGameplayComponent userStoryGameplayComponent;
    public UserStoryInputHandler(Transform transform, CardRenderComponent cardRenderComponent,
        UserStoryGameplayComponent userStoryGameplayComponent)
    {
        this.transform = transform;
        this.cardRenderComponent = cardRenderComponent;
        draggableInputHandler = new DraggableInputHandler();
        this.userStoryGameplayComponent = userStoryGameplayComponent;

    }

    public void onClick()
    {
        draggableInputHandler.onClick(transform.localPosition); //Let base class control dragging states
        cardRenderComponent.raiseCard();
        
    }

    public void onDrag()
    {
        draggableInputHandler.onDrag();
        transform.localPosition += draggableInputHandler.getDelta();
    }

    public void onRelase()
    {
        draggableInputHandler.onRelase();
        cardRenderComponent.putDownCard();
        if (userStoryGameplayComponent.wasDraggedIntoAColumn())
        {
            userStoryGameplayComponent.moveToColumn();
        }
        else
        {
            transform.position = draggableInputHandler.getInitialDragPosition();
        }
        
        /*
         TODO: Control the allowed dragging areas using UserStory state & constrains from columns
                then call the appropriate event trigger for ex. if user story is dropped in backlog
        */
    }
}
