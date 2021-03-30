using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
/**
 * This class handles everything related to the gameplay
 * of an user story
 */
public class UserStoryGameplay
{
    public int id;
    public int points;
    public string text;

    private string currentColumn;

    public UserStoryGameplay()
    {
        currentColumn = ColumnGameplayComponent.TODO_TAG;
    }

    public void moveTo(string newColumn)
    {
        currentColumn = newColumn;
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
}
