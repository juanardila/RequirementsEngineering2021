using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor.Tilemaps;
using UnityEngine;
/**
 * This class handles everything related to the gameplay
 * of an user story
 */
public class UserStoryGameplayComponent
{
    private UserStoryInteractionComponent userStoryInteractionComponent;
    private Transform userStoryTransform;

    public int id;
    public int points;
    public string text;
    private string currentColumn;

    

    public UserStoryGameplayComponent(UserStoryInteractionComponent userStoryInteractionComponent, Transform userStoryTransform)
    {
        currentColumn = ColumnGameplayComponent.BACLOG_TAG;
        this.userStoryInteractionComponent = userStoryInteractionComponent;
        this.userStoryTransform = userStoryTransform;
    }

    public void moveToColumn()
    {
        Board.getInstance().getColumn(currentColumn).delete(this.id);
        currentColumn = userStoryInteractionComponent.draggedToColumn();
        Board.getInstance().getColumn(currentColumn).add(this, userStoryTransform);
    }


    public void moveToColumn(string column)
    {
        Board.getInstance().getColumn(column).delete(this.id);
        Board.getInstance().getColumn(column).add(this, userStoryTransform);
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
