using TMPro;
using UnityEngine;
/**
 * This class handles everything related to the gameplay
 * of an user story
 */
public class UserStoryGameplayComponent
{
    private UserStoryInteractionComponent userStoryInteractionComponent;
    private Transform userStoryTransform;
    private UserStoryNetworkingComponent userStoryNetworkingComponent;

    public int id;
    public int points;
    public string text;
    private string currentColumn;
    private TextMeshProUGUI pointsMesh;

    public UserStoryGameplayComponent(UserStoryInteractionComponent userStoryInteractionComponent, Transform userStoryTransform,
        UserStoryNetworkingComponent userStoryNetworkingComponent)
    {
        this.currentColumn = ColumnGameplayComponent.BACLOG_TAG;
        this.userStoryInteractionComponent = userStoryInteractionComponent;
        this.userStoryTransform = userStoryTransform;
        this.userStoryNetworkingComponent = userStoryNetworkingComponent;

    }
    
    public void initializeRunTimeAttributes(int id, string title, int points, TextMeshProUGUI pointsMesh)
    {
        this.id = id;
        this.points = points;
        this.text = text;
        this.pointsMesh = pointsMesh;
    }
    
    public void work(int pointsDiminished)
    {
        points -= pointsDiminished;
        pointsMesh.text = points.ToString();
    }

    public void moveToColumn()
    {
        Board.getInstance().getColumn(currentColumn).delete(this.id);
        currentColumn = userStoryInteractionComponent.draggedToColumn();
        userStoryNetworkingComponent.sendMoveUserStory(this.id, currentColumn);
        Board.getInstance().getColumn(currentColumn).add(this, userStoryTransform);
    }


    public static void moveToColumn(int userStoryId, string column)
    {
        StoryNode storyNode = Board.getInstance().getColumn(column).getStories().Find(new StoryNode(userStoryId)).Value;
        if (storyNode != null)
        {
            Board.getInstance().getColumn(column).delete(userStoryId);
            Board.getInstance().getColumn(column).add(storyNode.userStoryGameplayComponent, storyNode.userStoryTransform);    
        }
    }
    
    public bool canBeMovedTo(string newColumn)
    {
        bool canBeMoved = false;
        if (currentColumn == ColumnGameplayComponent.BACLOG_TAG &&
            newColumn == ColumnGameplayComponent.TODO_TAG)
        {
            canBeMoved = true;
        } else if (currentColumn == ColumnGameplayComponent.TODO_TAG &&
                   newColumn == ColumnGameplayComponent.BACLOG_TAG)
        {
            canBeMoved = true;
        }
        return canBeMoved;
    }

    public bool wasDraggedIntoAColumn()
    {
        string newColumn = userStoryInteractionComponent.draggedToColumn();
        //if it is different of current column then the card was moved
        return  newColumn != null &&
                newColumn != currentColumn;
    }

    public string getColumn()
    {
        return currentColumn;
    }

}
