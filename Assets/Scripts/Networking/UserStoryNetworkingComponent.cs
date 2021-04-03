using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class UserStoryNetworkingComponent
{
    public const byte MOVECARD_CODE = 1;

    public UserStoryNetworkingComponent()
    {}

    public void sendMoveUserStory(int userStoryId, string prevColumn, string newColumn)
    {
        object[] content = new object[] {userStoryId, prevColumn, newColumn};
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        PhotonNetwork.RaiseEvent(MOVECARD_CODE, content, raiseEventOptions, SendOptions.SendReliable);
    }
    
}
