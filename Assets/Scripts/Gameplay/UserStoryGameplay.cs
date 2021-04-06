using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
/**
 * This class handles everything related to the gameplay
 * of an user story
 */
public class UserStoryGameplayComponent
{
    private static List<UserStoryGameplayComponent> userStoriesList = new List<UserStoryGameplayComponent>();

    public static UserStoryGameplayComponent getUserStoryGameplayComponent(int userStoryId)
    {
        return userStoriesList.Find(userStory => userStory.id == userStoryId);
    }
    
    private UserStoryInteractionComponent userStoryInteractionComponent;
    private Transform userStoryTransform;
    private UserStoryNetworkingComponent userStoryNetworkingComponent;
    private UserStoryRendererComponent userStoryRendererComponent;
    private List<GameObject> problemList;
    
    public int id;
    public int points;
    public string text;
    public int originalPoints;

    
    private string currentColumn;
    private TextMeshProUGUI pointsMesh;
    
    
    public UserStoryGameplayComponent(UserStoryInteractionComponent userStoryInteractionComponent, Transform userStoryTransform,
        UserStoryNetworkingComponent userStoryNetworkingComponent, UserStoryRendererComponent userStoryRendererComponent)
    {
        this.currentColumn = ColumnGameplayComponent.BACLOG_TAG;
        this.userStoryInteractionComponent = userStoryInteractionComponent;
        this.userStoryTransform = userStoryTransform;
        this.userStoryNetworkingComponent = userStoryNetworkingComponent;
        this.userStoryRendererComponent = userStoryRendererComponent;
        problemList = new List<GameObject>();
        userStoriesList.Add(this);
    }
    
    public void initializeRunTimeAttributes(int id, string title, int points, TextMeshProUGUI pointsMesh)
    {
        this.id = id;
        this.points = points;
        this.originalPoints = points;
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
        if (isDone())
        {
            userStoryRendererComponent.showDefault();
        }
        else
        {
            userStoryRendererComponent.showWorkInStory();    
        }
        
    }
    
    
    public void setUnAvailableToWork()
    {
        userStoryRendererComponent.showDefault();
    }

    public void setPoints(int points)
    {
        if (this.points <= 0)
        {
            return;
        }
        if (points <= 0)
        {
            this.points = 0;    
        }
        else
        {
            this.points = points;
        }
        userStoryRendererComponent.setPointsText(this.points);
    }

    public Transform getTransform()
    {
        return this.userStoryTransform;
    }

    public bool isDone()
    {
        return points <= 0 && problemList.Count == 0;
    }

    public void addProblem(GameObject gameObject)
    {
        problemList.Add(gameObject);
    }

    public bool haveProblems()
    {
        return problemList.Count != 0;
    }

    public GameObject deleteProblem()
    {
        if (haveProblems())
        {
            GameObject problem = problemList[problemList.Count - 1];
            problemList.RemoveAt(problemList.Count - 1);
            return problem;    
        }

        return null;
    }

    public List<GameObject> getProblems()
    {
        return problemList;
    }

  
}
