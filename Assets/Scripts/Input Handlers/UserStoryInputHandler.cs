using UnityEngine;


/**
 * this class handles the user story logic related to input
 */
public class UserStoryInputHandler
{
    private Transform transform;
    private UserStory userStory;
    private DraggableInputHandler draggableInputHandler;
    private CardRenderComponent cardRenderComponent;

    public UserStoryInputHandler(Transform transform, CardRenderComponent cardRenderComponent,
        UserStory userStory)
    {
        this.transform = transform;
        this.cardRenderComponent = cardRenderComponent;
        this.userStory = userStory;
        draggableInputHandler = new DraggableInputHandler();
        
    }

    public void onClick()
    {
        draggableInputHandler.onClick(); //Let base class control dragging states
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
        /*
         TODO: Control the allowed dragging areas using UserStory state & constrains from columns
                then call the appropriate event trigger for ex. if user story is dropped in backlog
        */
    }
}
