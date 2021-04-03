using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject userStoryPrefab;
    private void Start()
    {
        //GameObject userStoryGameObject =  Instantiate(userStoryPrefab);
        //UserStory userStory = userStoryGameObject.GetComponent<UserStory>();
        //userStory.initializeGameplay("1", "This works", "30");
        Tuple<int, string, int>[] userStories = FileManager.getInstance().parseUserStories();
        foreach (Tuple<int, string, int> userStoryData in userStories)
        {
            GameObject userStoryGameObject =  Instantiate(userStoryPrefab);
            UserStory userStory = userStoryGameObject.GetComponent<UserStory>();
            userStory.initializeGameplay(userStoryData.Item1, userStoryData.Item2, userStoryData.Item3);
        }
    }
}
