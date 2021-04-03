using System.Collections.Generic;
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
    private UserStoryRendererComponent userStoryRendererComponent;
    
    public int id;
    public int points;
    public string text;
    
    private string currentColumn;
    private TextMeshProUGUI pointsMesh;
    private bool canBeWorkedOn;

    public UserStoryGameplayComponent(UserStoryInteractionComponent userStoryInteractionComponent, Transform userStoryTransform,
        UserStoryNetworkingComponent userStoryNetworkingComponent, UserStoryRendererComponent userStoryRendererComponent)
    {
        this.currentColumn = ColumnGameplayComponent.BACLOG_TAG;
        this.userStoryInteractionComponent = userStoryInteractionComponent;
        this.userStoryTransform = userStoryTransform;
        this.userStoryNetworkingComponent = userStoryNetworkingComponent;
        this.userStoryRendererComponent = userStoryRendererComponent;
        this.canBeWorkedOn = false;
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
        userStoryNetworkingComponent.sendMoveUserStory(this.id, currentColumn, userStoryInteractionComponent.draggedToColumn());
        currentColumn = userStoryInteractionComponent.draggedToColumn();
        Board.getInstance().getColumn(currentColumn).add(this, userStoryTransform);
    }

    /**
     * Implementetion specific for networkning porpuses
     */
    public static void moveToColumn(int userStoryId, string prevColumn, string newColumn )
    {
        StoryNode storyNode = StoryList.find(Board.getInstance().getColumn(prevColumn).getStories(),
            userStoryId);
        if (storyNode.id != null)
        {
            storyNode.userStoryGameplayComponent.currentColumn = newColumn;
            Board.getInstance().getColumn(prevColumn).delete(userStoryId);
            Board.getInstance().getColumn(newColumn).add(storyNode.userStoryGameplayComponent, storyNode.userStoryTransform);
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
    
    public void setAvailableToWork()
    {
        this.canBeWorkedOn = true;
        userStoryRendererComponent.showWorkInStory();
    }
    public void setUnAvailableToWork()
    {
        this.canBeWorkedOn = false;
    }

    public bool storyCanBeWorkedOn()
    {
        return this.canBeWorkedOn;
    }
    
    private void setPoints(int points)
    {
        this.points = points;
        userStoryRendererComponent.setPointsText(points);
    }

    public void workInThisStory()
    {
        PlayerGameplay.workedOnStory = this;
        userStoryRendererComponent.showWorkingInStory();
        //Allow dice roll
    }
}
