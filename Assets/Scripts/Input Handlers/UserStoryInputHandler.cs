using UnityEngine;


/**
 * this class handles the user story logic related to input
 */
public class UserStoryInputHandler
{
    private Transform transform;
    private UserStory userStory;
    private DraggableInputHandler draggableInputHandler;

    public UserStoryInputHandler(Transform transform, UserStory userStory)
    {
        this.transform = transform;
        this.userStory = userStory;
        draggableInputHandler = new DraggableInputHandler();
        
    }

    public new void onClick()
    {
        draggableInputHandler.onClick(); //Let base class control dragging states
        
        
    }

    public void onDrag()
    {
        draggableInputHandler.onDrag();
        transform.localPosition += draggableInputHandler.getDelta();
    }

    public void onRelase()
    {
        draggableInputHandler.onRelase();
        /*
         TODO: Control the allowed dragging areas using UserStory state & constrains from columns
                then call the appropriate event trigger for ex. if user story is dropped in backlog
        */
    }
}
