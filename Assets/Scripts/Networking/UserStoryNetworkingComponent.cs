using Photon.Pun;
using UnityEngine;

public class UserStoryNetworkingComponent : PhotonView
{
    private PhotonView photonView;

    public UserStoryNetworkingComponent(PhotonView photonView)
    {
        this.photonView = photonView;
    }

    public void sendMoveUserStory(int userStoryId, string column)
    {
        photonView.RPC("_moveUserStory", RpcTarget.Others, userStoryId, column);
        Debug.Log("Story Moved send");
    }
    
}
