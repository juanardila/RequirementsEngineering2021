using System;
using SimpleJSON;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public TextAsset JsonAsset;
    private JSONNode _json;

    private static FileManager _instance;

    public static FileManager getInstance()
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
            _json = JSON.Parse(JsonAsset.text);
            _instance = this;
        }
    }
    
    private FileManager(){}
    
    public Tuple<int, string, int>[] parseUserStories()
    {
        JSONNode jsonUserStories = _json["user_stories"];
        Tuple<int, string, int>[] userStories = new Tuple<int, string, int>[jsonUserStories.Count];
        for (int index = 0; index < jsonUserStories.Count; ++index)
        {
            userStories[index] = new Tuple<int, string, int>(
                jsonUserStories[index]["id"].AsInt,
                jsonUserStories[index]["text"].Value,
                jsonUserStories[index]["points"].AsInt
            );
        }
        return userStories;
    }
}