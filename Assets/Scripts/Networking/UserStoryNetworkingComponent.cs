using Photon.Pun;
using UnityEngine;

public class UserStoryNetworkingComponent : PhotonView
{
    private PhotonView photonView;

    public UserStoryNetworkingComponent(PhotonView photonView)
    {
        this.photonView = photonView;
    }

    public void sendMoveUserStory(int userStoryId, string prevColumn, string newColumn)
    {
        photonView.RPC("_moveUserStory", RpcTarget.Others, userStoryId, prevColumn, newColumn);
        Debug.Log("Story Moved send");
    }
    
}
