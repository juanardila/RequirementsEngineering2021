using UnityEngine;

public class UserStoryInteractionComponent
{
    private string draggedIntoColumn;
    public UserStoryInteractionComponent()
    {
        draggedIntoColumn = null;
    }

    public void beingDraggedOver(string column)
    {
        draggedIntoColumn = column;
    }

    
    public void resetDragging()
    {
        draggedIntoColumn = null;
    }
    
    public void resetDragging(string currentColumnTag) 
    {
        if (currentColumnTag == draggedIntoColumn)
        {
            draggedIntoColumn = null;         
        }
            
    }
    
    public string draggedToColumn()
    {
        return draggedIntoColumn;
    }
    
}
