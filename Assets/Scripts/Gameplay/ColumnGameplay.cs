using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColumnGameplayComponent
{
    public const string BACLOG_TAG = "Backlog";
    public const string TODO_TAG = "ToDo";
    public const string ONPROGRESS_TAG = "OnProgress";
    public const string DONE_TAG = "Done";

    private string columnTag; //The type of column

    public ColumnGameplayComponent(string tag)
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
    }

    public string getColumnTag()
    {
        return columnTag;
    }
    
    
    
    
    
    
}
