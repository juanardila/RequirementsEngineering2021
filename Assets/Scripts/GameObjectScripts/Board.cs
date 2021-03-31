using System;
using System.Data;
using System.Security.Cryptography;
using UnityEditor.Experimental;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject backlog;
    public GameObject toDo;
    public GameObject onProgress;
    public GameObject done;


    private static Board _instance;

    public static Board getInstance()
    {
        return _instance;
    }

    //Singleton pattern
    //https://gamedev.stackexchange.com/questions/116009/in-unity-how-do-i-correctly-implement-the-singleton-pattern
    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    
    private Board(){}

    public ColumnGameplayComponent getColumn(string tag)
    {
        switch (tag)
        {
            case ColumnGameplayComponent.BACLOG_TAG:
                return backlog.GetComponent<Column>().getGameplayComponent();
            case ColumnGameplayComponent.TODO_TAG:
                return toDo.GetComponent<Column>().getGameplayComponent();
            case ColumnGameplayComponent.ONPROGRESS_TAG:
                return onProgress.GetComponent<Column>().getGameplayComponent();
            case ColumnGameplayComponent.DONE_TAG:
                return done.GetComponent<Column>().getGameplayComponent();
            default:
                throw new Exception("Invalid Column name");
        }
        
    } 
    

}
