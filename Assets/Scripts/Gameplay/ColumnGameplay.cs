using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ColumnGameplayComponent
{
    public const string BACLOG_TAG = "Backlog";
    public const string TODO_TAG = "ToDo";
    public const string ONPROGRESS_TAG = "OnProgress";
    public const string DONE_TAG = "Done";

    private string columnTag; //The type of column
    private ColumnRenderComponent columnRenderComponent;

    public ColumnGameplayComponent(string tag, ColumnRenderComponent columnRenderComponent)
    {
        switch (tag)
        {
            case BACLOG_TAG:
            case TODO_TAG:
            case ONPROGRESS_TAG:
            case DONE_TAG:
                this.columnTag = tag;
                break;
            default:
                throw new Exception("This tag does not exists");
        }

        this.columnRenderComponent = columnRenderComponent;
    }

    public string getColumnTag()
    {
        return columnTag;
    }

    public void add(UserStoryGameplayComponent userStory, Transform userStoryTransform)
    {
        Debug.Log("adding user story to column");
        
        columnRenderComponent.paintToDefault();
    }
    
    
    
    
    
}
