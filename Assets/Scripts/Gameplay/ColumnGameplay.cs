using System;
using System.Collections.Generic;
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

}
