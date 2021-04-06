using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;



public class ColumnGameplayComponent
{
    public const string BACLOG_TAG = "Backlog";
    public const string TODO_TAG = "ToDo";
    public const string ONPROGRESS_TAG = "OnProgress";
    public const string DONE_TAG = "Done";

    private string columnTag; //The type of column
    private LinkedList<StoryNode> userStoriesList; //Key is story id

    private ColumnRenderComponent columnRenderComponent;

    public ColumnGameplayComponent(string tag, ColumnRenderComponent columnRenderComponent)
    {
        switch (tag)
        {
            case BACLOG_TAG:
            case TODO_TAG:
            case ONPROGRESS_TAG:
            case DONE_TAG:
                columnTag = tag;
                break;
            default:
                throw new Exception("This tag does not exists");
        }

        this.columnRenderComponent = columnRenderComponent;
        userStoriesList = new LinkedList<StoryNode>();
    }

    public string getColumnTag()
    {
        return columnTag;
    }

    public void moveCardsToColumn(string tag)
    {
        switch (tag)
        {
            case ONPROGRESS_TAG:
                if(columnTag != ONPROGRESS_TAG)
                    moveCardsToColumn(Board.getInstance().onProgress.GetComponent<Column>().getGameplayComponent());
                break;
            case DONE_TAG:
                if(columnTag != DONE_TAG)
                    moveCardsToDone();
                break;
        }       
        
    }

    private void moveCardsToColumn(ColumnGameplayComponent newColumn)
    {
        newColumn.userStoriesList.Clear();
        newColumn.userStoriesList = this.userStoriesList;
        userStoriesList = new LinkedList<StoryNode>();
        int storyIndex = 1; //for simulating insertion one by one
        foreach (StoryNode storyNode in newColumn.userStoriesList )
        {
            newColumn.columnRenderComponent.positionNewStory(storyNode.userStoryTransform, 
                storyNode.userStoryGameplayComponent.getProblems(), storyIndex++);
        }
    }

    private void moveCardsToDone()
    {
        ColumnGameplayComponent done = Board.getInstance().done.gameObject.GetComponent<Column>().getGameplayComponent();
        ColumnGameplayComponent toDo = Board.getInstance().toDo.gameObject.GetComponent<Column>().getGameplayComponent();
        ColumnGameplayComponent onProgress = Board.getInstance().onProgress.gameObject.GetComponent<Column>().getGameplayComponent();
        
        toDo.userStoriesList = new LinkedList<StoryNode>(onProgress.userStoriesList);
        onProgress.userStoriesList = new LinkedList<StoryNode>();
        int storyIndex = 1;
        foreach (StoryNode storyNode in toDo.userStoriesList )
        {
            toDo.columnRenderComponent.positionNewStory(storyNode.userStoryTransform, storyNode.userStoryGameplayComponent.getProblems(), storyIndex++);
        }
        storyIndex = 1;
       
        foreach (StoryNode storyNode in toDo.userStoriesList)
        {
            if (storyNode.userStoryGameplayComponent.isDone())
            {
                done.columnRenderComponent.positionNewStory(storyNode.userStoryTransform,
                    storyNode.userStoryGameplayComponent.getProblems(), storyIndex++);
            }
        }
        
        
        foreach (StoryNode storyNode in done.userStoriesList)
        {
            if (done.userStoriesList.Contains(storyNode))
            {
                done.userStoriesList.Remove(storyNode);
                done.userStoriesList = new LinkedList<StoryNode>(done.userStoriesList);
            }
        }
        

    }

    public void add(UserStoryGameplayComponent userStory, Transform userStoryTransform)
    {
        userStoriesList.AddLast(new StoryNode(userStory.id, userStory, userStoryTransform));
        columnRenderComponent.positionNewStory(userStoryTransform, userStoriesList.Count);
        columnRenderComponent.paintToDefault();
    }

    public void delete(int deletedId)
    {
        columnRenderComponent.shiftStoriesUp(deletedId, userStoriesList);
        userStoriesList.Remove(new StoryNode(deletedId));
    }

    public LinkedList<StoryNode> getStories()
    {
        return userStoriesList;
    }

    public int sum()
    {
        int sum = 0;
        foreach(StoryNode storyNode in userStoriesList )
        {
            sum += storyNode.userStoryGameplayComponent.originalPoints;
        }

        return sum;
    }
    
    public int sumFinished()
    {
        int sum = 0;
        foreach(StoryNode storyNode in userStoriesList )
        {
            if(storyNode.userStoryGameplayComponent.isDone())
                sum += storyNode.userStoryGameplayComponent.originalPoints;
        }

        return sum;
    }

}
