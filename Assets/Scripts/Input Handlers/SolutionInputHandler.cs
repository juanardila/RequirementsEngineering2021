
using UnityEngine;

public class SolutionInputHandler
{
    private Transform transform;
    private DraggableInputHandler draggableInputHandler;

    public SolutionInputHandler(Transform transform)
    {
        draggableInputHandler = new DraggableInputHandler();
        this.transform = transform;
    }
    
    public void onClick()
    {
        if (Sprint.getInstance().getGameplayComponent().getPhase() == SprintGameplay.Phase.WorkWithInIteration &&
            Iteration.getInstance().getGameplaycomponent().getRound().isOver())
        {
            draggableInputHandler.onClick(transform.localPosition);
        }
    }

    public void onDrag()
    {
        draggableInputHandler.onDrag();
        transform.localPosition += draggableInputHandler.getDelta();
    }

    public void onRelase()
    {
        draggableInputHandler.onRelase();
    }

}
