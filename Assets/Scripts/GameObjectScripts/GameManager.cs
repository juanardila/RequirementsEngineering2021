using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject userStoryPrefab;
    private void Start()
    {
        GameObject userStoryGameObject =  Instantiate(userStoryPrefab);
        UserStory userStory = userStoryGameObject.GetComponent<UserStory>();
        userStory.initializeGameplay("1", "This works", "30");
    }
}
