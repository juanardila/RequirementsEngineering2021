using Photon.Pun;
using UnityEngine;
using UnityEngine.Lumin;


/**
 * this class handles the user story logic related to input
 */
public class UserStoryInputHandler
{
    private Transform transform;
    private DraggableInputHandler draggableInputHandler;
    private UserStoryRendererComponent userStoryRenderComponent;
    private UserStoryGameplayComponent userStoryGameplayComponent;
    private UserStoryInteractionComponent userStoryInteractionComponent;
    public UserStoryInputHandler(Transform transform, UserStoryRendererComponent userStoryRenderComponent,
        UserStoryGameplayComponent userStoryGameplayComponent, UserStoryInteractionComponent userStoryInteractionComponent)
    {
        this.transform = transform;
        this.userStoryRenderComponent = userStoryRenderComponent;
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
            userStoryRenderComponent.raiseCard();    
        } else if (Sprint.getInstance().getGameplayComponent().getPhase() == SprintGameplay.Phase.WorkWithInIteration &&
                   !userStoryGameplayComponent.isDone() )
        {
            Iteration.getInstance().getGameplaycomponent().getRound()
                .getTurn().workInThisStory(userStoryGameplayComponent);
            userStoryRenderComponent.showWorkingInStory();
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
            userStoryRenderComponent.putDownCard();
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
