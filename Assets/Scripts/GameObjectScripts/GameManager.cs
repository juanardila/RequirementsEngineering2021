using System;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameManager : MonoBehaviour, IOnEventCallback
{
    public GameObject userStoryPrefab;
    private void Start()
    {
        PhotonNetwork.AddCallbackTarget(this);
        Tuple<int, string, int>[] userStories = FileManager.getInstance().parseUserStories();
        foreach (Tuple<int, string, int> userStoryData in userStories)
        {
            GameObject userStoryGameObject = Instantiate(userStoryPrefab);
            UserStory userStory = userStoryGameObject.GetComponent<UserStory>();
            userStory.initializeGameplay(userStoryData.Item1, userStoryData.Item2, userStoryData.Item3);
        }
    }
    
    
    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;
        switch (eventCode)
        {
            case UserStoryNetworkingComponent.MOVECARD_CODE:
                object[] data = (object[])photonEvent.CustomData;
                UserStoryGameplayComponent.moveToColumn((int)data[0],(string) data[1],(string) data[2] );
                break;
            case SprintNetworkComponent.STARTWORKWITHINITERATION_CODE:
                Sprint.getInstance().getGameplayComponent().advanceToWorkWithInIteration();
                break;

        }
    }
}
