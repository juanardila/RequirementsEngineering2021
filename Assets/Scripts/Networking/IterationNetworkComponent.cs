
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

public class IterationNetworkComponent
{
    public const byte TURNPLAYED_CODE = 3;
    public const byte FINISHTURN_CODE = 4;
    public const byte USESOLUTION_CODE = 5;

    public static void sendTurnInfo(int userStoryId, int rollValue, int chanceCard)
    {
        object[] content = new object[] {userStoryId, rollValue, chanceCard};
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        PhotonNetwork.RaiseEvent(TURNPLAYED_CODE, content, raiseEventOptions, SendOptions.SendReliable);
    }

    public static void sendEndIteration()
    {
        object[] content = new object[] {};
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        PhotonNetwork.RaiseEvent(FINISHTURN_CODE, content, raiseEventOptions, SendOptions.SendReliable);
    }

    public static void sendUseSolution(int userStoryId)
    {
        object[] content = new object[] {};
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        PhotonNetwork.RaiseEvent(USESOLUTION_CODE, content, raiseEventOptions, SendOptions.SendReliable);
    }
    


}
