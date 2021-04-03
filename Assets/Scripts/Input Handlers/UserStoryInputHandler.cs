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
    private UserStoryInteractionComponent userStoryInteractionComponent;
    public UserStoryInputHandler(Transform transform, CardRenderComponent cardRenderComponent,
        UserStoryGameplayComponent userStoryGameplayComponent, UserStoryInteractionComponent userStoryInteractionComponent)
    {
        this.transform = transform;
        this.cardRenderComponent = cardRenderComponent;
        draggableInputHandler = new DraggableInputHandler();
        this.userStoryGameplayComponent = userStoryGameplayComponent;
        this.userStoryInteractionComponent = userStoryInteractionComponent;

    }
    //TODO: Refactor if checking state of sprint 
    public void onClick()
    {
        if (Sprint.getInstance().getGameplayComponent().getPhase() == SprintGameplay.Phase.PlanningAndCommitment)
        {
            draggableInputHandler.onClick(transform.localPosition); //Let base class control dragging states
            cardRenderComponent.raiseCard();    
        }
    }

    public void onDrag()
    {
        if (Sprint.getInstance().getGameplayComponent().getPhase() == SprintGameplay.Phase.PlanningAndCommitment)
        {
            draggableInputHandler.onDrag();
            transform.localPosition += draggableInputHandler.getDelta();
        }
    }

    public void onRelase()
    {
        if (Sprint.getInstance().getGameplayComponent().getPhase() == SprintGameplay.Phase.PlanningAndCommitment)
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
        }

        // userStoryInteractionComponent.resetDragging();
    }
}
