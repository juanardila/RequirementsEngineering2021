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

    public void stopDragginOver(string column)
    {
        if (column == draggedIntoColumn)
        {
            draggedIntoColumn = null;
        }
    }

    public string draggedToColumn()
    {
        return draggedIntoColumn;
    }
    
}
